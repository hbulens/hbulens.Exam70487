using hbulens.Exam70487.Common.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace hbulens.Exam70487.WebApi.Controllers
{
    public class VideosController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="ext"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(string filename, string ext)
        {
            string startupPath = Path.Combine(Environment.CurrentDirectory, "Media");
            VideoStream video = new VideoStream(startupPath, filename, ext);

            HttpResponseMessage response = Request.CreateResponse();
            response.Content = new PushStreamContent((x, y, z) => video.WriteToStream(x), new MediaTypeHeaderValue("video/" + ext));

            return response;
        }
    }
}
