using System.Text.Json.Nodes;

namespace LMS.Models
{
    public sealed class RRM 
    {

        public string Status { get; set; }
        public long ID { get; set; }
        public string RefNo { get; set; }
        public string Message { get; set; }
        public string Error_Msg { get; set; }
        public string Error_Desc { get; set; }
        public dynamic? RData { get; set; }

    }
}
