using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BaseSpecificationEditor
{
    public string baseSpecificationName;
    public float value;
}

public class BodyPartsEditor
{
    public string bodyPartsType;
    public string bodyPart;
}


public class CarEditor : EditorWindow
{
    Manufacturer[] manufacturersArray;
    List<string> manufacturersNames = new List<string>();
    Manufacturer CurrManufacturer;
    string ModelName;
    Sprite ModelLogo = null;
    string Generation;
    GameObject CarPrefab;
    uint UniqueID;
    uint Mileage;
    float OilLevel;
    float DirtLevel;

    uint FullPrice;
    uint SellPrice;
    Material BodyMaterial;
    Texture2D BodyTexture = null;

    SpecificationType[] specificationTypeArray;
    List<string> specificationTypeNames = new List<string>();

    List<BaseSpecificationEditor> CurrBaseSpecifications = new List<BaseSpecificationEditor>();

    [MenuItem("Window/Car Editor")]
    static void Init()
    {
        GetWindow(typeof(CarEditor));
    }

    void OnFocus()
    {
        manufacturersArray = Resources.FindObjectsOfTypeAll(typeof(Manufacturer)) as Manufacturer[];
        if (manufacturersNames.Count > 0)
        {
            manufacturersNames.Clear();
        }
        for (int i = 0; i < manufacturersArray.Length; i++)
        {
            manufacturersNames.Add(manufacturersArray[i].title);
        }


        specificationTypeArray = Resources.FindObjectsOfTypeAll(typeof(SpecificationType)) as SpecificationType[];
        if (specificationTypeNames.Count > 0)
        {
            specificationTypeNames.Clear();
        }


        for (int i = 0; i < specificationTypeArray.Length; i++)
        {
            specificationTypeNames.Add(specificationTypeArray[i].title);
        }
    }

    void CallCreateManufacturerWindow()
    {
        CreateManufacturerWindow window = CreateInstance<CreateManufacturerWindow>();
        window.Show();
    }

