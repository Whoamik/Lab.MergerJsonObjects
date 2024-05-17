using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.MergerJsonObjects.Entities
{
    internal class CollectionObject
    {
        public List<object> Objects { get; set; } = new List<object>();
        public List<string> Strings { get; set; } = new List<string>();
        public List<int> Ints { get; set; } = new List<int>();
        public List<SampleObject> SampleObjects { get; set; } = new List<SampleObject>();
    }
}
