using System.Collections.Generic;
using UnityEngine;
public class ColorSetter : MonoBehaviour
{
    [SerializeField] private List<LevelColorPattern> _levelColorPatterns;
    private int _activePatternIndex;
    private void Start()
    {
        FindObjectOfType<LevelManager>().OnLevelLoaded += () =>
        {
            _levelColorPatterns[_activePatternIndex].SetPattern();
            _activePatternIndex=_levelColorPatterns.GetNextIndex(_activePatternIndex);
        };
    }
}
[System.Serializable]
public class LevelColorPattern
{
    [SerializeField] private Color _cameraBackground;
    [SerializeField] private List<ColorItem> _colorItems;
    public void SetPattern()
    {
        Camera.main.backgroundColor = _cameraBackground;
        foreach (var color in _colorItems)
        {
            color.SetColor();
        }
    }
}

[System.Serializable]
public class ColorItem
{
    [SerializeField] private Material _material;
    [SerializeField] private Vector2 _offset;
    [SerializeField] private Color _color=new Color(1,1,1,1);

    public void SetColor()
    {
        _material.SetTextureOffset(MaterialConstants.MainTexID,_offset);
        _material.SetColor(MaterialConstants.MaterialColorID,_color);
    }
}
