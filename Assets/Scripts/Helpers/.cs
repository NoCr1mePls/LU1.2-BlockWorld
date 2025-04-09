using UnityEngine;
using UnityObjectScripts.DataObjects;

namespace UnityObjectScripts.Helpers
{
    /// <summary>
    /// A class containing json helpers
    /// </summary>
    public static class JSONHelper
    {
        /// <summary>
        /// Use this method to convert an object to a json string
        /// </summary>
        /// <param name="obj">object to be converted</param>
        /// <returns>The object as a string representation</returns>
        public static string SerializeToJson(object obj)
        {
            if (obj == null)
                return "NULL";
            else 
                return JsonUtility.ToJson(obj);
        }
        
        /// <summary>
        /// Use this method to convert a json string to an object
        /// </summary>
        /// <param name="jsonVal">The json string as raw</param>
        /// <returns></returns>
        public static WrapperDTO DeserializeFromJson(string jsonVal) {
            if(string.IsNullOrEmpty(jsonVal)) return null;
            Debug.Log($"Converting: {jsonVal}");
            return JsonUtility.FromJson<WrapperDTO>(jsonVal);
        }
    }
}