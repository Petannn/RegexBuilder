using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexBuilder
{
    public static class MetaChars
    {
        public const string Any = ".";
        public const string AnyDigit = "\\d";
        public const string NonDigit = "\\D";
        public const string WordCharacter = "\\w";
        public const string NonWordCharacter = "\\W";
        public const string WhiteSpace = "\\s";
        public const string NonWhiteSpace = "\\S";
    }

    public static class Anchors
    {
        public const string StartLine = "^";
        public const string EndLine = "$";
        public const string StartString = "\\A";
        public const string EndStringAndLasLine = "\\Z";
        public const string EndString = "\\z";
        public const string PreviousMatchEnd = "\\G";
        public const string WordBoundary = "\\b";
        public const string NonWordBoundary = "\\B";
    }
}