    void CallCreateSpecificationTypeWindow()
    {
        CreateSpecificationTypeWindow window = CreateInstance<CreateSpecificationTypeWindow>();
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Space(20);
        GUILayout.BeginHorizontal();

        GUILayoutOption[] LabelsOption = new GUILayoutOption[1] { GUILayout.Width(100) };
        GUILayout.Label("Manufacturer", LabelsOption);
        int Selected = 0;
        if (CurrManufacturer != null)
        {
            for (int i = 0; i < manufacturersArray.Length; i++)
            {
                if (manufacturersArray[i] == CurrManufacturer)
                {
                    Selected = i;
                }
            }
        }

        Selected = EditorGUILayout.Popup(Selected, manufacturersNames.ToArray());
        CurrManufacturer = manufacturersArray[Selected];


        if (GUILayout.Button("+", GUILayout.Height(14), GUILayout.Width(20)))
        {
            CallCreateManufacturerWindow();
        }
        GUILayout.EndHorizontal();



        GUILayout.BeginHorizontal();
        GUILayout.Label("Model Name", LabelsOption);
        ModelName = GUILayout.TextField(ModelName);
        GUILayout.EndHorizontal();



        GUILayout.BeginHorizontal();
        GUILayout.Label("Model Logo", LabelsOption);
        ModelLogo = EditorGUILayout.ObjectField(ModelLogo, typeof(Sprite), false, GUILayout.Height(100), GUILayout.Width(100)) as Sprite;
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Generation", LabelsOption);
        Generation = GUILayout.TextField(Generation);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Car Prefab", LabelsOption);
        CarPrefab = EditorGUILayout.ObjectField(CarPrefab, typeof(GameObject), false) as GameObject;
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Unique ID", LabelsOption);
        uint.TryParse(GUILayout.TextField(UniqueID.ToString()), out UniqueID);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Mileage", LabelsOption);
        uint.TryParse(GUILayout.TextField(Mileage.ToString()), out Mileage);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Oil Level", LabelsOption);
        OilLevel = GUILayout.HorizontalSlider(OilLevel, 0, 100);
        float.TryParse(GUILayout.TextField(OilLevel.ToString(), GUILayout.Width(60)), out OilLevel);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Dirt Level", LabelsOption);
        DirtLevel = GUILayout.HorizontalSlider(DirtLevel, 0, 100);
        float.TryParse(GUILayout.TextField(DirtLevel.ToString(), GUILayout.Width(60)), out DirtLevel);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Body Material", LabelsOption);
        BodyMaterial = EditorGUILayout.ObjectField(BodyMaterial, typeof(Material), false) as Material;
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Body Texture", LabelsOption);
        BodyTexture = EditorGUILayout.ObjectField(BodyTexture, typeof(Texture2D), false) as Texture2D;
        GUILayout.EndHorizontal();

        GUILayout.Label("Value", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Full Price", LabelsOption);
        uint.TryParse(GUILayout.TextField(FullPrice.ToString(), GUILayout.Width(60)), out FullPrice);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Sell Price", LabelsOption);
        uint.TryParse(GUILayout.TextField(SellPrice.ToString(), GUILayout.Width(60)), out SellPrice);
        GUILayout.EndHorizontal();


        GUILayout.Label("Base specifications", EditorStyles.boldLabel);
        GUILayout.BeginHorizontal();
        if (CurrBaseSpecifications.Count == 0 && GUILayout.Button("Fill base specifications"))
        {
            if (specificationTypeArray.Length == 0)
            {
                if (EditorUtility.DisplayDialog("Fill base specifications failed", "There are no base specifications! Please create at least one base specification", "Create base specification", "Cancel"))
                {
                    CallCreateSpecificationTypeWindow();
                }
            }

            for (int i = 0; i < specificationTypeArray.Length; i++)
            {
                BaseSpecificationEditor baseSpecification = new BaseSpecificationEditor();
                baseSpecification.baseSpecificationName = specificationTypeArray[i].title;
                baseSpecification.value = 0;
                CurrBaseSpecifications.Add(baseSpecification);

            }
            //ShowWindow();
        }
        GUILayout.EndHorizontal();


        for (int i = 0; i < CurrBaseSpecifications.Count; i++)
        {
            GUILayout.BeginHorizontal();




            if (GUILayout.Button("Remove"))
            {
                CurrBaseSpecifications.Remove(CurrBaseSpecifications[i]);
            }

            if (CurrBaseSpecifications.Count > i)
            {

                int SelectedBaseSpecification = 0;
                for (int i2 = 0; i2 < specificationTypeArray.Length; i2++)
                {
                    if (CurrBaseSpecifications[i].baseSpecificationName == specificationTypeNames[i2])
                    {
                        SelectedBaseSpecification = i2;
                    }
                }

                SelectedBaseSpecification = EditorGUILayout.Popup(SelectedBaseSpecification, specificationTypeNames.ToArray());
                string SelectedBaseSpecificationName = specificationTypeNames[SelectedBaseSpecification];
                BaseSpecificationEditor BSE = CurrBaseSpecifications.Find(x => x.baseSpecificationName == SelectedBaseSpecificationName && x != CurrBaseSpecifications[i]);
                if (BSE != null)
                {
                    if (!EditorUtility.DisplayDialog("Selecting base specification failed", "This car already has base specification " + SelectedBaseSpecificationName, "OK", "Delete"))
                    {
                            CurrBaseSpecifications.Remove(CurrBaseSpecifications[i]);
                        i--;
                    }


                    /*
                    for (int i2 = 0; i2 < CurrBaseSpecifications.Count; i2++)
                    {
                        //CurrBaseSpecifications[i2].baseSpecificationName
                        
                        if (SelectedBaseSpecificationName == CurrBaseSpecifications[i2].baseSpecificationName && CurrBaseSpecifications[i2] != CurrBaseSpecifications[i])
                        {
                            CurrBaseSpecifications.Remove(CurrBaseSpecifications[i2]);
                        }
                    }
                    */
                }
                else
                {
                    CurrBaseSpecifications[i].baseSpecificationName = specificationTypeNames[SelectedBaseSpecification];
                }


                if (GUILayout.Button("+", GUILayout.Height(14), GUILayout.Width(20)))
                {
                    CallCreateSpecificationTypeWindow();
                }


                float.TryParse(GUILayout.TextField(CurrBaseSpecifications[i].value.ToString(), GUILayout.Width(60)), out CurrBaseSpecifications[i].value);
                string unit = "";
                for (int i2 = 0; i2 < specificationTypeArray.Length; i2++)
                {
                    if (specificationTypeArray[i2].title == CurrBaseSpecifications[i].baseSpecificationName)
                    {
                        unit = specificationTypeArray[i2].unit;
                        break;
                    }
                }
                GUILayout.Label(unit, LabelsOption);
            }
            GUILayout.EndHorizontal();
        }


        GUILayout.BeginHorizontal();
        if (CurrBaseSpecifications.Count > 0)
        {
            List<string> AvaliableSpecificationNames = new List<string>(specificationTypeNames);
            for (int i = 0; i < CurrBaseSpecifications.Count; i++)
            {
                AvaliableSpecificationNames.Remove(CurrBaseSpecifications[i].baseSpecificationName);
            }

            if (AvaliableSpecificationNames.Count > 0)
            {


                if (GUILayout.Button("Add base specification"))
                {
                    BaseSpecificationEditor baseSpecification = new BaseSpecificationEditor();
                    baseSpecification.baseSpecificationName = AvaliableSpecificationNames[0];
                    baseSpecification.value = 0;
                    CurrBaseSpecifications.Add(baseSpecification);
                }


            }


        }
        GUILayout.EndHorizontal();


        if (GUILayout.Button("Create Car"))
        {
            CreateNewCar();
        }

    }



    void CreateNewCar()
    {
        List<BaseSpecification> BaseSpecifications = new List<BaseSpecification>();
        for (int i = 0; i < CurrBaseSpecifications.Count; i++)
        {
            BaseSpecification baseSpecification = new BaseSpecification();
            baseSpecification.baseValue = CurrBaseSpecifications[i].value;
            SpecificationType specificationType = null;
            for (int i2 = 0; i2 < specificationTypeArray.Length; i2++)
            {
                if (specificationTypeArray[i2].title == CurrBaseSpecifications[i].baseSpecificationName)
                {
                    specificationType = specificationTypeArray[i2];
                    break;
                }
            }
            baseSpecification.specificationType = specificationType;
            BaseSpecifications.Add(baseSpecification);

        }


        Car newCar = CreateCar.Create(CurrManufacturer, ModelName, ModelLogo, Generation, CarPrefab, UniqueID, Mileage, OilLevel, DirtLevel, BaseSpecifications, BodyMaterial, BodyTexture, null, FullPrice, SellPrice);
    }
}





public class CreateManufacturerWindow : EditorWindow
{
    Texture2D manufacturerLogo;
    string manufacturerTitle;
    void OnGUI()
    {

        GUILayout.BeginHorizontal();
        GUILayout.Label("Manufacturer Editor", EditorStyles.boldLabel);

        GUILayout.EndHorizontal();

        manufacturerTitle = EditorGUILayout.TextField("Title", manufacturerTitle, GUILayout.ExpandWidth(false), GUILayout.Width(250));
        manufacturerLogo = EditorGUILayout.ObjectField("Logo", manufacturerLogo, typeof(Texture2D), false, GUILayout.Height(100), GUILayout.Width(250)) as Texture2D;

        if (GUILayout.Button("Create Manufacturer", GUILayout.ExpandWidth(true)))
        {
            if (manufacturerTitle != "" && manufacturerLogo != null)
            {
                CreateNewManufacturer(manufacturerTitle, manufacturerLogo);

            }
            else
            {
                EditorUtility.DisplayDialog("Create manufacturer failed", "Please fil manufacturer Name and Logo", "Ok");
            }
        }
    }



