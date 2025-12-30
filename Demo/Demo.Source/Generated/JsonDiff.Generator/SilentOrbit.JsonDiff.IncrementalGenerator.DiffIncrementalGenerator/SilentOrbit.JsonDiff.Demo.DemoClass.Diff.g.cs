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
    [GeneratedCode("SilentOrbit.JsonDiff", "0.1")]
    public partial class Diff : IDiff<DemoClass>
    {
        #region Change Properties

        /// <summary>
        /// <see cref="DemoClass.MyPropertyName"/>
        /// </summary>
        [JsonPropertyName("my")]
        public bool? MyPropertyName { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyBool"/>
        /// </summary>
        public bool? MyBool { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyNullBool"/>
        /// </summary>
        [JsonConverter(typeof(JsonNullableChangedConverter<bool?>))]
        public JsonNullableChanged<bool?>? MyNullBool { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyByte"/>
        /// </summary>
        public byte? MyByte { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyNullByte"/>
        /// </summary>
        [JsonConverter(typeof(JsonNullableChangedConverter<byte?>))]
        public JsonNullableChanged<byte?>? MyNullByte { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyUInt16"/>
        /// </summary>
        public ushort? MyUInt16 { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyNullUInt16"/>
        /// </summary>
        [JsonConverter(typeof(JsonNullableChangedConverter<ushort?>))]
        public JsonNullableChanged<ushort?>? MyNullUInt16 { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyUInt32"/>
        /// </summary>
        public uint? MyUInt32 { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyNullUInt32"/>
        /// </summary>
        [JsonConverter(typeof(JsonNullableChangedConverter<uint?>))]
        public JsonNullableChanged<uint?>? MyNullUInt32 { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyUInt64"/>
        /// </summary>
        public ulong? MyUInt64 { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyNullUInt64"/>
        /// </summary>
        [JsonConverter(typeof(JsonNullableChangedConverter<ulong?>))]
        public JsonNullableChanged<ulong?>? MyNullUInt64 { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyUInt128"/>
        /// </summary>
        public UInt128? MyUInt128 { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyNullUInt128"/>
        /// </summary>
        [JsonConverter(typeof(JsonNullableChangedConverter<UInt128?>))]
        public JsonNullableChanged<UInt128?>? MyNullUInt128 { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyInt16"/>
        /// </summary>
        public short? MyInt16 { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyNullInt16"/>
        /// </summary>
        [JsonConverter(typeof(JsonNullableChangedConverter<short?>))]
        public JsonNullableChanged<short?>? MyNullInt16 { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyInt32"/>
        /// </summary>
        public int? MyInt32 { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyNullInt32"/>
        /// </summary>
        [JsonConverter(typeof(JsonNullableChangedConverter<int?>))]
        public JsonNullableChanged<int?>? MyNullInt32 { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyInt64"/>
        /// </summary>
        public long? MyInt64 { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyNullInt64"/>
        /// </summary>
        [JsonConverter(typeof(JsonNullableChangedConverter<long?>))]
        public JsonNullableChanged<long?>? MyNullInt64 { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyInt128"/>
        /// </summary>
        public Int128? MyInt128 { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyNullInt128"/>
        /// </summary>
        [JsonConverter(typeof(JsonNullableChangedConverter<Int128?>))]
        public JsonNullableChanged<Int128?>? MyNullInt128 { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyFloat"/>
        /// </summary>
        public float? MyFloat { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyNullFloat"/>
        /// </summary>
        [JsonConverter(typeof(JsonNullableChangedConverter<float?>))]
        public JsonNullableChanged<float?>? MyNullFloat { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyDouble"/>
        /// </summary>
        public double? MyDouble { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyNullDouble"/>
        /// </summary>
        [JsonConverter(typeof(JsonNullableChangedConverter<double?>))]
        public JsonNullableChanged<double?>? MyNullDouble { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyDecimal"/>
        /// </summary>
        public decimal? MyDecimal { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyNullDecimal"/>
        /// </summary>
        [JsonConverter(typeof(JsonNullableChangedConverter<decimal?>))]
        public JsonNullableChanged<decimal?>? MyNullDecimal { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyString"/>
        /// </summary>
        public string? MyString { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyNullString"/>
        /// </summary>
        [JsonConverter(typeof(JsonNullableChangedConverter<string?>))]
        public JsonNullableChanged<string?>? MyNullString { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyGuid"/>
        /// </summary>
        public Guid? MyGuid { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyNullGuid"/>
        /// </summary>
        [JsonConverter(typeof(JsonNullableChangedConverter<Guid?>))]
        public JsonNullableChanged<Guid?>? MyNullGuid { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyDateTime"/>
        /// </summary>
        public DateTime? MyDateTime { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyNullDateTime"/>
        /// </summary>
        [JsonConverter(typeof(JsonNullableChangedConverter<DateTime?>))]
        public JsonNullableChanged<DateTime?>? MyNullDateTime { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyDateTimeOffset"/>
        /// </summary>
        public DateTimeOffset? MyDateTimeOffset { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyNullDateTimeOffset"/>
        /// </summary>
        [JsonConverter(typeof(JsonNullableChangedConverter<DateTimeOffset?>))]
        public JsonNullableChanged<DateTimeOffset?>? MyNullDateTimeOffset { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyDateTimeAlways"/>
        /// </summary>
        public DateTime MyDateTimeAlways { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyRevClass"/>
        /// </summary>
        public SilentOrbit.JsonDiff.Demo.TestRevClass? MyRevClass { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyNullRevClass"/>
        /// </summary>
        [JsonConverter(typeof(JsonNullableChangedConverter<TestRevClass?>))]
        public JsonNullableChanged<SilentOrbit.JsonDiff.Demo.TestRevClass?>? MyNullRevClass { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyFullRevClass"/>
        /// </summary>
        public SilentOrbit.JsonDiff.Demo.TestRevClass? MyFullRevClass { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyNullFullRevClass"/>
        /// </summary>
        [JsonConverter(typeof(JsonNullableChangedConverter<TestRevClass?>))]
        public JsonNullableChanged<SilentOrbit.JsonDiff.Demo.TestRevClass?>? MyNullFullRevClass { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MySimpleClass"/>
        /// </summary>
        public SilentOrbit.JsonDiff.Demo.TestSimpleClass? MySimpleClass { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyNullSimpleClass"/>
        /// </summary>
        [JsonConverter(typeof(JsonNullableChangedConverter<TestSimpleClass?>))]
        public JsonNullableChanged<SilentOrbit.JsonDiff.Demo.TestSimpleClass?>? MyNullSimpleClass { get; set; }

        #endregion Change Properties


        #region Diff Properties "^..."

        /// <summary>
        /// <see cref="DemoClass.MyRevClass"/>
        /// </summary>
        [JsonPropertyName("^MyRevClass")]
        public SilentOrbit.JsonDiff.Demo.TestRevClass.Diff? MyRevClass_Diff { get; set; }

        /// <summary>
        /// <see cref="DemoClass.MyNullRevClass"/>
        /// </summary>
        [JsonPropertyName("^MyNullRevClass")]
        public SilentOrbit.JsonDiff.Demo.TestRevClass.Diff? MyNullRevClass_Diff { get; set; }

        #endregion Diff Properties "^..."


        /// <summary>
        /// For deserialization
        /// </summary>
        public Diff() { }

        /// <summary>
        /// Create a reference before editing main instance
        /// </summary>
        public Diff(DemoClass data)
        {
            MyPropertyName = data.MyPropertyName;
            MyBool = data.MyBool;
            MyNullBool = new() { Changed = data.MyNullBool };
            MyByte = data.MyByte;
            MyNullByte = new() { Changed = data.MyNullByte };
            MyUInt16 = data.MyUInt16;
            MyNullUInt16 = new() { Changed = data.MyNullUInt16 };
            MyUInt32 = data.MyUInt32;
            MyNullUInt32 = new() { Changed = data.MyNullUInt32 };
            MyUInt64 = data.MyUInt64;
            MyNullUInt64 = new() { Changed = data.MyNullUInt64 };
            MyUInt128 = data.MyUInt128;
            MyNullUInt128 = new() { Changed = data.MyNullUInt128 };
            MyInt16 = data.MyInt16;
            MyNullInt16 = new() { Changed = data.MyNullInt16 };
            MyInt32 = data.MyInt32;
            MyNullInt32 = new() { Changed = data.MyNullInt32 };
            MyInt64 = data.MyInt64;
            MyNullInt64 = new() { Changed = data.MyNullInt64 };
            MyInt128 = data.MyInt128;
            MyNullInt128 = new() { Changed = data.MyNullInt128 };
            MyFloat = data.MyFloat;
            MyNullFloat = new() { Changed = data.MyNullFloat };
            MyDouble = data.MyDouble;
            MyNullDouble = new() { Changed = data.MyNullDouble };
            MyDecimal = data.MyDecimal;
            MyNullDecimal = new() { Changed = data.MyNullDecimal };
            MyString = data.MyString;
            MyNullString = new() { Changed = data.MyNullString };
            MyGuid = data.MyGuid;
            MyNullGuid = new() { Changed = data.MyNullGuid };
            MyDateTime = data.MyDateTime;
            MyNullDateTime = new() { Changed = data.MyNullDateTime };
            MyDateTimeOffset = data.MyDateTimeOffset;
            MyNullDateTimeOffset = new() { Changed = data.MyNullDateTimeOffset };
            MyDateTimeAlways = data.MyDateTimeAlways;
            if (data.MyRevClass == null)
                MyRevClass = null;
            else
                MyRevClass_Diff = new(data.MyRevClass);
            if (data.MyNullRevClass == null)
                MyNullRevClass = new() { Changed = null };
            else
                MyNullRevClass_Diff = new(data.MyNullRevClass);
            MyFullRevClass = JsonClone.Clone(data.MyFullRevClass);
            MyNullFullRevClass = new() { Changed = JsonClone.Clone(data.MyNullFullRevClass) };
            MySimpleClass = JsonClone.Clone(data.MySimpleClass);
            MyNullSimpleClass = new() { Changed = JsonClone.Clone(data.MyNullSimpleClass) };
        }

        /// <summary>
        /// Remove all properties matching in data.
        /// Return true if ALL properties were trimmed
        /// </summary>
        public bool TrimIsUnchanged(DemoClass data)
        {
            var remaining = 41;
            if (MyPropertyName == data.MyPropertyName)
            {
                MyPropertyName = null;
                remaining--;
            }
            if (MyBool == data.MyBool)
            {
                MyBool = null;
                remaining--;
            }
            if (MyNullBool!.Changed == data.MyNullBool)
            {
                MyNullBool = null;
                remaining--;
            }
            if (MyByte == data.MyByte)
            {
                MyByte = null;
                remaining--;
            }
            if (MyNullByte!.Changed == data.MyNullByte)
            {
                MyNullByte = null;
                remaining--;
            }
            if (MyUInt16 == data.MyUInt16)
            {
                MyUInt16 = null;
                remaining--;
            }
            if (MyNullUInt16!.Changed == data.MyNullUInt16)
            {
                MyNullUInt16 = null;
                remaining--;
            }
            if (MyUInt32 == data.MyUInt32)
            {
                MyUInt32 = null;
                remaining--;
            }
            if (MyNullUInt32!.Changed == data.MyNullUInt32)
            {
                MyNullUInt32 = null;
                remaining--;
            }
            if (MyUInt64 == data.MyUInt64)
            {
                MyUInt64 = null;
                remaining--;
            }
            if (MyNullUInt64!.Changed == data.MyNullUInt64)
            {
                MyNullUInt64 = null;
                remaining--;
            }
            if (MyUInt128 == data.MyUInt128)
            {
                MyUInt128 = null;
                remaining--;
            }
            if (MyNullUInt128!.Changed == data.MyNullUInt128)
            {
                MyNullUInt128 = null;
                remaining--;
            }
            if (MyInt16 == data.MyInt16)
            {
                MyInt16 = null;
                remaining--;
            }
            if (MyNullInt16!.Changed == data.MyNullInt16)
            {
                MyNullInt16 = null;
                remaining--;
            }
            if (MyInt32 == data.MyInt32)
            {
                MyInt32 = null;
                remaining--;
            }
            if (MyNullInt32!.Changed == data.MyNullInt32)
            {
                MyNullInt32 = null;
                remaining--;
            }
            if (MyInt64 == data.MyInt64)
            {
                MyInt64 = null;
                remaining--;
            }
            if (MyNullInt64!.Changed == data.MyNullInt64)
            {
                MyNullInt64 = null;
                remaining--;
            }
            if (MyInt128 == data.MyInt128)
            {
                MyInt128 = null;
                remaining--;
            }
            if (MyNullInt128!.Changed == data.MyNullInt128)
            {
                MyNullInt128 = null;
                remaining--;
            }
            if (MyFloat == data.MyFloat)
            {
                MyFloat = null;
                remaining--;
            }
            if (MyNullFloat!.Changed == data.MyNullFloat)
            {
                MyNullFloat = null;
                remaining--;
            }
            if (MyDouble == data.MyDouble)
            {
                MyDouble = null;
                remaining--;
            }
            if (MyNullDouble!.Changed == data.MyNullDouble)
            {
                MyNullDouble = null;
                remaining--;
            }
            if (MyDecimal == data.MyDecimal)
            {
                MyDecimal = null;
                remaining--;
            }
            if (MyNullDecimal!.Changed == data.MyNullDecimal)
            {
                MyNullDecimal = null;
                remaining--;
            }
            if (MyString == data.MyString)
            {
                MyString = null;
                remaining--;
            }
            if (MyNullString!.Changed == data.MyNullString)
            {
                MyNullString = null;
                remaining--;
            }
            if (MyGuid == data.MyGuid)
            {
                MyGuid = null;
                remaining--;
            }
            if (MyNullGuid!.Changed == data.MyNullGuid)
            {
                MyNullGuid = null;
                remaining--;
            }
            if (MyDateTime == data.MyDateTime)
            {
                MyDateTime = null;
                remaining--;
            }
            if (MyNullDateTime!.Changed == data.MyNullDateTime)
            {
                MyNullDateTime = null;
                remaining--;
            }
            if (MyDateTimeOffset == data.MyDateTimeOffset)
            {
                MyDateTimeOffset = null;
                remaining--;
            }
            if (MyNullDateTimeOffset!.Changed == data.MyNullDateTimeOffset)
            {
                MyNullDateTimeOffset = null;
                remaining--;
            }
            if (MyRevClass_Diff!.TrimIsUnchanged(data.MyRevClass))
            {
                MyRevClass = null;
                MyRevClass_Diff = null;
                remaining--;
            }
            if (MyNullRevClass != null)
            {
                // Changed: null
                if (data.MyNullRevClass == null)
                {
                    MyNullRevClass = null;
                    remaining--;
                }
            }
            else
            {
                // Revision
                if (data.MyNullRevClass == null || MyNullRevClass_Diff!.TrimIsUnchanged(data.MyNullRevClass))
                {
                    MyNullRevClass_Diff = null;
                    remaining--;
                }
            }
            if (JsonClone.Compare(MyFullRevClass, data.MyFullRevClass))
            {
                MyFullRevClass = null;
                remaining--;
            }
            if (JsonClone.Compare(MyNullFullRevClass!.Changed, data.MyNullFullRevClass))
            {
                MyNullFullRevClass = null;
                remaining--;
            }
            if (JsonClone.Compare(MySimpleClass, data.MySimpleClass))
            {
                MySimpleClass = null;
                remaining--;
            }
            if (JsonClone.Compare(MyNullSimpleClass!.Changed, data.MyNullSimpleClass))
            {
                MyNullSimpleClass = null;
                remaining--;
            }
            return remaining <= 0;
        }

        /// <summary>
        /// Apply changes to full instance
        /// </summary>
        public DemoClass ApplyTo(DemoClass? from)
        {
            var to = JsonClone.Clone(from) ?? new();
            if (MyPropertyName != null)
                to.MyPropertyName = MyPropertyName.Value;
            if (MyBool != null)
                to.MyBool = MyBool.Value;
            if (MyNullBool != null)
                to.MyNullBool = MyNullBool.Changed;
            if (MyByte != null)
                to.MyByte = MyByte.Value;
            if (MyNullByte != null)
                to.MyNullByte = MyNullByte.Changed;
            if (MyUInt16 != null)
                to.MyUInt16 = MyUInt16.Value;
            if (MyNullUInt16 != null)
                to.MyNullUInt16 = MyNullUInt16.Changed;
            if (MyUInt32 != null)
                to.MyUInt32 = MyUInt32.Value;
            if (MyNullUInt32 != null)
                to.MyNullUInt32 = MyNullUInt32.Changed;
            if (MyUInt64 != null)
                to.MyUInt64 = MyUInt64.Value;
            if (MyNullUInt64 != null)
                to.MyNullUInt64 = MyNullUInt64.Changed;
            if (MyUInt128 != null)
                to.MyUInt128 = MyUInt128.Value;
            if (MyNullUInt128 != null)
                to.MyNullUInt128 = MyNullUInt128.Changed;
            if (MyInt16 != null)
                to.MyInt16 = MyInt16.Value;
            if (MyNullInt16 != null)
                to.MyNullInt16 = MyNullInt16.Changed;
            if (MyInt32 != null)
                to.MyInt32 = MyInt32.Value;
            if (MyNullInt32 != null)
                to.MyNullInt32 = MyNullInt32.Changed;
            if (MyInt64 != null)
                to.MyInt64 = MyInt64.Value;
            if (MyNullInt64 != null)
                to.MyNullInt64 = MyNullInt64.Changed;
            if (MyInt128 != null)
                to.MyInt128 = MyInt128.Value;
            if (MyNullInt128 != null)
                to.MyNullInt128 = MyNullInt128.Changed;
            if (MyFloat != null)
                to.MyFloat = MyFloat.Value;
            if (MyNullFloat != null)
                to.MyNullFloat = MyNullFloat.Changed;
            if (MyDouble != null)
                to.MyDouble = MyDouble.Value;
            if (MyNullDouble != null)
                to.MyNullDouble = MyNullDouble.Changed;
            if (MyDecimal != null)
                to.MyDecimal = MyDecimal.Value;
            if (MyNullDecimal != null)
                to.MyNullDecimal = MyNullDecimal.Changed;
            if (MyString != null)
                to.MyString = MyString;
            if (MyNullString != null)
                to.MyNullString = MyNullString.Changed;
            if (MyGuid != null)
                to.MyGuid = MyGuid.Value;
            if (MyNullGuid != null)
                to.MyNullGuid = MyNullGuid.Changed;
            if (MyDateTime != null)
                to.MyDateTime = MyDateTime.Value;
            if (MyNullDateTime != null)
                to.MyNullDateTime = MyNullDateTime.Changed;
            if (MyDateTimeOffset != null)
                to.MyDateTimeOffset = MyDateTimeOffset.Value;
            if (MyNullDateTimeOffset != null)
                to.MyNullDateTimeOffset = MyNullDateTimeOffset.Changed;
            to.MyDateTimeAlways = MyDateTimeAlways;
            if (MyRevClass != null)
                to.MyRevClass = JsonClone.Clone(MyRevClass);
            if (MyRevClass_Diff != null)
                to.MyRevClass = MyRevClass_Diff.ApplyTo(to.MyRevClass);
            if (MyNullRevClass != null)
                to.MyNullRevClass = JsonClone.Clone(MyNullRevClass.Changed);
            if (MyNullRevClass_Diff != null)
                to.MyNullRevClass = MyNullRevClass_Diff.ApplyTo(to.MyNullRevClass);
            if (MyFullRevClass != null)
                to.MyFullRevClass = JsonClone.Clone(MyFullRevClass);
            if (MyNullFullRevClass != null)
                to.MyNullFullRevClass = JsonClone.Clone(MyNullFullRevClass.Changed);
            if (MySimpleClass != null)
                to.MySimpleClass = JsonClone.Clone(MySimpleClass);
            if (MyNullSimpleClass != null)
                to.MyNullSimpleClass = JsonClone.Clone(MyNullSimpleClass.Changed);
            return to;
        }
    }
}
