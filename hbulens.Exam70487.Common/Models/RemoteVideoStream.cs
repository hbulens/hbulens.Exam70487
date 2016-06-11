using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.Exam70487.Common.Models
{
    public class RemoteVideoStream : IVideoStream
    {
        #region Constructor

        public RemoteVideoStream(Uri uri)
        {
            this._uri = uri;
        }

        #endregion Constructor

        #region Properties

        private readonly Uri _uri;

        #endregion Properties

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputStream"></param>
        public async void WriteToStream(Stream outputStream)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] buffer = webClient.DownloadData(this._uri);
                    using (MemoryStream mem = new MemoryStream(buffer))
                    {
                        var length = (int)mem.Length;
                        var bytesRead = 1;

                        while (length > 0 && bytesRead > 0)
                        {
                            bytesRead = await mem.ReadAsync(buffer, 0, Math.Min(length, buffer.Length));
                            await outputStream.WriteAsync(buffer, 0, bytesRead);
                            length -= bytesRead;
                        }                       
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
            finally
            {
                outputStream.Close();
            }
        }

        #endregion Methods

    }
}
