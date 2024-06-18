# RegexBuilder 
Fluent Regex Construction Library

## Overview

RegexBuilder is a C# library designed to simplify the creation of regular expressions using fluent extension methods. This library allows you to build complex regular expressions in a readable and maintainable way.

## Features

- Fluent interface for building regular expressions.
- Easy-to-read and maintain syntax.
- No unnecessary memory allocations
- Extensible using user-defined extension methods to assemble commonly used expressions in the project

## Example Code

```csharp
IRegexBuilder regexBuilder = new RegexBuilder();
regexBuilder
    .Add("Hello")
    .WhiteSpace()
    .Group(q =>
        q.Add("world")
         .Or()
         .Add("universe"));

var regex = regexBuilder.Build(); // pattern: Hello\s(world|universe)
Console.WriteLine("pattern: " + regex);
var matches = regex.Matches("Hello world Hello universe"); // match1: "Hello world" match2:  "Hello universe"
for (int i = 0; i < matches.Count; i++)
{
    Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "match{0}: \"{1}\"", i+1, matches[i]));
}
```

Output
```
pattern: Hello\s(world|universe)
match1: "Hello world"
match2: "Hello universe"
```
## License
This project is licensed under the MIT License. See the LICENSE file for more details.