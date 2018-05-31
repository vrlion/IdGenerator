using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdGenerator
{
    public class IdGenerator
    {
        public static string CreateShortId(Guid? guid = null)
        {
            guid = guid ?? Guid.NewGuid();
            var base64Guid = Convert.ToBase64String(guid.Value.ToByteArray());
            // Replace URL unfriendly characters with better ones
            base64Guid = base64Guid.Replace('+', '-').Replace('/', '_');
            // Remove the trailing ==
            return base64Guid.Substring(0, base64Guid.Length - 2);
        }

        public static Guid FromShortId(string str)
        {
            str = str.Replace('_', '/').Replace('-', '+');
            var byteArray = Convert.FromBase64String(str + "==");
            return new Guid(byteArray);
        }
    }
}
