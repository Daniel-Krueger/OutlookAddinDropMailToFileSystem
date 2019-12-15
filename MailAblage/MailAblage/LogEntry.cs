using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailAblage
{
    public class LogEntry
    {
        public string MailSubject { get; set; }
        public DateTime MailDateTime { get; set; }
        public string Folder { get; set; }
        public string Filename { get; set; }
        public bool deleted { get; set; }
        public string MessageId { get; set; }
        public string Message { get; set; }
    }
}
