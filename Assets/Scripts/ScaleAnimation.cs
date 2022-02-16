using System;
using UnityEngine;
public class ScaleAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 _endScale;
    [SerializeField] private Vector3 _startScale;
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
        transform.localScale = _startScale;
        StartCoroutine(CoroutinesKid.ScalerAnim(transform,_endScale,_frames,_startDelay));
    }
}
