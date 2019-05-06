using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenge.Common.Utilities
{
    public static class ObjectSerialization<T>
    {
        public static string Serialize(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public static T Deserialize(string JsonData)
        {
            return JsonConvert.DeserializeObject<T>(JsonData);
        }
    }
}
