﻿using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace FrameWork.Application
{
    public static class Slugify
    {
      public static string GenerateSlug(this string phrase)
        {
            var s= phrase.RemoveDiacrutucs().ToLower();
            s = Regex.Replace(s, @"[^\u0600-\u06FF\uFB8A\u067E\u0686\u06AF\u200C\u200Fa-z0-9\s-]", "");
            s = Regex.Replace(s, @"\s+", " ").Trim();
            s=s.Substring(0, s.Length <=100 ?s.Length:45).Trim();
            s = Regex.Replace(s, @"\s", "-");
            s = Regex.Replace(s, @"", "-");
            return s.ToLower();

        }
        public static string RemoveDiacrutucs(this string text)
        {if(string.IsNullOrWhiteSpace(text))
            return string.Empty;
            var normalizedstring = text.Normalize(NormalizationForm.FormKC);
            var stringbuilder=new StringBuilder();
            foreach (var c in normalizedstring)
            {
                var unicodeCategory=CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                    stringbuilder.Append(c);
            }
            return stringbuilder.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
