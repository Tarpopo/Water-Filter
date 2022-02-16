using UnityEngine;
public class CameraSetter : Setter
{
    private Camera _camera;
    public override void OnLoadedSet()
    { 
        _camera=Camera.main;
        SetTransform(_camera.transform,_loadedTransform);
        _camera.orthographic = false;
    }

    public override void OnCompletedSet()
    {
        SetTransform(_camera.transform,_completedTransform);
        _camera.orthographic = true;
    }
}
