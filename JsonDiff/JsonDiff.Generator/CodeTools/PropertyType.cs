namespace SilentOrbit.JsonDiff.CodeTools;

enum PropertyType
{
    None = 0,

    /// <summary>
    /// Non nullable value type.
    /// </summary>
    Value,

    /// <summary>
    /// Nullable value type
    /// </summary>
    ValueNullable,

    /// <summary>
    /// Full class, not nullable, no subchanges
    /// </summary>
    Class,

    /// <summary>
    /// Full class, nullable, no subchanges
    /// </summary>
    ClassNullable,

    Revision,

    RevisionNullable,

    //TODO: Sub changed in string, OT
}
