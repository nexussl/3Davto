using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateManufacturer
{
    static string path = "Assets/Cars/Manufacturers";
    [MenuItem("Assets/Create/Cars/Manufacturer")]
    public static void CreateEmptyManufacturer() {
        Create("New Manufacturer", null);
    }

    public static Manufacturer Create(string title, Texture2D logo)
    {
        if (!AssetDatabase.IsValidFolder("Assets/Cars"))
        {
            AssetDatabase.CreateFolder("Assets", "Cars");
        }

        if (!AssetDatabase.IsValidFolder(path))
        {
            AssetDatabase.CreateFolder("Assets/Cars", "Manufacturers");
        }

        Manufacturer asset = ScriptableObject.CreateInstance<Manufacturer>();
        asset.title = title;
        asset.logo = logo;
        AssetDatabase.CreateAsset(asset, AssetDatabase.GenerateUniqueAssetPath(path + "/" + title + ".asset"));
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
        return asset;
    }
}