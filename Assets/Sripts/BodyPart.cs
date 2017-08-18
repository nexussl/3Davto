using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : ScriptableObject {
    public BodyPartType bodyPartType;
    public string Name = "New Body Part";
    public GameObject bodyPartPrefab;
    public Material material;
    public List<Car> avaliableCarList = new List<Car>();
}
