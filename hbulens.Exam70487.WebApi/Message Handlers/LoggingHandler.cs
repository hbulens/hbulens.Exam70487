using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hbulens.Exam70487.WebApi
{
    public class LoggingHandler : DelegatingHandler
    {
        #region Constructor
       
        #endregion Constructor

        #region Properties

        protected static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion Properties

        #region Methods

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _logger.Debug(string.Format("Request received on {0}", DateTime.Now.ToString()));
            return base.SendAsync(request, cancellationToken);
        }

        #endregion Methods
    }
}
