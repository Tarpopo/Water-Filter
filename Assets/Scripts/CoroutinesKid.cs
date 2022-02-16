using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public static class CoroutinesKid
{
    public static IEnumerator ChangePosition(Transform transform, Vector3 endPosition,float speed,UnityAction onEndMoving)
    {
        var steps=Vector3.Distance(endPosition,transform.position)/(speed*Time.fixedDeltaTime);
        var delta = (endPosition - transform.position)/steps;
        for (int i = 0;i<steps; i++)
        {
            transform.position += delta;
            yield return new WaitForFixedUpdate();
        }
        onEndMoving?.Invoke();
    }
    public static IEnumerator ChangeLocalPosition(Transform transform, Vector3 endPosition,int frames,WaitForSeconds startDelay)
    {
        yield return startDelay;
        var delta = (endPosition - transform.localPosition)/frames;
        for (int i = 0;i<frames; i++)
        {
            transform.position += delta;
            yield return new WaitForFixedUpdate();
        }
    }
    public static IEnumerator Rotate(Transform transform, Vector3 axis,float angle,int frames)
    {
        var delta = Quaternion.AngleAxis(angle/frames,axis.normalized);
        for (int i = 0;i<frames; i++)
        {
            transform.rotation *= delta;
            yield return new WaitForFixedUpdate();
        }
    }
    public static IEnumerator EulerRotate(Transform transform, Vector3 rotateTo,int frames,Action action)
    {
        var delta = Quaternion.Euler((rotateTo-transform.localEulerAngles)/frames);
        for (int i = 0;i<frames; i++)
        {
            transform.localRotation *= delta;
            yield return null;
        }
        action?.Invoke();
    }
    public static IEnumerator ScalerAnim(Transform tr, Vector3 targetScale, int frames,WaitForSeconds startDelay)
    {
        yield return startDelay;
        var delta = (targetScale - tr.localScale) / frames;

        for (int i = 0; i < frames; i++)
        {
            tr.localScale += delta;
            yield return null;
        }
    }
    public static IEnumerator AlwaysRotate(Transform transform, Vector3 rotateTo,float speed)
    {
        var delta = Quaternion.Euler(rotateTo);
        while (true)
        {
            transform.rotation *= delta;
            yield return null;
        }
    }
}
