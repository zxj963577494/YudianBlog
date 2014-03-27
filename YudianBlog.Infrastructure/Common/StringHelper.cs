using System;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace YudianBlog.Infrastructure.Common
{
    public class StringHelper
    {
        public static string Filter(string sInput)
        {
            if ((sInput == null) || (sInput == ""))
            {
                return null;
            }
            string sInput1 = sInput.ToLower();
            string output = sInput;
            string pattern = "*|and|exec|insert|select|delete|update|count|master|truncate|declare|char(|mid(|chr(|'";
            if (Regex.Match(sInput1, Regex.Escape(pattern), RegexOptions.IgnoreCase).Success)
            {
                output = output.Replace(sInput, "''");
            }
            else
            {
                output = output.Replace("'", "''");
            }
            return output;
        }

        public static string InputTexts(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }
            text = Regex.Replace(text, @"[\s]{2,}", " ");
            text = Regex.Replace(text, @"(<[b|B][r|R]/*>)+|(<[p|P](.|\n)*?>)", "\n");
            text = Regex.Replace(text, @"(\s*&[n|N][b|B][s|S][p|P];\s*)+", " ");
            text = Regex.Replace(text, @"<(.|\n)*?>", string.Empty);
            text = text.Replace("'", "''");
            return text;
        }

        public static double String2Double(string str)
        {
            if (ValidateHelper.IsDecimal(str))
            {
                return double.Parse(str);
            }
            return 0.0;
        }

        public static DateTime StringToDateTime(string str)
        {
            if (ValidateHelper.IsDateTime(str))
            {
                return DateTime.Parse(str);
            }
            return DateTime.Parse("1900-1-1");
        }

        public static int StringToInt(string str)
        {
            if (ValidateHelper.IsNumberSign(str))
            {
                return int.Parse(str);
            }
            return 0;
        }

        public static string SubString(string SoucreStr, int len)
        {
            string result = SoucreStr;
            if (SoucreStr.Length >= len)
            {
                result = SoucreStr.Substring(0, len);
            }
            return result;
        }

        public static string SubString(string str, int begin, int length)
        {
            if (str.Length < begin)
            {
                return "";
            }
            if (length >= (str.Length - begin))
            {
                length = str.Length - begin;
            }
            return str.Substring(begin, length);
        }

        public static string SubStringAndAppend(string str, int length, string appendCode)
        {
            return (SubString(str, length) + appendCode);
        }

        public static string SubStringHTML(string htmlString, int length, string appendCode)
        {
            MatchCollection matchCollection = null;
            int i;
            StringBuilder resultString = new StringBuilder();
            int charLength = 0;
            bool isHtmlMark = false;
            bool isHtmlCode = false;
            char[] pChars = htmlString.ToCharArray();
            for (i = 0; i < pChars.Length; i++)
            {
                char charTemp = pChars[i];
                if (charTemp.Equals("<"))
                {
                    isHtmlMark = true;
                }
                else if (charTemp.Equals("&"))
                {
                    isHtmlCode = true;
                }
                else if (charTemp.Equals(">") && isHtmlMark)
                {
                    charLength--;
                    isHtmlMark = false;
                }
                else if (charTemp.Equals(";") && isHtmlCode)
                {
                    isHtmlCode = false;
                }
                if (!isHtmlCode && !isHtmlMark)
                {
                    charLength++;
                    if (Encoding.Default.GetBytes(new char[charTemp]).Length > 1)
                    {
                        charLength++;
                    }
                }
                resultString.Append(charTemp);
                if (charLength >= length)
                {
                    break;
                }
            }
            resultString.Append(appendCode);
            matchCollection = Regex.Matches(Regex.Replace(Regex.Replace(Regex.Replace(resultString.ToString(), "(>)[^<>]*(<?)", "$1$2", RegexOptions.IgnoreCase), "</?(area|base|basefont|body|br|col|colgroup|dd|dt|frame|head|hr|html|img|input|isindex|li|link|meta|option|p|param|tbody|td|tfoot|th|thead|tr)[^<>]*/?>", "", RegexOptions.IgnoreCase), @"<([a-zA-Z]+)[^<>]*>(.*?)</\1>", "", RegexOptions.IgnoreCase), "<([a-zA-Z]+)[^<>]*>");
            ArrayList htmlArray = new ArrayList();
            foreach (Match mt in matchCollection)
            {
                htmlArray.Add(mt.Result("$1"));
            }
            for (i = htmlArray.Count - 1; i >= 0; i--)
            {
                resultString.Append("</");
                resultString.Append(htmlArray[i]);
                resultString.Append(">");
            }
            return resultString.ToString();
        }

        public static string ToString(object obj)
        {
            if (obj != null)
            {
                return obj.ToString();
            }
            return "";
        }
    }
}

