using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DisplaySpecifications {
    public SpecificationType specificationType;
    public float Value;
}

public class GetCarParams : MonoBehaviour {
    public Car car;
    public List<DisplaySpecifications> specifications = new List<DisplaySpecifications>();
    /*
    [Header("Weight")]
    public float CalculatedWeight;
    [Header("EnginePower")]
    public float CalculatedEnginePower;
    [Header("Torque")]
    public float CalculatedTorque;
    [Header("Aerodynamics")]
    public float CalculatedAerodynamics;
    [Header("FuelConsumption")]
    public float CalculatedFuelConsumption;
    [Header("MaximumSpeed")]
    public float CalculatedMaximumSpeed;
    [Header("AccelerationTo100")]
    public float CalculatedAccelerationTo100;
    [Header("AccelerationTo200")]
    public float CalculatedAccelerationTo200;
    [Header("VolumeOfFuelTank")]
    public float CalculatedVolumeOfFuelTank;
    */


    // Use this for initialization
    void Start () {
        if (car)
        {
            for (int i = 0; i < car.baseSpecificationsList.Count; i++) {
                DisplaySpecifications bs = new DisplaySpecifications();
                bs.specificationType = car.baseSpecificationsList[i].specificationType;
                bs.Value = car.CalculateValueBySpecificationType(car.baseSpecificationsList[i].specificationType);
                specifications.Add(bs);
            }
            /*
            CalculatedWeight = car.FullWeight;

            CalculatedEnginePower = car.FullEnginePower;

            CalculatedTorque = car.FullTorque;

            CalculatedAerodynamics = car.FullAerodynamics;

            CalculatedFuelConsumption = car.FullFuelConsumption;

            CalculatedMaximumSpeed = car.FullMaximumSpeed;

            CalculatedAccelerationTo100 = car.FullAccelerationTo100;

            CalculatedAccelerationTo200 = car.FullAccelerationTo200;
            
            CalculatedVolumeOfFuelTank = car.FullVolumeOfFuelTank;
            */
        }
}
	
}
