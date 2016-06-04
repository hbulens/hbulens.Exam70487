using hbulens.Exam70487.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.WebApi.Formatters
{
    /// <summary>
    /// Code based on http://www.asp.net/web-api/overview/formats-and-model-binding/media-formatters
    /// </summary>
    internal class CsvFormatter : BufferedMediaTypeFormatter
    {
        #region Constructor

        public CsvFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv"));
        }

        #endregion Constructor

        #region Properties

        private static char[] _specialChars = new char[] { ',', '\n', '\r', '"' };

        #endregion Properties

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override bool CanReadType(Type type)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public override bool CanWriteType(Type type)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="writeStream"></param>
        /// <param name="content"></param>
        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            using (var writer = new StreamWriter(writeStream))
            {
                var customers = value as IEnumerable<Customer>;
                if (customers != null)
                {
                    foreach (Customer customer in customers)
                    {
                        this.WriteItem(customer, writer);
                    }
                }
                else
                {
                    var singleCustomer = value as Customer;
                    if (singleCustomer == null)
                    {
                        throw new InvalidOperationException("Cannot serialize type");
                    }

                    this.WriteItem(singleCustomer, writer);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="writer"></param>
        private void WriteItem(Customer customer, StreamWriter writer)
        {
            writer.WriteLine("{0},{1}", customer.Id.ToString(), customer.Name);
        }

        #endregion Methods

    }
}
