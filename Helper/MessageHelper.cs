using System.Runtime.Serialization;

namespace SalesAPI.Helper
{
    public class MessageHelper
    {
        [DataMember]
        public string Message { get; set; }
        public int statuscode { get; set; }
        public long Key { get; set; }
    }
}
