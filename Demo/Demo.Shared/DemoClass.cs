using SilentOrbit.JsonDiff.Attributes;
using System.Text.Json.Serialization;

namespace SilentOrbit.JsonDiff.Demo;

[JsonDiffClass(AssertLevel = AssertLevel.None, HandleUnexpectedNull = true)]
public partial class DemoClass
{
    [JsonPropertyName("my")]
    public bool MyPropertyName { get; set; }

    public bool MyBool { get; set; }
    public bool? MyNullBool { get; set; }

    public byte MyByte { get; set; }
    public byte? MyNullByte { get; set; }
    public UInt16 MyUInt16 { get; set; }
    public UInt16? MyNullUInt16 { get; set; }
    public UInt32 MyUInt32 { get; set; }
    public UInt32? MyNullUInt32 { get; set; }
    public UInt64 MyUInt64 { get; set; }
    public UInt64? MyNullUInt64 { get; set; }
    public UInt128 MyUInt128 { get; set; }
    public UInt128? MyNullUInt128 { get; set; }

    public Int16 MyInt16 { get; set; }
    public Int16? MyNullInt16 { get; set; }
    public Int32 MyInt32 { get; set; }
    public Int32? MyNullInt32 { get; set; }
    public Int64 MyInt64 { get; set; }
    public Int64? MyNullInt64 { get; set; }
    public Int128 MyInt128 { get; set; }
    public Int128? MyNullInt128 { get; set; }

    public float MyFloat { get; set; }
    public float? MyNullFloat { get; set; }
    public double MyDouble { get; set; }
    public double? MyNullDouble { get; set; }
    public decimal MyDecimal { get; set; }
    public decimal? MyNullDecimal { get; set; }

    public string MyString { get; set; } = "Hello";
    public string? MyNullString { get; set; }
    //public byte[] BytesValue { get; set; }
    public Guid MyGuid { get; set; }
    public Guid? MyNullGuid { get; set; }

    public DateTime MyDateTime { get; set; }
    public DateTime? MyNullDateTime { get; set; }
    public DateTimeOffset MyDateTimeOffset { get; set; }
    public DateTimeOffset? MyNullDateTimeOffset { get; set; }

    [JsonDiffAlways]
    public DateTime MyDateTimeAlways { get; set; }

    public TestRevClass MyRevClass { get; set; } = new();
    public TestRevClass? MyNullRevClass { get; set; }

    [JsonDiffFull]
    public TestRevClass MyFullRevClass { get; set; } = new();
    [JsonDiffFull]
    public TestRevClass? MyNullFullRevClass { get; set; }

    public TestSimpleClass MySimpleClass { get; set; } = new();
    public TestSimpleClass? MyNullSimpleClass { get; set; }

    /* Not yet supported
    public TestDiffClass.NestedDiffClass NestedDiffClassValue { get; set; } 
    public TestDiffClass.NestedDiffClass? NestedDiffClassNullableValue { get; set; }

    public TestSimpleClass.NestedSimpleClass NestedSimpleClassValue { get; set; }
    public TestSimpleClass.NestedSimpleClass? NestedSimpleClassNullableValue { get; set; }
    */

}

[JsonDiffClass]
public partial class TestRevClass
{
    public int A { get; set; }
    public int? B { get; set; }

    /* Not yet supported
    [DiffRev]
    public partial class NestedDiffClass
    {
        public int A { get; set; }
        public int? B { get; set; }
    }
    */
}

public partial class TestSimpleClass
{
    public int A { get; set; }
    public int? B { get; set; }

    public partial class NestedSimpleClass
    {
        public int A { get; set; }
        public int? B { get; set; }
    }
}

[JsonDiffClass]
public partial class TestNullUnhandled
{
    public string MyString { get; set; } = "Hello";

    public TestRevClass MyRevClass { get; set; } = new();

    [JsonDiffFull]
    public TestRevClass MyFullRevClass { get; set; } = new();

    public TestSimpleClass MySimpleClass { get; set; } = new();
}

[JsonDiffClass(HandleUnexpectedNull = true)]
public partial class TestNullHandled
{
    public string MyString { get; set; } = "Hello";
    
    public TestRevClass MyRevClass { get; set; } = new();
    
    [JsonDiffFull]
    public TestRevClass MyFullRevClass { get; set; } = new();
 
    public TestSimpleClass MySimpleClass { get; set; } = new();
}
