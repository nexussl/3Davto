using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class CreateCar
{
    static string path = "Assets/Cars/Catalogue";
    //[MenuItem("Assets/Create/Cars/Car")]
    public static Car Create(

    Manufacturer manufacturer,
    string modelName,
    Sprite modelLogo,
    string generation,
    GameObject carPrefab,
    uint uniqueID,
    uint mileage,
    float oilLevel,
    float dirtLevel,
    List<BaseSpecification> baseSpecificationsList,
    Material bodyMaterial,
    Texture bodyTexture,
    List<BodyPart> installedBodyParts,
    uint fullPrice,
    uint sellPrice

    )
    {
        if (!AssetDatabase.IsValidFolder("Assets/Cars"))
        {
            AssetDatabase.CreateFolder("Assets", "Cars");
        }

        if (!AssetDatabase.IsValidFolder("Assets/Cars/Catalogue"))
        {
            AssetDatabase.CreateFolder("Assets/Cars", "Catalogue");
        }

        if (!AssetDatabase.IsValidFolder("Assets/Cars/Catalogue/" + manufacturer.title))
        {
            AssetDatabase.CreateFolder("Assets/Cars/Catalogue", manufacturer.title);
        }

        Car asset = ScriptableObject.CreateInstance<Car>();

        asset.baseSpecificationsList = baseSpecificationsList;
        asset.bodyMaterial = bodyMaterial;
        asset.bodyTexture = bodyTexture;
        asset.carPrefab = carPrefab;
        asset.dirtLevel = dirtLevel;
        asset.fullPrice = fullPrice;
        asset.generation = generation;
        asset.installedBodyParts = installedBodyParts;
        asset.manufacturer = manufacturer;
        asset.mileage = mileage;
        asset.modelLogo = modelLogo;
        asset.modelName = modelName;
        asset.oilLevel = oilLevel;
        asset.sellPrice = sellPrice;
        asset.uniqueID = uniqueID;






        AssetDatabase.CreateAsset(asset, AssetDatabase.GenerateUniqueAssetPath("Assets/Cars/Catalogue/" + manufacturer.title + "/" + manufacturer.title + " " + modelName + ".asset"));
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
        return asset;
    }
}