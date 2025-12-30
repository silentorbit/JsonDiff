using SilentOrbit.JsonDiff.Demo;
using SilentOrbit.JsonDiff.Tools;

namespace SilentOrbit.JsonDiff.Test;

[TestClass]
public sealed class TestFeatures
{
    const string jsonV1 = """
    {
      "MyInt32": 1,
      "MyString": "Hello",
      "MyRevClass": {},
      "MyFullRevClass": {},
      "MySimpleClass": {}
    }
    """;

    const string jsonV2 = """
    {
      "MyInt32": 3,
      "MyInt64": 2,
      "MyString": "Hello",
      "MyDateTimeAlways": "1979-10-11T00:00:00",
      "MyRevClass": {},
      "MyFullRevClass": {},
      "MySimpleClass": {}
    }
    """;

    /// <summary>
    /// <see cref="DemoClass.MyDateTimeAlways"/> default value is not serialized but is applies
    /// </summary>
    const string jsonDiffToV1 = """
    {
      "MyInt32": 1,
      "MyInt64": 0
    }
    """;

    const string jsonDiffToV2 = """
    {
      "MyInt32": 3,
      "MyInt64": 2,
      "MyDateTimeAlways": "1979-10-11T00:00:00"
    }
    """;

    [TestMethod]
    public void BasicUsage()
    {
        //Get original data
        var v1 = new DemoClass { MyInt32 = 1 };
        Json.AssertJSON(v1, jsonV1);

        //Get revision to track changes
        var diffToV1 = v1.CreateReferenceDiff();

        //Apply changes
        var v2 = JsonClone.Clone(v1);
        v2.MyInt64 = 2;
        v2.MyInt32 = 3;
        v2.MyDateTimeAlways = new DateTime(1979, 10, 11);
        Json.AssertJSON(v2, jsonV2);

        //Determine changes
        var unchanged = diffToV1.TrimIsUnchanged(v2);
        Assert.IsFalse(unchanged);
        Json.AssertJSON(diffToV1, jsonDiffToV1);

        //Track reverse
        var diffToV2 = v2.CreateReferenceDiff();

        //Apply changes to get back to the previous version
        var v1_new = diffToV1.ApplyTo(v2);
        Json.AssertJSON(v1_new, jsonV1);

        //Reverse, trim
        diffToV2.TrimIsUnchanged(v1_new);
        Json.AssertJSON(diffToV2, jsonDiffToV2);
    }


    [TestMethod]
    public void RevGenerator()
    {
        //Get original data
        var data = new DemoClass { MyInt32 = 1 };
        Json.AssertJSON(data, jsonV1);

        //Before editing, get revision, safe to add it to the history
        var gen = data.CreateDiffGenerator();

        //Apply changes
        gen.MyInt64 = 2;
        gen.MyInt32 = 3;
        gen.MyDateTimeAlways = new DateTime(1979, 10, 11);
        Json.AssertJSON(data, jsonV2);

        //Determine changes
        var rev = gen.Rev;
        Json.AssertJSON(rev, jsonDiffToV1);
        //rev now has the changes from the new t1 to the old t1

        var v1 = rev.ApplyTo(data);
        Json.AssertJSON(v1, jsonV1);
    }

    /// <summary>
    /// Handle null in non-nullable properties.
    /// </summary>
    [TestMethod]
    public void HandleNull()
    {
        var dataHandled = new TestNullHandled
        {
            MyRevClass = null!,
            MyString = null!,
            MyFullRevClass = null!,
            MySimpleClass = null!,
        };
        var dataUnhandled = new TestNullUnhandled
        {
            MyRevClass = null!,
            MyString = null!,
            MyFullRevClass = null!,
            MySimpleClass = null!,
        };
        Json.AssertJSON(dataHandled, "{}");
        Json.AssertJSON(dataUnhandled, "{}");

        //Get revision to track changes
        var revHandled = dataHandled.CreateReferenceDiff();
        Json.AssertJSON(revHandled, "{}");

        Assert.ThrowsExactly<NullReferenceException>(() =>
        {
            var revUnhandled = dataUnhandled.CreateReferenceDiff();
        });
    }

    /// <summary>
    /// Test generation of property with <see cref="DiffAlwaysAttribute"/>
    /// </summary>
    [TestMethod]
    public void DiffAlways()
    {
        var dt = new DateTime(2000, 1, 2);
        var data = new DemoClass { MyDateTimeAlways = dt };
        var diff = data.CreateReferenceDiff();
        Assert.IsInstanceOfType<DateTime>(diff.MyDateTimeAlways);
        Assert.AreEqual(dt, diff.MyDateTimeAlways);

        var dt2 = new DateTime(2000, 1, 1);
        var gen = data.CreateDiffGenerator();
        gen.MyDateTimeAlways = dt2;
        Assert.AreEqual(dt, gen.Rev.MyDateTimeAlways);
        Assert.AreEqual(dt2, gen.Data.MyDateTimeAlways);
        Assert.AreEqual(dt2, data.MyDateTimeAlways);

        var data2 = gen.Rev.ApplyTo(data);
        Assert.AreEqual(dt, data2.MyDateTimeAlways);
    }
}
