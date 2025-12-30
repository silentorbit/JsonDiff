using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SilentOrbit.JsonDiff.Demo;

using static SilentOrbit.JsonDiff.Demo.Helpers;

/// <summary>
/// This project uses the JsonDiff from source by referencing the generator project.
/// Best for development of the JsonDiff project.
/// </summary>
class Program
{
    public static void Main()
    {
        DetectChanges();
        CompareInstances();
        JsonFormat();
        Console.WriteLine("Demo Completed");
    }

    /// <summary>
    /// Detect what was modified in an instance.
    /// </summary>
    static void DetectChanges()
    {
        //Start with a class
        var demo = new DemoClass { MyInt32 = 123 };
        JsonAssert(demo, """
            {
              "MyInt32": 123,
              "MyString": "Hello",
              "MyRevClass": {},
              "MyFullRevClass": {},
              "MySimpleClass": {}
            }
            """);

        //Get a reference for later comparison
        var diff = demo.CreateReferenceDiff();

        //Modify the class
        demo.MyInt32 = 321;
        demo.MyInt64 = 1;
        JsonAssert(demo, """
            {
              "MyInt32": 321,
              "MyInt64": 1,
              "MyString": "Hello",
              "MyRevClass": {},
              "MyFullRevClass": {},
              "MySimpleClass": {}
            }
            """);

        //Get backwards diff: from new to original
        diff.TrimIsUnchanged(demo);
        JsonAssert(diff, """
            {
              "MyInt32": 123,
              "MyInt64": 0
            }
            """);

        //Use diff to get back original demo
        var original = diff.ApplyTo(demo);
        JsonAssert(original, """
            {
              "MyInt32": 123,
              "MyString": "Hello",
              "MyRevClass": {},
              "MyFullRevClass": {},
              "MySimpleClass": {}
            }
            """);

        //Get Forwards diff, from original to new
        diff = demo.CreateReferenceDiff();
        diff.TrimIsUnchanged(original);
        JsonAssert(diff, """
            {
              "MyInt32": 321,
              "MyInt64": 1
            }
            """);
    }

    /// <summary>
    /// Compare two existing instances.
    /// </summary>
    static void CompareInstances()
    {
        //Start with two instances
        var a = JsonSerializer.Deserialize<DemoClass>("""
            {
              "MyInt32": 123,
              "MyString": "Hello",
              "MyRevClass": {},
              "MyFullRevClass": {},
              "MySimpleClass": {}
            }
            """)!;
        var b = JsonSerializer.Deserialize<DemoClass>("""
            {
              "MyInt32": 321,
              "MyInt64": 1,
              "MyString": "Hello",
              "MyRevClass": {},
              "MyFullRevClass": {},
              "MySimpleClass": {}
            }
            """)!;

        //Compare changes from a to b
        var diff = b.CreateReferenceDiff();
        diff.TrimIsUnchanged(a);
        JsonAssert(diff, """
            {
              "MyInt32": 321,
              "MyInt64": 1
            }
            """);
    }

    static void JsonFormat()
    {
        //All examples start with this.
        var start = new DemoClass
        {
            //int
            MyInt32 = 4,
            //int?
            MyNullInt32 = 4,
            // [JsonDiffFullClone] and [JsonDiffClass] class MyNullSimpleClass
            MyNullSimpleClass = new() { A = 4, B = 3 },
            // class MySimpleClass - normal, whole class is serialized if any property changed
            MySimpleClass = new() { A = 4, B = 3 },
            // [JsonDiffClass] class MyRevClass
            MyRevClass = new() { A = 4, B = 3 },
        };

        //No changes
        AssertDiff(start, start, "{}");

        //Modified
        AssertDiff(start, new()
        {
            MyInt32 = 12,
            MyNullInt32 = 12,
            MySimpleClass = new() { A = 12, B = 3 }, //Whole class is serialized
            MyNullSimpleClass = start.MyNullSimpleClass,
            MyRevClass = new() { A = 12, B = 3 }, //Only changed fields are serialized
        }, """
        {
          "MyInt32": 12,
          "MyNullInt32": 12,
          "MySimpleClass": {
            "A": 12,
            "B": 3
          },
          "^MyRevClass": {
            "A": 12
          }
        }
        """);

        //Modified default/null
        AssertDiff(start, new()
        {
            MyInt32 = 0,
            MyNullInt32 = null,
            MySimpleClass = new() { A = 4, B = null },
            MyNullSimpleClass = null,
            MyRevClass = new() { A = 4, B = null }, //Only B is changed to null
        }, """
        {
          "MyInt32": 0,
          "MyNullInt32": null,
          "MySimpleClass": {
            "A": 4
          },
          "MyNullSimpleClass": null,
          "^MyRevClass": {
            "B": null
          }
        }
        """);

        Debug.Fail("");
    }

}