    void CreateNewManufacturer(string title, Texture2D logo)
    {
        CreateManufacturer.Create(title, logo);
        if (EditorUtility.DisplayDialog("Creating succesful", "Manufacturer " + title + " was created", "OK"))
        {
            Close();
        }
    }
}




public class CreateSpecificationTypeWindow : EditorWindow
{
    string Title;
    string Unit;
    void OnGUI()
    {

        GUILayout.BeginHorizontal();
        GUILayout.Label("Specification Type Editor", EditorStyles.boldLabel);

        GUILayout.EndHorizontal();



        Title = EditorGUILayout.TextField("Title", Title, GUILayout.ExpandWidth(false), GUILayout.Width(250));
        Unit = EditorGUILayout.TextField("Unit", Unit, GUILayout.ExpandWidth(false), GUILayout.Width(250));

        if (GUILayout.Button("Create specification type", GUILayout.ExpandWidth(true)))
        {
            if (Title != "" && Unit != null)
            {
                CreateNewManufacturer(Title, Unit);

            }
            else
            {
                EditorUtility.DisplayDialog("Create specification type failed", "Please fil specification type Title and Unit", "Ok");
            }
        }
    }



    void CreateNewManufacturer(string title, string unit)
    {
        CreateSpecificationType.Create(title, unit);
        if (EditorUtility.DisplayDialog("Creating succesful", "Specification type " + title + " was created", "OK"))
        {
            Close();
        }
    }
}
































public class CarUpgradeEditor : EditorWindow
{
    Car CurrentCar;



