using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;

namespace hbulens.Exam70487.WebApi
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        #region Constructor

        public GlobalExceptionFilter()
        {

        }

        #endregion Constructor

        #region Properties

        protected static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion Properties

        #region Methods

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            _logger.Error(actionExecutedContext.Exception.Message);
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(actionExecutedContext.Exception.Message),
                ReasonPhrase = "Exception"
            });
        }

        #endregion Methods                
    }
}
