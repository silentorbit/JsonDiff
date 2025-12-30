
# JSON format

The goal is to have the diff in a compact and readable format.

Preferrably default values are not serialized for a compact result.

This describes how properties diff in a class with attribute [`[JsonDiffClass]`](https://github.com/silentorbit/JsonDiff/blob/master/JsonDiff/JsonDiff.Abstractions/Attributes/JsonDiffClassAttribute.cs) are generated.

## Examples

See more detailed examples in [Demo.Shared/Program.cs](https://github.com/silentorbit/JsonDiff/blob/master/Demo/Demo.Shared/Program.cs)

## Unchanged

Unchanged properties are not serialized

```
{}
```

## Modified

Modified values are represented with their new value.
Primitives and unmarked classes will be serialized in full.

Classes with the attribute [`[JsonDiffClass]`](https://github.com/silentorbit/JsonDiff/blob/master/JsonDiff/JsonDiff.Abstractions/Attributes/JsonDiffClassAttribute.cs) will only serialize the changed properties.
These properties are serialized with a special key starting with "^".

[`[JsonDiffClass]`](https://github.com/silentorbit/JsonDiff/blob/master/JsonDiff/JsonDiff.Abstractions/Attributes/JsonDiffClassAttribute.cs) can be overridden in a property with [`[JsonDiffFull]`](https://github.com/silentorbit/JsonDiff/blob/master/JsonDiff/JsonDiff.Abstractions/Attributes/JsonDiffFullAttribute.cs) which will treat it as an unmarked class.

```
{
  "MyInt": 5,
  "MyClass": { A = 4, B = 5 },
  "MyDiffClass": { B = 5 },
}
```

## Nullable

Nullable properties will serialize to the value `null`.
Compared to not serializing at all if unchanged.

```
{
  "MyNullableInt": null,
  "MyNullableClass": null,
  "MyDiffClass": { B = null },
}
```

In code these nullable properties in the Diff class are using the helper class [`JsonNullableChanged<T>`](https://github.com/silentorbit/JsonDiff/blob/master/JsonDiff/JsonDiff.Abstractions/Interfaces/JsonNullableChanged.cs).

