using System.Linq;
using UnityEditor;
using UnityEngine;
public class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance) return _instance;
            Debug.Log("create Instance");
            _instance = (T) Resources.FindObjectsOfTypeAll(typeof(T)).FirstOrDefault();
            if (_instance == null)
            {
                Debug.Log("cant find");
            }

            return _instance;
        }
    }
}
