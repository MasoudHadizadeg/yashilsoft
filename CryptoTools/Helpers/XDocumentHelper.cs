using System.IO;
using System.Xml.Linq;

namespace CryptoTools.Helpers
{
    public class XDocumentHelper
    {
        public static byte[] GetBytes(XDocument document)
        {
            var stream = new MemoryStream();
            document.Save(stream);
            stream.Position = 0;
            var array = stream.ToArray();
            stream.Dispose();
            return array;
        }
    }
}
