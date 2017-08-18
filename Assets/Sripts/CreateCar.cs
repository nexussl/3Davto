using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateCar
{
    static string path = "Assets/Cars/Catalogue";
    [MenuItem("Assets/Create/Cars/Car")]
    public static Car Create()
    {
        if (!AssetDatabase.IsValidFolder("Assets/Cars"))
        {
            AssetDatabase.CreateFolder("Assets", "Cars");
        }

        if (!AssetDatabase.IsValidFolder(path))
        {
            AssetDatabase.CreateFolder("Assets/Cars", "Catalogue");
        }

        Car asset = ScriptableObject.CreateInstance<Car>();
        AssetDatabase.CreateAsset(asset, AssetDatabase.GenerateUniqueAssetPath(path + "/New Car.asset"));
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
        return asset;
    }
}