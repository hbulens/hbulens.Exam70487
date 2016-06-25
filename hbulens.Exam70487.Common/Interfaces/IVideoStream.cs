using System.IO;

namespace hbulens.Exam70487.Common.Models
{
    public interface IVideoStream
    {
         void WriteToStream(Stream outputStream);
    }
}