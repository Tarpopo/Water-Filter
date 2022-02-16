using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(menuName = "ColorTemplates")]
public class ColorTemplates : SingletonScriptableObject<ColorTemplates>
{
    [SerializeField][AssetList(Path = "CustomAssets/MaterialColorizer/Materials")] private Material _templateMaterial;
    [SerializeField]private List<MaterialColor> _beginMaterialColors;
    [SerializeField][ListItemSelector(nameof(ChangeTemplateMaterial))]private List<ColorProperty> _colors;

    private void ChangeTemplateMaterial(int index)
    {
        if (_colors[index] == null) return;
        Instance._templateMaterial.SetTextureOffset(MaterialConstants.MainTexID,_colors[index].Offset);
    }
    [Button]
    public void ResetAllMaterials()
    {
        foreach (var sceneColor in Instance._beginMaterialColors)
        {
            sceneColor.ChangeTemplateMaterial();
        }
    }

    public Vector2 GetColorOffset(string name)
    {
        return Instance._colors.FirstOrDefault(element=>element.Name==name).Offset;
    }
    public IEnumerable<String> GetAllProperties()
    {
        return Instance._colors.Select(x=>x.Name);
    }
}
[Serializable]
public class ColorProperty
{
    public Action<Material> OnOffsetChange;
    public string Name;
    public Vector2 Offset;
}
