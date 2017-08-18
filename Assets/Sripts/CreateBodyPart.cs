using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateBodyPart
{
    static string path = "Assets/Cars/BodyParts";
    [MenuItem("Assets/Create/Cars/Body Part")]

    public static void Create()
    {
        if (!AssetDatabase.IsValidFolder("Assets/Cars"))
        {
            AssetDatabase.CreateFolder("Assets", "Cars");
        }

        if (!AssetDatabase.IsValidFolder(path))
        {
            AssetDatabase.CreateFolder("Assets/Cars", "BodyParts");
        }

        BodyPart asset = ScriptableObject.CreateInstance<BodyPart>();
        AssetDatabase.CreateAsset(asset, AssetDatabase.GenerateUniqueAssetPath(path + "/New Body Part.asset"));
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}