using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificationType : ScriptableObject
{
    public string title = "New Specification Type";
    public string unit;
}

/*
[System.Serializable]
public class CarSpecification
{
    public SpecificationType specificationType;
    public float Value;
}
*/

/*
public enum SpecificationType
{
    //DO NOT CHANGE NUMERIC VALUES!
    Weight = 100,
    EnginePower = 200,
    Torque = 300,
    Aerodynamics = 400,
    FuelConsumption = 500,
    MaximumSpeed = 600,
    AccelerationFrom0To100 = 700,
    AccelerationFrom100To200 = 800,
    VolumeOfFuelTank = 900,
    
}
*/

/*
public class Specification {
public string GetSpecificationUnitBySpecificationType(SpecificationType specificationType) {
    switch (specificationType)
    {
        case SpecificationType.AccelerationFrom0To100:
            return "s";

        case SpecificationType.AccelerationFrom100To200:
            return "s";

        case SpecificationType.Aerodynamics:
            return "Сх";

        case SpecificationType.EnginePower:
            return "h.p./ kW";

        case SpecificationType.FuelConsumption:
            return "L/100km";

        case SpecificationType.MaximumSpeed:
            return "km/h";

        case SpecificationType.Torque:
            return "Hm";

        case SpecificationType.VolumeOfFuelTank:
            return "L";

        case SpecificationType.Weight:
            return "kg";
        default:
            return "";
    }
}


}
*/
