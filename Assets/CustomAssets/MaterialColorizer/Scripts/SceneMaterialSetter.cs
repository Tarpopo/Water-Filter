using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
public class SceneMaterialSetter : MonoBehaviour
{
    public List<MaterialColor> SceneMaterialsPropetries;
    [Button]
    private void ChangeAllMaterials()
    {
        foreach (var sceneColor in SceneMaterialsPropetries)
        {
            sceneColor.ChangeTemplateMaterial();
        }
    }
    private void Start()
    {
        ChangeAllMaterials();
    }
    private void OnDisable()
    {
        ColorTemplates.Instance.ResetAllMaterials();
    }
}
[Serializable]
public class MaterialColor
{
    public Material material;
    private IEnumerable<string> empty=new List<string>(1);
    [ValueDropdown(nameof(GetAllProperties))] public string Property;
    public void ChangeTemplateMaterial()
    {
        material.SetTextureOffset(MaterialConstants.MainTexID,ColorTemplates.Instance.GetColorOffset(Property));
    }
    private IEnumerable<String> GetAllProperties()
    {
        return ColorTemplates.Instance.GetAllProperties();
    }
}


