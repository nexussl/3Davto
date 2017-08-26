using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AffectingType {
    Multiply,
    AdditionOrSubstraction,
    ReplaceBaseValue
}

[System.Serializable]
public class AffectingOnSpecification {
    public SpecificationType specificationType;
    public AffectingType affectingType;
    public float AffectingValue;
}

public class BodyPart : ScriptableObject {
    public BodyPartType bodyPartType;
    public string Name = "New Body Part";
    public GameObject bodyPartPrefab;
    public Sprite BodyPartImage;
    public Material material;
    public string description;
    public uint Price;
    public int uniqueID;
    public List<AffectingOnSpecification> affectingOnSpecificationList = new List<AffectingOnSpecification>();
    public List<Car> avaliableCarList = new List<Car>();
}
