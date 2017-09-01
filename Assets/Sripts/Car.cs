using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class BaseSpecification
{
    public SpecificationType specificationType;
    public float baseValue;
}



public class Car : ScriptableObject
{
    public Manufacturer manufacturer;
    public string modelName = "New Car";
    public Sprite modelLogo;
    public string generation;
    public GameObject carPrefab;
    public uint uniqueID;

    public uint mileage = 0;
    [Range(0, 100)]
    public float oilLevel = 100;
    [Range(0, 100)]
    public float dirtLevel = 0;



    [Header("Base Specifications")]
    public List<BaseSpecification> baseSpecificationsList = new List<BaseSpecification>();

    /*
    [Range(0,5000)]
    [SerializeField]
    float baseWeight;
    public float FullWeight
    {
        get
        {
            return CalculateValueBySpecificationType(SpecificationType.Weight);
        }
    }

    [Range(0, 2000)]
    [SerializeField]
    float baseEnginePower;
    public float FullEnginePower
    {
        get
        {
            return CalculateValueBySpecificationType(SpecificationType.EnginePower);
        }
    }

    [Range(0, 5000)]
    [SerializeField]
    float baseTorque;
    public float FullTorque
    {
        get
        {
            return CalculateValueBySpecificationType(SpecificationType.Torque);
        }
    }

    [Range(0, 100)]
    [SerializeField]
    float baseAerodynamics;
    public float FullAerodynamics
    {
        get
        {
            return CalculateValueBySpecificationType(SpecificationType.Aerodynamics);
        }
    }

    [Range(0, 20)]
    [SerializeField]
    float baseFuelConsumption;
    public float FullFuelConsumption
    {
        get
        {
            return CalculateValueBySpecificationType(SpecificationType.FuelConsumption);
        }
    }

    [Range(0, 700)]
    [SerializeField]
    float baseMaximumSpeed;
    public float FullMaximumSpeed
    {
        get
        {
            return CalculateValueBySpecificationType(SpecificationType.MaximumSpeed);
        }
    }

    [Range(0, 50)]
    [SerializeField]
    float baseAccelerationTo100;
    public float FullAccelerationTo100
    {
        get
        {
            return CalculateValueBySpecificationType(SpecificationType.AccelerationFrom0To100);
        }
    }

    [Range(0, 100)]
    [SerializeField]
    float baseAccelerationTo200;
    public float FullAccelerationTo200
    {
        get
        {
            return CalculateValueBySpecificationType(SpecificationType.AccelerationFrom100To200);
        }
    }

    [Range(0, 200)]
    [SerializeField]
    float baseVolumeOfFuelTank;
    public float FullVolumeOfFuelTank
    {
        get
        {
            return CalculateValueBySpecificationType(SpecificationType.VolumeOfFuelTank);
        }
    }

    */





    [Header("Body parts")]
    public Material bodyMaterial;
    public Texture bodyTexture;
    public List<BodyPart> installedBodyParts = new List<BodyPart>();

    [Header("Value")]
    public uint fullPrice;
    public uint sellPrice;



    public float CalculateValueBySpecificationType(SpecificationType specificationType) {
        float Value = GetBaseValueBySpecificationType(specificationType);
        List<AffectingOnSpecification> AffectingBodyPartList = new List<AffectingOnSpecification>();
        for (int i = 0; i < installedBodyParts.Count; i++)
        {

            AffectingOnSpecification affectingOnSpecification = installedBodyParts[i].affectingOnSpecificationList.Find(x => x.specificationType == specificationType);
            if (affectingOnSpecification != null)
            {
                AffectingBodyPartList.Add(affectingOnSpecification);
            }
        }

        if (AffectingBodyPartList.Count > 0)
        {
            AffectingOnSpecification replaceBaseValue = AffectingBodyPartList.Find(x => x.affectingType == AffectingType.ReplaceBaseValue);

            if (replaceBaseValue != null)
            {
                Value = replaceBaseValue.AffectingValue;
            }

            List<AffectingOnSpecification> MultiplyAffection = AffectingBodyPartList.FindAll(x => x.affectingType == AffectingType.Multiply);
            for (int i = 0; i < MultiplyAffection.Count; i++)
            {
                Value *= MultiplyAffection[i].AffectingValue;
            }
            if (Value < 0)
            {
                Debug.LogWarning(specificationType.ToString() + " - Value cant be below zero! Setting to Zero");
                Value = 0;
            }


            List<AffectingOnSpecification> AdditionOrSubstractionAffection = AffectingBodyPartList.FindAll(x => x.affectingType == AffectingType.AdditionOrSubstraction);
            for (int i = 0; i < AdditionOrSubstractionAffection.Count; i++)
            {
                Value += AdditionOrSubstractionAffection[i].AffectingValue;
            }
            if (Value < 0)
            {
                Debug.LogWarning(specificationType.ToString() + " - Value cant be below zero! Setting to Zero");
                Value = 0;
            }
        }

        return Value;
    }



    float GetBaseValueBySpecificationType(SpecificationType specificationType) 
    {

        BaseSpecification baseSpecification = baseSpecificationsList.Find(x => x.specificationType == specificationType);
        if (baseSpecification != null)
        {
            return baseSpecification.baseValue;
        }
        else {
            return 0;
        }

        /*
        switch (specificationType)
        {
            case SpecificationType.AccelerationFrom0To100:
                return baseAccelerationTo100;

            case SpecificationType.AccelerationFrom100To200:
                return baseAccelerationTo200;

            case SpecificationType.Aerodynamics:
                return baseAerodynamics;

            case SpecificationType.EnginePower:
                return baseEnginePower;

            case SpecificationType.FuelConsumption:
                return baseFuelConsumption;

            case SpecificationType.MaximumSpeed:
                return baseMaximumSpeed;

            case SpecificationType.Torque:
                return baseTorque;

            case SpecificationType.VolumeOfFuelTank:
                return baseVolumeOfFuelTank;

            case SpecificationType.Weight:
                return baseWeight;
            default:
                return 0;
        }
        */
    }
}