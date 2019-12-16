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
        private static Regex FileNamePattern = new Regex(@"\d{4}-\d{1,2}-\d{1,2}\s*(\(\d*\))?\s*(?<" + fileNamePatternGroup + @">.*)\.[^.]*$");

        public static string GetFileNamePattern(string filename)
        {
            var matches = FileNamePattern.Match(filename);
            if (matches.Success)
            {
                return matches.Groups[fileNamePatternGroup].Value;
            }
            return filename;
        }
    }
}
