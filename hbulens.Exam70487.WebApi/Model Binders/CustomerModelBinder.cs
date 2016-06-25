using hbulens.Exam70487.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;

namespace hbulens.Exam70487.WebApi
{
    public class CustomerModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(Customer))
            {
                return false;
            }

            ValueProviderResult val = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (val == null)
            {
                return false;
            }

            string key = val.RawValue as string;
            if (key == null)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Wrong value type");
                return false;
            }

            Customer result;
            if (Customer.TryParse(key, out result))
            {
                bindingContext.Model = result;
                return true;
            }

            bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Cannot convert value to Customer");
            return false;
        }
    }
}
