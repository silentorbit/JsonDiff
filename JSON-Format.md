
# JSON format

The serialized format is similar to [JSON Merge Patch](https://datatracker.ietf.org/doc/html/rfc7386) but with some significant differences with prefixes to separate full vs partial replace.

The goal is to have the diff in a compact and readable format.

This describes how properties diff in a class with attribute [`[JsonDiffClass]`](https://github.com/silentorbit/JsonDiff/blob/master/JsonDiff/JsonDiff.Abstractions/Attributes/JsonDiffClassAttribute.cs) are generated.

## Base Concepts

* Unchanged properties are omitted from the serialization
* Explicit `null` means Clear: A `null` value in the diff explicitly sets that property to `null`.
* The Caret (^) Prefix differentiates between full replacement and partial update.

## Examples

See more detailed examples in [Demo.Shared/Program.cs](https://github.com/silentorbit/JsonDiff/blob/master/Demo/Demo.Shared/Program.cs)

## Modified Properties

How a change is serialized depends on the type of property and whether it is marked for diffing.

### Primitives & Standard Classes (Full Replace)
Primitives and classes without the `[JsonDiffClass]` attribute (or properties explicitly marked `[JsonDiffClass]`) are serialized in full.

```
{
  "MyInt": 5,
  "StandardClass": { "A": 4, "B": 5 }
}
```
The target's StandardClass is entirely overwritten. Any existing fields in the target not listed here are reset to defaults.

### JsonDiffClass (Partial Patch)
Classes marked with `[JsonDiffClass]` serialize only their changed fields. To signal this, the key is prefixed with ^.

```
{
  "^MyDiffClass": { "B": 5 }
}
```
Only property B is updated. Other properties within MyDiffClass remain unchanged.

## Nullable

JsonDiff distinguishes between an unchanged property (omitted) and one that was intentionally set to null.

| State | JSON Representation |
| ---   | --- |
| Unchanged | (Key is omitted) |
| Set to `null`| `"MyProperty": null`|

# Summary Comparison

| JSON Key | Type | Strategy | Target Result |
| --- |
| "User": { ... } | Object | Replace | Overwrites the whole object. Missing fields are lost.
| "^User": { ... }| Object|Patch|Merges fields. Missing fields in JSON are preserved.|
|"User": null|Any|Clear|Sets target property to null.|
| (Omitted)|Any|Ignore|No change to the target.|

In the generated C# code, these properties use the [`JsonNullableChanged<T>`](https://github.com/silentorbit/JsonDiff/blob/master/JsonDiff/JsonDiff.Abstractions/Interfaces/JsonNullableChanged.cs) helper to track the state between "Value not present" and "Value is null."