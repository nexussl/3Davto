using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateSpecificationType
{
    static string path = "Assets/Cars/Specification Types";
    [MenuItem("Assets/Create/Cars/Specification Type")]

    public static void Create()
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
        AssetDatabase.CreateAsset(asset, AssetDatabase.GenerateUniqueAssetPath(path + "/New Specification Type.asset"));
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}