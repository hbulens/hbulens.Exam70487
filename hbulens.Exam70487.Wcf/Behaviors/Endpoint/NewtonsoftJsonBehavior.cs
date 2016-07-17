using hbulens.Exam70487.Wcf.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Wcf.Behaviors.Service
{
    public class NewtonsoftJsonBehavior : WebHttpBehavior
    {
        public override void Validate(ServiceEndpoint endpoint)
        {
            base.Validate(endpoint);

            BindingElementCollection elements = endpoint.Binding.CreateBindingElements();
            WebMessageEncodingBindingElement webEncoder = elements.Find<WebMessageEncodingBindingElement>();
            if (webEncoder == null)
            {
                throw new InvalidOperationException("This behavior must be used in an endpoint with the WebHttpBinding(or a custom binding with the WebMessageEncodingBindingElement).");
            }

            foreach (OperationDescription operation in endpoint.Contract.Operations)
            {
                this.ValidateOperation(operation);
            }
        }

        protected override IDispatchMessageFormatter GetRequestDispatchFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
        {
            if (this.IsGetOperation(operationDescription))
            {
                // no change for GET operations
                return base.GetRequestDispatchFormatter(operationDescription, endpoint);
            }

            if (operationDescription.Messages[0].Body.Parts.Count == 0)
            {
                // nothing in the body, still use the default
                return base.GetRequestDispatchFormatter(operationDescription, endpoint);
            }

            return new NewtonsoftJsonDispatchFormatter(operationDescription, true);
        }

        protected override IDispatchMessageFormatter GetReplyDispatchFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
        {
            if (operationDescription.Messages.Count == 1 || operationDescription.Messages[1].Body.ReturnValue.Type == typeof(void))
            {
                return base.GetReplyDispatchFormatter(operationDescription, endpoint);
            }
            else
            {
                return new NewtonsoftJsonDispatchFormatter(operationDescription, false);
            }
        }

        protected override IClientMessageFormatter GetRequestClientFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
        {
            if (operationDescription.Behaviors.Find<WebGetAttribute>() != null)
            {
                // no change for GET operations
                return base.GetRequestClientFormatter(operationDescription, endpoint);
            }
            else
            {
                WebInvokeAttribute wia = operationDescription.Behaviors.Find<WebInvokeAttribute>();
                if (wia != null)
                {
                    if (wia.Method == "HEAD")
                {
                        // essentially a GET operation
                        return base.GetRequestClientFormatter(operationDescription, endpoint);
                    }
                }
            }

            if (operationDescription.Messages[0].Body.Parts.Count == 0)
            {
                // nothing in the body, still use the default
                return base.GetRequestClientFormatter(operationDescription, endpoint);
            }

            return new NewtonsoftJsonClientFormatter(operationDescription, endpoint);
        }

        protected override IClientMessageFormatter GetReplyClientFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
        {
            if (operationDescription.Messages.Count == 1 || operationDescription.Messages[1].Body.ReturnValue.Type == typeof(void))
            {
                return base.GetReplyClientFormatter(operationDescription, endpoint);
            }
            else
            {
                return new NewtonsoftJsonClientFormatter(operationDescription, endpoint);
            }
        }

        private bool IsGetOperation(OperationDescription operation)
        {
            WebGetAttribute wga = operation.Behaviors.Find<WebGetAttribute>();
            if (wga != null)
            {
                return true;
            }

            WebInvokeAttribute wia = operation.Behaviors.Find<WebInvokeAttribute>();
            if (wia != null)
            {
                return wia.Method == "HEAD";
            }

            return false;
        }
        private string GetUriTemplate(OperationDescription operation)
        {
            WebGetAttribute wga = operation.Behaviors.Find<WebGetAttribute>();
            if (wga != null)
            {
                return wga.UriTemplate;
            }

            WebInvokeAttribute wia = operation.Behaviors.Find<WebInvokeAttribute>();
            if (wia != null)
            {
                return wia.UriTemplate;
            }

            return null;
        }

        private WebMessageBodyStyle GetBodyStyle(OperationDescription operation)
        {
            WebGetAttribute wga = operation.Behaviors.Find<WebGetAttribute>();
            if (wga != null)
            {
                return wga.BodyStyle;
            }

            WebInvokeAttribute wia = operation.Behaviors.Find<WebInvokeAttribute>();
            if (wia != null)
            {
                return wia.BodyStyle;
            }

            return this.DefaultBodyStyle;
        }
        private void ValidateOperation(OperationDescription operation)
        {            
        }
    }
}
