
# ⚡ SilentOrbit.JsonDiff


Strong-typed object diffing for dotnet with a compact and readable JSON format.

JsonDiff generates a companion .Diff class for your models at compile-time.
It allows you to track changes, reduce network payload, and sync state with System.Text.Json serialization.

# 🚀 Quick Start

## Mark your classes

Add `partial` and [`[JsonDiffClass]`](https://github.com/silentorbit/JsonDiff/blob/master/JsonDiff/JsonDiff.Abstractions/Attributes/JsonDiffClassAttribute.cs) to the models you want to track.

```C#
[JsonDiffClass]
public partial class UserProfile {
    public string Name { get; set; }
    public int Level { get; set; }
    ...
```

## Detect changes
```C#
var profile = new UserProfile();
var diff = original.CreateReferenceDiff();

// Modify
profile.Name = "Alice";
profile.Level = 42;

// Calculate changes
diff.TrimIsUnchanged(profile);

var json = JsonSerializer.Serialize(diff);
// {"Name":"Alice","Level":42}
```

## Apply Diff

```
UserProfile current = ...
UserProfile.Diff diff = ...

// Reconstruct the previous revision
var previous = diff.ApplyTo(current);
        
```

See other examples in [Demo](https://github.com/silentorbit/JsonDiff/blob/master/Demo/Demo.Shared/Program.cs)


# 📦 JSON format

JsonDiff is designed for readability and minimal size. It uses a prefix system for partial updates:

- Full Replace: `{ "Settings": { "Theme": "Dark" } }`  
(Overwrites the entire Settings object)

- Partial Patch: `{ "^Settings": { "Theme": "Dark" } }`  
(Only updates the Theme; keeps other Settings intact)

Note: The ^ prefix tells the parser to perform a partial update rather than a total replacement.

Backwards compatibility, you can start with only a few classes using partial patch and later extend to more classes, old serialized JSON is compatible with the updated code thanks to the prefix system.

[Read more...](https://github.com/silentorbit/JsonDiff/blob/master/JSON-Format.txt)

# 🛠️ Installation
Get up and running via NuGet:

```Bash
dotnet add package SilentOrbit.JsonDiff
```

Includes both 
[`SilentOrbit.JsonDiff.Abstraction`](https://www.nuget.org/packages/SilentOrbit.JsonDiff.Abstraction/)
[`SilentOrbit.JsonDiff.Generator`](https://www.nuget.org/packages/SilentOrbit.JsonDiff.Generator/)

## 📜 From Source

Explore
[`Demo.NuGet`](https://github.com/silentorbit/JsonDiff/tree/master/Demo/Demo.NuGet)
and
[`Demo.Source`](https://github.com/silentorbit/JsonDiff/tree/master/Demo/Demo.Source)
on GitHub.

## 🏗️ Build Configurations

To check generated code into Source Control (Git), we provide build targets in the Demo.Source.csproj:

- Debug/Release: Standard background source generation.
- GenerateSource: Runs the generator and saves the .cs files to your /Generated folder.
- DebugGenerated: Builds using the saved files (Source Generator disabled).

| Configuration          | Source Generation | Save to "Generated" | Build                |
| ---------------------- | ----------------- | ------------------- | -------------------- |
| Debug                  | Yes               | No                  | Newly generated      |
| Release                | Yes               | No                  | Newly generated      |
| GenerateSource (Debug) | Yes               | Yes                 | Newly generated      |
| DebugGenerated         | No                | No                  | Previously generated |
| ReleaseGenerated       | No                | No                  | Previously generated |



# ⚙️ Advanced Control

Fine-tune how your diffs are generated using property attributes:

| Attribute | Effect |
| --- | --- |
| [[JsonDiffAlways]](https://github.com/silentorbit/JsonDiff/blob/master/JsonDiff/JsonDiff.Abstractions/Attributes/JsonDiffAlwaysAttribute.cs) | Always include this property in the diff, assume always changed. |
| [[JsonDiffIgnore]](https://github.com/silentorbit/JsonDiff/blob/master/JsonDiff/JsonDiff.Abstractions/Attributes/JsonDiffIgnoreAttribute.cs) | Don't include this property in the diff. |
| [[JsonDiffImmutable]](https://github.com/silentorbit/JsonDiff/blob/master/JsonDiff/JsonDiff.Abstractions/Attributes/JsonDiffImmutableAttribute.cs) | Treat the property as a single value, never attempt a partial patch. |
| [[JsonDiffFull]](https://github.com/silentorbit/JsonDiff/blob/master/JsonDiff/JsonDiff.Abstractions/Attributes/JsonDiffFullAttribute.cs) | Force a deep copy of the value when a change is detected. |




