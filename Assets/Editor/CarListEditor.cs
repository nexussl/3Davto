using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class CarListEditor : EditorWindow
{
    /*
    public CarList carList;
    private int viewIndex = 1;


    public Manufacturer manufacturer;

    [MenuItem("Window/Inventory Item Editor %#e")]
    static void Init()
    {
        EditorWindow.GetWindow(typeof(CarListEditor));
    }

    void OnEnable()
    {
        if (EditorPrefs.HasKey("ObjectPath"))
        {
            string objectPath = EditorPrefs.GetString("ObjectPath");
            carList = AssetDatabase.LoadAssetAtPath(objectPath, typeof(CarList)) as CarList;
        }

    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Inventory Item Editor", EditorStyles.boldLabel);
        if (carList != null)
        {
            if (GUILayout.Button("Show Item List"))
            {
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = carList;
            }
        }
        if (GUILayout.Button("Open Item List"))
        {
            OpenItemList();
        }
        if (GUILayout.Button("New Item List"))
        {
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = carList;
        }
        GUILayout.EndHorizontal();

        if (carList == null)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            //EditorGUILayout.ObjectField("Manufacturer", manufacturer, typeof(CarManufacturer), false);

            manufacturer = EditorGUILayout.ObjectField(manufacturer, typeof(Manufacturer), false) as Manufacturer;

            if (GUILayout.Button("Create New Item List", GUILayout.ExpandWidth(false)) && manufacturer != null)
            {
                CreateNewItemList(manufacturer);
            }
            if (GUILayout.Button("Open Existing Item List", GUILayout.ExpandWidth(false)))
            {
                OpenItemList();
            }
            GUILayout.EndHorizontal();
        }

        GUILayout.Space(20);

        if (carList != null)
        {
            GUILayout.BeginHorizontal();

            GUILayout.Space(10);

            if (GUILayout.Button("Prev", GUILayout.ExpandWidth(false)))
            {
                if (viewIndex > 1)
                    viewIndex--;
            }
            GUILayout.Space(5);
            if (GUILayout.Button("Next", GUILayout.ExpandWidth(false)))
            {
                if (viewIndex < carList.itemList.Count)
                {
                    viewIndex++;
                }
            }

            GUILayout.Space(60);

            if (GUILayout.Button("Add Item", GUILayout.ExpandWidth(false)))
            {
                AddItem();
            }
            if (GUILayout.Button("Delete Item", GUILayout.ExpandWidth(false)))
            {
                DeleteItem(viewIndex - 1);
            }

            GUILayout.EndHorizontal();
            if (carList.itemList == null)
                Debug.Log("wtf");
            if (carList.itemList.Count > 0)
            {
                GUILayout.BeginHorizontal();
                viewIndex = Mathf.Clamp(EditorGUILayout.IntField("Current Item", viewIndex, GUILayout.ExpandWidth(false)), 1, carList.itemList.Count);
                //Mathf.Clamp (viewIndex, 1, inventoryItemList.itemList.Count);
                EditorGUILayout.LabelField("of   " + carList.itemList.Count.ToString() + "  items", "", GUILayout.ExpandWidth(false));
                GUILayout.EndHorizontal();


                carList.itemList[viewIndex - 1].manufacturer = EditorGUILayout.ObjectField("Manufacturer", carList.itemList[viewIndex - 1].manufacturer, typeof(Manufacturer), false) as Manufacturer;
                carList.itemList[viewIndex - 1].modelLogo = EditorGUILayout.ObjectField("Model Logo", carList.itemList[viewIndex - 1].modelLogo, typeof(Sprite), false) as Sprite;
                carList.itemList[viewIndex - 1].modelName = EditorGUILayout.TextField("Model Name", carList.itemList[viewIndex - 1].modelName as string);

                GUILayout.Space(10);

            }
            else
            {
                GUILayout.Label("This Inventory List is Empty.");
            }
        }
        if (GUI.changed)
        {
            if (carList != null)
            {
                EditorUtility.SetDirty(carList);
            }
        }
    }

    void CreateNewItemList(Manufacturer manufacturer)
    {
        // There is no overwrite protection here!
        // There is No "Are you sure you want to overwrite your existing object?" if it exists.
        // This should probably get a string from the user to create a new name and pass it ...
        viewIndex = 1;
        carList = CreateCarList.Create(manufacturer);
        if (carList)
        {
            carList.manufacturer = manufacturer;
            carList.itemList = new List<Car>();
            string relPath = AssetDatabase.GetAssetPath(carList);
            EditorPrefs.SetString("ObjectPath", relPath);
        }
    }

    void OpenItemList()
    {
        string absPath = EditorUtility.OpenFilePanel("Select Inventory Item List", "", "");
        if (absPath.StartsWith(Application.dataPath))
        {
            string relPath = absPath.Substring(Application.dataPath.Length - "Assets".Length);
            carList = AssetDatabase.LoadAssetAtPath(relPath, typeof(CarList)) as CarList;
            if (carList.itemList == null)
                carList.itemList = new List<Car>();
            if (carList)
            {
                EditorPrefs.SetString("ObjectPath", relPath);
            }
        }
    }

    void AddItem()
    {
        Car newItem = new Car();
        newItem.modelName = "New Car";
        carList.itemList.Add(newItem);
        viewIndex = carList.itemList.Count;
    }

    void DeleteItem(int index)
    {
        carList.itemList.RemoveAt(index);
    }
*/
}