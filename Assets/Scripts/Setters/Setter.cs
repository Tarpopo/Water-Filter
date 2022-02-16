using System;
using UnityEngine;
public class Setter : MonoBehaviour
{
    [SerializeField] protected Set _loadedTransform;
    [SerializeField] protected Set _completedTransform;
    public virtual void OnLoadedSet()
    {
        SetTransform(transform,_loadedTransform);
    }
    public virtual void OnCompletedSet()
    {
        SetTransform(transform,_completedTransform);
    }
    protected void SetTransform(Transform transform,Set set)
    {
        transform.position = set.Position;
        transform.eulerAngles = set.Rotation;
    }
}
[Serializable]
public class Set
{
    public Vector3 Position;
    public Vector3 Rotation;
}
