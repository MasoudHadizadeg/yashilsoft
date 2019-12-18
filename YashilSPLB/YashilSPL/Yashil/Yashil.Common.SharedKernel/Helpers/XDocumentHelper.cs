using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace Yashil.Common.SharedKernel.Helpers
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
