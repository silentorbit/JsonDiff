#nullable enable

using System.CodeDom.Compiler;
using System.Collections.Generic;
using Debug = System.Diagnostics.Debug;
using SilentOrbit.JsonDiff.Interfaces;
using SilentOrbit.JsonDiff.Tools;
using System.Text.Json.Serialization;

namespace SilentOrbit.JsonDiff.Demo;

public partial class DemoClass : IDiffClass<DemoClass,DemoClass.Diff,DemoClass.DiffGenerator>
{
    /// <summary>
    /// Generate Rev on demand
    /// </summary>
    [GeneratedCode("SilentOrbit.JsonDiff", "0.1")]
    public partial class DiffGenerator : DiffGeneratorBase<DemoClass,DemoClass.Diff>
    {
        public static implicit operator DiffGenerator(DemoClass data) => new(data);
        public DiffGenerator(DemoClass data) : base(data)
        {
            Rev.MyDateTimeAlways = data.MyDateTimeAlways;
        }
        public bool MyPropertyName
        {
            get => Data.MyPropertyName;
            set
            {
                // Not changed
                if (Data.MyPropertyName == value)
                    return;
                // Store old value first time modified
                Rev.MyPropertyName ??= Data.MyPropertyName;
                // Store new value
                Data.MyPropertyName = value;
            }
        }
        public bool MyBool
        {
            get => Data.MyBool;
            set
            {
                // Not changed
                if (Data.MyBool == value)
                    return;
                // Store old value first time modified
                Rev.MyBool ??= Data.MyBool;
                // Store new value
                Data.MyBool = value;
            }
        }
        public bool? MyNullBool
        {
            get => Data.MyNullBool;
            set
            {
                // Not changed
                if (Data.MyNullBool == value)
                    return;
                // Store old value first time modified
                Rev.MyNullBool ??= new() { Changed = Data.MyNullBool };
                // Store new value
                Data.MyNullBool = value;
            }
        }
        public byte MyByte
        {
            get => Data.MyByte;
            set
            {
                // Not changed
                if (Data.MyByte == value)
                    return;
                // Store old value first time modified
                Rev.MyByte ??= Data.MyByte;
                // Store new value
                Data.MyByte = value;
            }
        }
        public byte? MyNullByte
        {
            get => Data.MyNullByte;
            set
            {
                // Not changed
                if (Data.MyNullByte == value)
                    return;
                // Store old value first time modified
                Rev.MyNullByte ??= new() { Changed = Data.MyNullByte };
                // Store new value
                Data.MyNullByte = value;
            }
        }
        public ushort MyUInt16
        {
            get => Data.MyUInt16;
            set
            {
                // Not changed
                if (Data.MyUInt16 == value)
                    return;
                // Store old value first time modified
                Rev.MyUInt16 ??= Data.MyUInt16;
                // Store new value
                Data.MyUInt16 = value;
            }
        }
        public ushort? MyNullUInt16
        {
            get => Data.MyNullUInt16;
            set
            {
                // Not changed
                if (Data.MyNullUInt16 == value)
                    return;
                // Store old value first time modified
                Rev.MyNullUInt16 ??= new() { Changed = Data.MyNullUInt16 };
                // Store new value
                Data.MyNullUInt16 = value;
            }
        }
        public uint MyUInt32
        {
            get => Data.MyUInt32;
            set
            {
                // Not changed
                if (Data.MyUInt32 == value)
                    return;
                // Store old value first time modified
                Rev.MyUInt32 ??= Data.MyUInt32;
                // Store new value
                Data.MyUInt32 = value;
            }
        }
        public uint? MyNullUInt32
        {
            get => Data.MyNullUInt32;
            set
            {
                // Not changed
                if (Data.MyNullUInt32 == value)
                    return;
                // Store old value first time modified
                Rev.MyNullUInt32 ??= new() { Changed = Data.MyNullUInt32 };
                // Store new value
                Data.MyNullUInt32 = value;
            }
        }
        public ulong MyUInt64
        {
            get => Data.MyUInt64;
            set
            {
                // Not changed
                if (Data.MyUInt64 == value)
                    return;
                // Store old value first time modified
                Rev.MyUInt64 ??= Data.MyUInt64;
                // Store new value
                Data.MyUInt64 = value;
            }
        }
        public ulong? MyNullUInt64
        {
            get => Data.MyNullUInt64;
            set
            {
                // Not changed
                if (Data.MyNullUInt64 == value)
                    return;
                // Store old value first time modified
                Rev.MyNullUInt64 ??= new() { Changed = Data.MyNullUInt64 };
                // Store new value
                Data.MyNullUInt64 = value;
            }
        }
        public UInt128 MyUInt128
        {
            get => Data.MyUInt128;
            set
            {
                // Not changed
                if (Data.MyUInt128 == value)
                    return;
                // Store old value first time modified
                Rev.MyUInt128 ??= Data.MyUInt128;
                // Store new value
                Data.MyUInt128 = value;
            }
        }
        public UInt128? MyNullUInt128
        {
            get => Data.MyNullUInt128;
            set
            {
                // Not changed
                if (Data.MyNullUInt128 == value)
                    return;
                // Store old value first time modified
                Rev.MyNullUInt128 ??= new() { Changed = Data.MyNullUInt128 };
                // Store new value
                Data.MyNullUInt128 = value;
            }
        }
        public short MyInt16
        {
            get => Data.MyInt16;
            set
            {
                // Not changed
                if (Data.MyInt16 == value)
                    return;
                // Store old value first time modified
                Rev.MyInt16 ??= Data.MyInt16;
                // Store new value
                Data.MyInt16 = value;
            }
        }
        public short? MyNullInt16
        {
            get => Data.MyNullInt16;
            set
            {
                // Not changed
                if (Data.MyNullInt16 == value)
                    return;
                // Store old value first time modified
                Rev.MyNullInt16 ??= new() { Changed = Data.MyNullInt16 };
                // Store new value
                Data.MyNullInt16 = value;
            }
        }
        public int MyInt32
        {
            get => Data.MyInt32;
            set
            {
                // Not changed
                if (Data.MyInt32 == value)
                    return;
                // Store old value first time modified
                Rev.MyInt32 ??= Data.MyInt32;
                // Store new value
                Data.MyInt32 = value;
            }
        }
        public int? MyNullInt32
        {
            get => Data.MyNullInt32;
            set
            {
                // Not changed
                if (Data.MyNullInt32 == value)
                    return;
                // Store old value first time modified
                Rev.MyNullInt32 ??= new() { Changed = Data.MyNullInt32 };
                // Store new value
                Data.MyNullInt32 = value;
            }
        }
        public long MyInt64
        {
            get => Data.MyInt64;
            set
            {
                // Not changed
                if (Data.MyInt64 == value)
                    return;
                // Store old value first time modified
                Rev.MyInt64 ??= Data.MyInt64;
                // Store new value
                Data.MyInt64 = value;
            }
        }
        public long? MyNullInt64
        {
            get => Data.MyNullInt64;
            set
            {
                // Not changed
                if (Data.MyNullInt64 == value)
                    return;
                // Store old value first time modified
                Rev.MyNullInt64 ??= new() { Changed = Data.MyNullInt64 };
                // Store new value
                Data.MyNullInt64 = value;
            }
        }
        public Int128 MyInt128
        {
            get => Data.MyInt128;
            set
            {
                // Not changed
                if (Data.MyInt128 == value)
                    return;
                // Store old value first time modified
                Rev.MyInt128 ??= Data.MyInt128;
                // Store new value
                Data.MyInt128 = value;
            }
        }
        public Int128? MyNullInt128
        {
            get => Data.MyNullInt128;
            set
            {
                // Not changed
                if (Data.MyNullInt128 == value)
                    return;
                // Store old value first time modified
                Rev.MyNullInt128 ??= new() { Changed = Data.MyNullInt128 };
                // Store new value
                Data.MyNullInt128 = value;
            }
        }
        public float MyFloat
        {
            get => Data.MyFloat;
            set
            {
                // Not changed
                if (Data.MyFloat == value)
                    return;
                // Store old value first time modified
                Rev.MyFloat ??= Data.MyFloat;
                // Store new value
                Data.MyFloat = value;
            }
        }
        public float? MyNullFloat
        {
            get => Data.MyNullFloat;
            set
            {
                // Not changed
                if (Data.MyNullFloat == value)
                    return;
                // Store old value first time modified
                Rev.MyNullFloat ??= new() { Changed = Data.MyNullFloat };
                // Store new value
                Data.MyNullFloat = value;
            }
        }
        public double MyDouble
        {
            get => Data.MyDouble;
            set
            {
                // Not changed
                if (Data.MyDouble == value)
                    return;
                // Store old value first time modified
                Rev.MyDouble ??= Data.MyDouble;
                // Store new value
                Data.MyDouble = value;
            }
        }
        public double? MyNullDouble
        {
            get => Data.MyNullDouble;
            set
            {
                // Not changed
                if (Data.MyNullDouble == value)
                    return;
                // Store old value first time modified
                Rev.MyNullDouble ??= new() { Changed = Data.MyNullDouble };
                // Store new value
                Data.MyNullDouble = value;
            }
        }
        public decimal MyDecimal
        {
            get => Data.MyDecimal;
            set
            {
                // Not changed
                if (Data.MyDecimal == value)
                    return;
                // Store old value first time modified
                Rev.MyDecimal ??= Data.MyDecimal;
                // Store new value
                Data.MyDecimal = value;
            }
        }
        public decimal? MyNullDecimal
        {
            get => Data.MyNullDecimal;
            set
            {
                // Not changed
                if (Data.MyNullDecimal == value)
                    return;
                // Store old value first time modified
                Rev.MyNullDecimal ??= new() { Changed = Data.MyNullDecimal };
                // Store new value
                Data.MyNullDecimal = value;
            }
        }
        public string MyString
        {
            get => Data.MyString;
            set
            {
                // Not changed
                if (Data.MyString == value)
                    return;
                // Store old value first time modified
                Rev.MyString ??= Data.MyString;
                // Store new value
                Data.MyString = value;
            }
        }
        public string? MyNullString
        {
            get => Data.MyNullString;
            set
            {
                // Not changed
                if (Data.MyNullString == value)
                    return;
                // Store old value first time modified
                Rev.MyNullString ??= new() { Changed = Data.MyNullString };
                // Store new value
                Data.MyNullString = value;
            }
        }
        public Guid MyGuid
        {
            get => Data.MyGuid;
            set
            {
                // Not changed
                if (Data.MyGuid == value)
                    return;
                // Store old value first time modified
                Rev.MyGuid ??= Data.MyGuid;
                // Store new value
                Data.MyGuid = value;
            }
        }
        public Guid? MyNullGuid
        {
            get => Data.MyNullGuid;
            set
            {
                // Not changed
                if (Data.MyNullGuid == value)
                    return;
                // Store old value first time modified
                Rev.MyNullGuid ??= new() { Changed = Data.MyNullGuid };
                // Store new value
                Data.MyNullGuid = value;
            }
        }
        public DateTime MyDateTime
        {
            get => Data.MyDateTime;
            set
            {
                // Not changed
                if (Data.MyDateTime == value)
                    return;
                // Store old value first time modified
                Rev.MyDateTime ??= Data.MyDateTime;
                // Store new value
                Data.MyDateTime = value;
            }
        }
        public DateTime? MyNullDateTime
        {
            get => Data.MyNullDateTime;
            set
            {
                // Not changed
                if (Data.MyNullDateTime == value)
                    return;
                // Store old value first time modified
                Rev.MyNullDateTime ??= new() { Changed = Data.MyNullDateTime };
                // Store new value
                Data.MyNullDateTime = value;
            }
        }
        public DateTimeOffset MyDateTimeOffset
        {
            get => Data.MyDateTimeOffset;
            set
            {
                // Not changed
                if (Data.MyDateTimeOffset == value)
                    return;
                // Store old value first time modified
                Rev.MyDateTimeOffset ??= Data.MyDateTimeOffset;
                // Store new value
                Data.MyDateTimeOffset = value;
            }
        }
        public DateTimeOffset? MyNullDateTimeOffset
        {
            get => Data.MyNullDateTimeOffset;
            set
            {
                // Not changed
                if (Data.MyNullDateTimeOffset == value)
                    return;
                // Store old value first time modified
                Rev.MyNullDateTimeOffset ??= new() { Changed = Data.MyNullDateTimeOffset };
                // Store new value
                Data.MyNullDateTimeOffset = value;
            }
        }
        public DateTime MyDateTimeAlways
        {
            get => Data.MyDateTimeAlways;
            set => Data.MyDateTimeAlways = value;
        }
        public SilentOrbit.JsonDiff.Demo.TestRevClass.DiffGenerator MyRevClass
        {
            get
            {
                // Existing generator
                if (field != null)
                    return field;
                // Create a generator
                field = new(Data.MyRevClass);
                Rev.MyRevClass_Diff = field.Rev;
                return field;
            }
            /// <summary>
            /// Assume the generator is from implicit cast
            /// </summary>
            set
            {
                // Same generator
                if (field == value)
                    return;
                throw new NotImplementedException();
            }
        }
        public SilentOrbit.JsonDiff.Demo.TestRevClass.DiffGenerator? MyNullRevClass
        {
            get
            {
                // Null value => null generator
                if (Data.MyNullRevClass == null)
                    return null;
                // Existing generator
                if (field != null)
                    return field;
                // Create a generator
                field = new(Data.MyNullRevClass);
                Rev.MyNullRevClass_Diff = field.Rev;
                return field;
            }
            /// <summary>
            /// Assume the generator is from implicit cast
            /// </summary>
            set
            {
                // Same generator
                if (field == value)
                    return;
                if (field != null)
                    throw new NotImplementedException("Generator already created");
                if (value == null)
                {
                    if (Data.MyNullRevClass == null)
                        return;
                    throw new NotImplementedException();
                }
                else
                {
                    throw new NotImplementedException();
                }
                throw new NotImplementedException();
            }
        }
        public TestRevClass MyFullRevClass
        {
            get
            {
                // Store old value first time accessed
                Rev.MyFullRevClass ??= JsonClone.Clone(Data.MyFullRevClass);
                // Store new value
                return Data.MyFullRevClass;
            }
            set
            {
                // Not changed
                if (Data.MyFullRevClass == value)
                    return;
                // Store old value first time modified
                Rev.MyFullRevClass ??= JsonClone.Clone(Data.MyFullRevClass);
                // Store new value
                Data.MyFullRevClass = value;
            }
        }
        public TestRevClass? MyNullFullRevClass
        {
            get
            {
                // Store old value first time accessed
                Rev.MyNullFullRevClass ??= new() { Changed = JsonClone.Clone(Data.MyNullFullRevClass) };
                return Data.MyNullFullRevClass;
            }
            set
            {
                // Not changed
                if (Data.MyNullFullRevClass == value)
                    return;
                // Store old value first time modified
                Rev.MyNullFullRevClass ??= new() { Changed = JsonClone.Clone(Data.MyNullFullRevClass) };
                // Store new value
                Data.MyNullFullRevClass = value;
            }
        }
        public TestSimpleClass MySimpleClass
        {
            get
            {
                // Store old value first time accessed
                Rev.MySimpleClass ??= JsonClone.Clone(Data.MySimpleClass);
                // Store new value
                return Data.MySimpleClass;
            }
            set
            {
                // Not changed
                if (Data.MySimpleClass == value)
                    return;
                // Store old value first time modified
                Rev.MySimpleClass ??= JsonClone.Clone(Data.MySimpleClass);
                // Store new value
                Data.MySimpleClass = value;
            }
        }
        public TestSimpleClass? MyNullSimpleClass
        {
            get
            {
                // Store old value first time accessed
                Rev.MyNullSimpleClass ??= new() { Changed = JsonClone.Clone(Data.MyNullSimpleClass) };
                return Data.MyNullSimpleClass;
            }
            set
            {
                // Not changed
                if (Data.MyNullSimpleClass == value)
                    return;
                // Store old value first time modified
                Rev.MyNullSimpleClass ??= new() { Changed = JsonClone.Clone(Data.MyNullSimpleClass) };
                // Store new value
                Data.MyNullSimpleClass = value;
            }
        }
    }
}
