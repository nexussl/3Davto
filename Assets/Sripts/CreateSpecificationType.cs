using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateSpecificationType
{
    static string path = "Assets/Cars/Specification Types";
    //[MenuItem("Assets/Create/Cars/Specification Type")]

    public static void Create(string title, string unit)
    {
        if (!AssetDatabase.IsValidFolder("Assets/Cars"))
        {
            AssetDatabase.CreateFolder("Assets", "Cars");
        }

        if (!AssetDatabase.IsValidFolder(path))
        {
            AssetDatabase.CreateFolder("Assets/Cars", "Specification Types");
        }

        SpecificationType asset = ScriptableObject.CreateInstance<SpecificationType>();
        asset.title = title;
        asset.unit = unit;
        AssetDatabase.CreateAsset(asset, AssetDatabase.GenerateUniqueAssetPath(path + "/" + title + ".asset"));
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}