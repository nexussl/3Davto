using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateBodyPartType
{
    static string path = "Assets/Cars/BodyPartTypes";
    [MenuItem("Assets/Create/Cars/Body Part Type")]

    public static void Create()
    {
        if (!AssetDatabase.IsValidFolder("Assets/Cars"))
        {
            AssetDatabase.CreateFolder("Assets", "Cars");
        }

        if (!AssetDatabase.IsValidFolder(path))
        {
            AssetDatabase.CreateFolder("Assets/Cars", "BodyPartTypes");
        }

        BodyPartType asset = ScriptableObject.CreateInstance<BodyPartType>();
        AssetDatabase.CreateAsset(asset, AssetDatabase.GenerateUniqueAssetPath(path + "/New Body Part Type.asset"));
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}