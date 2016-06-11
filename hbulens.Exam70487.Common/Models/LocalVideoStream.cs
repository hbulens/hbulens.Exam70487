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
    public class LocalVideoStream : IVideoStream
    {
        #region Constructor

        public LocalVideoStream(string path, string filename, string ext)
        {
            _filename = Path.Combine(path, filename + "." + ext);
        }

        #endregion Constructor

        #region Properties

        private readonly string _filename;

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
                byte[] buffer = new byte[65536];

                using (FileStream video = File.Open(_filename, FileMode.Open, FileAccess.Read))
                {
                    var length = (int)video.Length;
                    var bytesRead = 1;

                    while (length > 0 && bytesRead > 0)
                    {
                        bytesRead = await video.ReadAsync(buffer, 0, Math.Min(length, buffer.Length));
                        await outputStream.WriteAsync(buffer, 0, bytesRead);
                        length -= bytesRead;
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
