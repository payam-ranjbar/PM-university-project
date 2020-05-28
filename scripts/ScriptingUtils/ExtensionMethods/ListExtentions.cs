using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace ScriptingUtils.ExtensionMethods
{
    public static class ListExtensions
    {
        public static T GetRandomObject<T>(this List<T> list, T excluded = default , int min = 0, int max = 0)
        {
            Random rnd = new Random((int) Time.time);
            if (max == 0)
            {
                max = list.Count;
            }

            if (excluded != null) 
            {
                var listCopy = list;
                listCopy.Remove(excluded);
                return listCopy[rnd.Next(min, max)];
            }

            int outputIndex;
            do
            {
                outputIndex = rnd.Next(min, max);

            }
            while (list[outputIndex] == null);

            return list[outputIndex];
        }
        
        public static List<T> Exclude<T>(this List<T> list, T obj)
        {
            list.Remove(obj);
            return list;
        }
        public static List<T> Include<T>(this List<T> list, T obj)
        {
            if (!list.Contains(obj))
            {
                list.Add(obj);
            }
            return list;
        }
        
    }
}