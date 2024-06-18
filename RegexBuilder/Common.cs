namespace RegexBuilder;

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
    public const string EndStringOrEndLine = "\\Z";
    public const string EndString = "\\z";
    public const string PreviousMatchEnd = "\\G";
    public const string WordBoundary = "\\b";
    public const string NonWordBoundary = "\\B";
}

public static class EscapedChars
{
    public const string Bell = "\\a";
    public const string Backspace = "\\b";
    public const string Tab = "\\t";
    public const string CarriageReturn = "\\b";
    public const string VerticalTab = "\\v";
    public const string FormFeed = "\\f";
    public const string NewLine = "\\n";
    public const string Escape = "\\e";
    public const string OctalRepresentation = "\\";
    public const string HexadecimalRepresentation = "\\x";
    public const string ASCIIControlChar = "\\c";
    public const string Unicode = "\\u";
}

public static class Substitutions
{
    public const string Placeholder = "$";
}