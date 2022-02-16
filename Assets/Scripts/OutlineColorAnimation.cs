using System.Collections;
using UnityEngine;
public class OutlineColorAnimation : MonoBehaviour
{
    [SerializeField] private bool _activeOnStart;
    [SerializeField] private int _frames;
    private Color _startColor;
    private Outline _outline;
    private void Start()
    {
        _outline = GetComponent<Outline>();
        _startColor = _outline.OutlineColor;
        if (_activeOnStart) Animate();
    }
    public void Animate()
    {
        StopAllCoroutines();
        _outline.OutlineColor = _startColor;
        StartCoroutine(ImageToColorAnim(Color.clear, _frames));
    }
    public void StopAnimation()
    {
        StopAllCoroutines();
        _outline.OutlineColor = Color.clear;
    }
    private IEnumerator ImageToColorAnim(Color target, int frames)
    {
        Color deltaColor = (target - _startColor) / frames;
        Color tempColor = _outline.OutlineColor;
        while (true)
        {
            for (int i = 0; i < frames; i++)
            {
                tempColor += deltaColor;
                _outline.OutlineColor = tempColor;
                yield return null;
            }
            
            for (int i = 0; i < frames; i++)
            {
                tempColor -= deltaColor;
                _outline.OutlineColor = tempColor;
                yield return null;
            }
        }
    }
}
