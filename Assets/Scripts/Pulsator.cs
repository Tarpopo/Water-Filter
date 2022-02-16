using System.Collections;
using UnityEngine;

public class Pulsator : MonoBehaviour
{
    [SerializeField]
    private float _delay;

    [SerializeField]
    private float _scaleFactor;
    
    [SerializeField]
    private int _frames;

    private Transform _transform;
    private Vector3 _origScale;

    [SerializeField]
    private bool _pulseOnEnable = true;

    private void Awake()
    {
        _transform = transform;
        _origScale = transform.localScale;
    }

    private IEnumerator Pulse()
    {
        yield return new WaitForSeconds(_delay);
        if (_transform == null) yield return null;
        
        Vector3 target = _transform.localScale * _scaleFactor;

        Vector3 delta = (target - _transform.localScale) / _frames;

        while (true)
        {
            for (int i = 0; i < _frames; i++)
            {
                if (_transform != null) _transform.localScale -= delta;

                yield return null;
            }

            for (int i = 0; i < _frames; i++)
            {
                if(_transform!=null) _transform.localScale += delta;

                yield return null;
            }
        }
    }

    private void OnEnable()
    {
        if(_pulseOnEnable)
            StartPulse(_transform);
    }

    private void OnDisable()
    {
        StopPulse();
    }

    public void StartPulse(Transform objTransform)
    {
        StopAllCoroutines();
        _transform = objTransform;
        _origScale = _transform.localScale;
        StartCoroutine(Pulse());
    }
    
    public void StopPulse()
    {
        StopAllCoroutines();
        _transform.localScale = _origScale;
    }
}
