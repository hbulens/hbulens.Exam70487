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
            IVideoStream video = default(IVideoStream);

            // *************************************************************************************************************************
            // If BLOB is not activated, let the code below comment
            // *************************************************************************************************************************
            string startupPath = Path.Combine(Environment.CurrentDirectory, "Media");
            video = new LocalVideoStream(startupPath, filename, ext);

            // *************************************************************************************************************************
            // If you want to use BLOB storage, comment the code above and uncomment the code below
            // NOTE: you may have to change the URL of the file - depending on your setup in the BLOB project
            // *************************************************************************************************************************
            //string fileUri = "http://127.0.0.1:10000/devstoreaccount1/democontainerblockblob/polina.webm";
            //video = new RemoteVideoStream(new Uri(fileUri));

            HttpResponseMessage response = Request.CreateResponse();
            response.Content = new PushStreamContent((x, y, z) => video.WriteToStream(x), new MediaTypeHeaderValue("video/" + ext));

            return response;
        }
    }
}
