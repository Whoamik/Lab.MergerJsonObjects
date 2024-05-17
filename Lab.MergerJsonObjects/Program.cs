using Lab.MergerJsonObjects;
using Lab.MergerJsonObjects.Entities;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        var data = new
        {
            stronk = new
            {
                id = "test0",
                name = "data",
                var = "123",
                date = new DateTime(2024, 05, 17),
                obj = new
                {
                    strik = 3,
                    enx = EnumObject.Strink
                }
            },
            name = "data",
            arr = new CollectionObject()
            {
                SampleObjects = new List<SampleObject> { new SampleObject() { id = "111", Name = "string1" }, new SampleObject() { id = "333", Name = "string22" } },
                Ints = new List<int>() { 1, 23, 4 },
            },
            brr = new[] { new {
                    id = "testarr", value = "arres"
                }, new {
                    id = "testarr2", value = "arres" } },
            obj = new SampleObject() { Name = "name", }
        };

        var data2 = new
        {
            stronk = new
            {
                id = "test1",
                name = "data",
                var = "123",
                date = DateTime.Now,
                obj = new
                {
                    strik = 1,
                    enx = EnumObject.Sure
                }
            },
            name = "data",
            arr = new CollectionObject()
            {
                SampleObjects = new List<SampleObject> { new SampleObject() { id = "111", Name = "bbb" }, new SampleObject() { id = "222", Name = "ccc" } },
                Strings = new List<string>() { "value", "test" },
                Ints = new List<int>() { 1, 23, 477 },
                Objects = new List<object>() { DateTime.Now, "nhac", 1, 244 }
            },
            brr = new[] { new {
                    id = "testarr", value = "arres"
                }, new {
                    id = "testarr2", value = "arres" } },
            obj = new SampleObject() { Name = "name", }
        };

        Console.WriteLine(JsonConvert.SerializeObject(data));
        Console.WriteLine(JsonConvert.SerializeObject(data2));
        bool is_same = MergerObjects.Compare(data, data2);
        Console.WriteLine(is_same);
        MergerObjects.Merge(data, data2);
        Console.WriteLine(JsonConvert.SerializeObject(data));
        Console.ReadLine();
    }
}