    [MenuItem("Window/Car Upgrade")]
    static void Init()
    {
        GetWindow(typeof(CarUpgradeEditor));
    }

    void OnFocus()
    {

    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Car Upgrade Editor", EditorStyles.boldLabel);

        GUILayout.EndHorizontal();


        CurrentCar = EditorGUILayout.ObjectField(CurrentCar, typeof(Car), false) as Car;
        if (CurrentCar != null)
        {
            GUILayout.Label("Installed body parts", EditorStyles.boldLabel);
            List<BodyPart> installedBodyParts = CurrentCar.installedBodyParts;

            for (int i = 0; i < installedBodyParts.Count; i++)
            {

                GUILayout.BeginHorizontal();
                installedBodyParts[i] = EditorGUILayout.ObjectField(installedBodyParts[i], typeof(BodyPart), false) as BodyPart;
                if (GUILayout.Button("+", GUILayout.Height(14), GUILayout.Width(20)))
                {
                    CallCreateBodyPartWindow();
                }
                GUILayout.EndHorizontal();
            }

        }

    }


    void CallCreateBodyPartWindow()
    {
        CreateBodyPartWindow window = CreateInstance<CreateBodyPartWindow>();
        window.Show();
    }


}



public class CreateBodyPartWindow : EditorWindow
{
    BodyPart currBodyPart;
    BodyPartType[] BodyPartTypeArray;
    BodyPartType bodyPartType;
    List<string> BodyPartTypeNames = new List<string>();
    string Name;
    string Unit;

    [MenuItem("Window/Body Part Editor")]
    static void Init()
    {
        GetWindow(typeof(CreateBodyPartWindow));
    }


    void OnFocus() {
        BodyPartTypeArray = Resources.FindObjectsOfTypeAll(typeof(BodyPartType)) as BodyPartType[];
        if (BodyPartTypeNames.Count > 0)
        {
            BodyPartTypeNames.Clear();
        }
        for (int i = 0; i < BodyPartTypeArray.Length; i++)
        {
            BodyPartTypeNames.Add(BodyPartTypeArray[i].Title);
        }
    }


