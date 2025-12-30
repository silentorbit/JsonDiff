
# JsonDiff

Calculate difference between objects of the same type.

The difference is presented in a generated `MyClass.Diff` class that can be serialized with `System.Text.Json`.

## JSON format

The goal is to have a compact and readable format.

The serialized format is similar to [JSON Merge Patch](https://datatracker.ietf.org/doc/html/rfc7386) but with some significant differences.

- JsonDiff is not working with generic JSON documents, its strongly typed to the classes marked up.
- JsonDiff differentiates between full and partial object replace. This is seen in the JSON format where partial replacements are prefixed with "^".

Example: A is completly replaced by the new values.

```
{
  "A": { "B": 3, "C": 4 }
}
```

Example: A is partially modified, C is replaced by 4 and B is not modified.

```
{
  "^A": { "C": 4 }
}
```

Further on other symbol prefixes may be used for other operations not yet supported. For example list or substring manipulation.

[Read more...](https://github.com/silentorbit/JsonDiff/blob/master/JSON-Format.txt)

# Code Example

See examples in [Demo](https://github.com/silentorbit/JsonDiff/blob/master/Demo/Demo.Shared/Program.cs)

# Features

Assign attributes to control the source generation.

## Class Attribute

Assign this to every class that will be compared on a per property level.
Classes missing this will be treated as "immutable", any change will be indicated by a complete copy.

- [[JsonDiffClass]](https://github.com/silentorbit/JsonDiff/blob/master/JsonDiff/JsonDiff.Abstractions/Attributes/JsonDiffClassAttribute.cs)

## Property Attributes

- [[JsonDiffAlways]](https://github.com/silentorbit/JsonDiff/blob/master/JsonDiff/JsonDiff.Abstractions/Attributes/JsonDiffAlwaysAttribute.cs)
- [[JsonDiffFullCloneAttribute]](https://github.com/silentorbit/JsonDiff/blob/master/JsonDiff/JsonDiff.Abstractions/Attributes/JsonDiffFullCloneAttribute.cs)
- [[JsonDiffIgnoreAttribute]](https://github.com/silentorbit/JsonDiff/blob/master/JsonDiff/JsonDiff.Abstractions/Attributes/JsonDiffIgnoreAttribute.cs)
- [[JsonDiffImmutableAttribute]](https://github.com/silentorbit/JsonDiff/blob/master/JsonDiff/JsonDiff.Abstractions/Attributes/JsonDiffImmutableAttribute.cs)

# Installing

Two options: NuGet package or from source.

## NuGet

Install NuGet package: [`SilentOrbit.JsonDiff`](https://www.nuget.org/packages/SilentOrbit.JsonDiff/)

Sample: [`Demo.NuGet` on GitHub](https://github.com/silentorbit/JsonDiff/tree/master/Demo/Demo.NuGet)

## Source

Clone [`JsonDiff` on GitHub](https://github.com/silentorbit/JsonDiff/)

Sample: [`Demo.Source` on GitHub](https://github.com/silentorbit/JsonDiff/tree/master/Demo/Demo.Source) (Same Repo)

# Configurations

Demo.csproj has 3 extra configurations.
The purpose of these are to enable one time source generation.

`Debug` and `Release` behaves as normal, using the source generator.

`GenerateSource` Generates the source and saves it inside the project, allowing you to save the source code in git.  

The saved source code is only used in `DebugGenerated` and `ReleaseGenerated`.  
You may choose to copy the configuration from these into your project, allowing one time code generation.

| Configuration          | Source Generation | Save to "Generated" | Build                |
| ---------------------- | ----------------- | ------------------- | -------------------- |
| Debug                  | Yes               | No                  | Newly generated      |
| Release                | Yes               | No                  | Newly generated      |
| GenerateSource (Debug) | Yes               | Yes                 | Newly generated      |
| DebugGenerated         | No                | No                  | Previously generated |
| ReleaseGenerated       | No                | No                  | Previously generated |

