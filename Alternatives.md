
# Comparing to other formats

Comparing patch format with other.

- JSON Patch ([RFC 6902](https://datatracker.ietf.org/doc/html/rfc6902))
- JSON Merge Patch ([(RFC 7386)](https://datatracker.ietf.org/doc/html/rfc7386))
- JSON Diff [SilentOrbit.JsonDiff](https://github.com/silentorbit/JsonDiff)

# Replace

## JSON Patch

```
[
  { "op": "replace", "path": "/baz", "value": "boo" },
]
```

## JSON Merge Patch

```
{ "baz": "boo" }
```

## JSON Diff

```
{ "baz": "boo" }
```