    void OnGUI()
    {
        GUILayoutOption[] LabelsOption = new GUILayoutOption[1] { GUILayout.Width(100) };
        GUILayout.BeginHorizontal();
        GUILayout.Label("Body Part Editor", EditorStyles.boldLabel);
        GUILayout.EndHorizontal();



        currBodyPart = EditorGUILayout.ObjectField(currBodyPart, typeof(BodyPart), false) as BodyPart;

        if (currBodyPart != null)
        {
            bodyPartType = currBodyPart.bodyPartType;
            Name = currBodyPart.Name;
            
        }



        GUILayout.BeginHorizontal();

        
        GUILayout.Label("Body Parts Type", LabelsOption);
        int Selected = 0;
        if (bodyPartType != null)
        {
            for (int i = 0; i < BodyPartTypeArray.Length; i++)
            {
                if (BodyPartTypeArray[i] == bodyPartType)
                {
                    Selected = i;
                }
            }
        }
        Selected = EditorGUILayout.Popup(Selected, BodyPartTypeNames.ToArray());
        bodyPartType = BodyPartTypeArray[Selected];


        if (GUILayout.Button("+", GUILayout.Height(14), GUILayout.Width(20)))
        {
            CallCreateBodyPartTypeWindow();
        }
        GUILayout.EndHorizontal();




        if (currBodyPart == null)
        {
            if (GUILayout.Button("Create new body part", GUILayout.ExpandWidth(true)))
            {
                if (bodyPartType != null)
                {
                    currBodyPart = CreateNewBodyPart(bodyPartType);

                }
                else
                {
                    EditorUtility.DisplayDialog("Create body part type failed", "Please fil body part type Title", "Ok");
                }
            }
        }
        else
        {
            currBodyPart.Name = Name;
            AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(currBodyPart), Name);
        }

        //Name = EditorGUILayout.TextField("Title", Name, GUILayout.ExpandWidth(false), GUILayout.Width(250));




    }



    BodyPart CreateNewBodyPart(BodyPartType bodyPartType)
    {
        BodyPart bp = CreateBodyPart.Create(bodyPartType);
        if (EditorUtility.DisplayDialog("Creating succesful", "Body part " + bodyPartType.ToString() + " was created", "OK"))
        {
            Close();
        }
        return bp;
    }

    void CallCreateBodyPartTypeWindow()
    {
        CreateBodyPartsTypeWindow window = CreateInstance<CreateBodyPartsTypeWindow>();
        window.Show();
    }
}



public class CreateBodyPartsTypeWindow : EditorWindow
{
    BodyPartType bpt;
    string Title;
    void OnGUI()
    {

        GUILayout.BeginHorizontal();
        GUILayout.Label("Body part type editor", EditorStyles.boldLabel);

        GUILayout.EndHorizontal();

        bpt = EditorGUILayout.ObjectField(bpt, typeof(BodyPartType), false) as BodyPartType;

        if (bpt != null)
        {
            Title = bpt.Title;
        }


        Title = EditorGUILayout.TextField("Title", Title, GUILayout.ExpandWidth(false), GUILayout.Width(250));

        if (bpt == null)
        {
            if (GUILayout.Button("Create new body part type", GUILayout.ExpandWidth(true)))
            {
                if (Title != "")
                {
                    bpt = CreateNewBodyPartType(Title);

                }
                else
                {
                    EditorUtility.DisplayDialog("Create body part type failed", "Please fil body part type Title", "Ok");
                }
            }
        }
        else {
            bpt.Title = Title;
            AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(bpt), Title);
        }
    }



    BodyPartType CreateNewBodyPartType(string title)
    {
        BodyPartType bpt = CreateBodyPartType.Create(title);
        if (EditorUtility.DisplayDialog("Creating succesful", "Body part type " + title + " was created", "OK"))
        {
            Close();
        }
        return bpt;
    }
}


