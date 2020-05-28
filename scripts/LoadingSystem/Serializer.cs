using UnityEngine;

namespace LoadingSystem
{
    public class Serializer<T> where T : ISerializable
    {

        public static string ToJson(T model)
        {
            return JsonUtility.ToJson(model);
        }

        public static T UpdateObjectFromJson(string json, T obj)
        {
            JsonUtility.FromJsonOverwrite(json, obj);
            return obj;
        }
    }

    
}