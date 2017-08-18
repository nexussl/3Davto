using UnityEngine;
using System.Collections.Generic;

                                                      
public class Car: ScriptableObject {
    public Manufacturer manufacturer;
    public string modelName = "New Car";
    public Sprite modelLogo;
    public GameObject carPrefab;
    public int uniqueID;

    [Header("Specifications")]
    public uint mileage = 0;
    [Range(0, 100)]
    public float oilLevel = 100;
    [Range(0, 100)]
    public float dirtLevel = 0;

    [Header("Body parts")]
    public Material bodyMaterial;
    public Texture bodyTexture;
    public List<BodyPart> installedBodyParts = new List<BodyPart>();

    [Header("Value")]
    public uint fullPrice;
    public uint sellPrice;
}