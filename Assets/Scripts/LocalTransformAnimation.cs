using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalTransformAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 _endPosition;
    [SerializeField] private int _frames;
    [SerializeField] private float _delay;
    private WaitForSeconds _startDelay;

    private void Start()
    {
        _startDelay = new WaitForSeconds(_delay);
    }

    public void StartAnimation()
    {
        StopAllCoroutines();
        StartCoroutine(CoroutinesKid.ChangeLocalPosition(transform,_endPosition,_frames,_startDelay));
    }
}
