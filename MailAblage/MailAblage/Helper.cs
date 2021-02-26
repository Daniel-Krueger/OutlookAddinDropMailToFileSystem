using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MailAblage
{
    public static class Helper
    {
        private const string fileNamePatternGroup = "filename";
        private static Regex FileNamePattern = new Regex(@"(^\d{4}-\d{1,2}-\d{1,2}\s*(\(\d*\))?\s*)?(?<" + fileNamePatternGroup + @">.*)\.[^.]*$");

        public static string GetFileNamePattern(string filename)
        {
            var matches = FileNamePattern.Match(filename);
            if (matches.Success)
            {
                return matches.Groups[fileNamePatternGroup].Value;
            }
            return filename;
        }

        public static void GetNewEntryFromMessage(System.IO.MemoryStream filestream, out LogEntry newEntry)
        {
            using (OutlookStorage.Message outlookMsg = new OutlookStorage.Message(filestream))
            {
                newEntry = new LogEntry();
                newEntry.MailDateTime = outlookMsg.ReceivedDate;
                newEntry.MessageId = outlookMsg.ID;
                newEntry.MailSubject = outlookMsg.Subject;

                if (outlookMsg.From == "ALEREMOTE")
                {
                    if (outlookMsg.Subject == "Z_FIRSTLOAD")
                    {
                        newEntry.Filename = $"{newEntry.MailDateTime.ToString("yyyy-MM-dd")} (1) BW (Query) (20_ALY_open orders) (fehlende Aufträge) (ZFIRSTLOAD) ({newEntry.MailDateTime.ToString("HHmm")} Uhr).msg";
                        newEntry.SpecialCase = true;
                    }
                    else if (outlookMsg.Subject == "SAP BW dataloads")
                    {
                        newEntry.Filename = $"{newEntry.MailDateTime.ToString("yyyy-MM-dd")} (1) BW (Query) (20_ALY_open orders) (fehlende Aufträge) (ALEREMOTE) ({newEntry.MailDateTime.ToString("HHmm")} Uhr).msg";
                        newEntry.SpecialCase = true;
                    }
                }
            }
        }
    }
}
