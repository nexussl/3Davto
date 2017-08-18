using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class ManufacturerEditor : EditorWindow
{
    //private int viewIndex = 1;

    
    Manufacturer manufacturer;

    public string manufacturerTitle;
    public Texture2D manufacturerLogo;

    [MenuItem("Window/Cars/Manufacturer Editor %#e")]
    static void Init()
    {
        EditorWindow.GetWindow(typeof(ManufacturerEditor));
    }

    void OnEnable()
    {
        if (EditorPrefs.HasKey("ObjectPath"))
        {
            string objectPath = EditorPrefs.GetString("ObjectPath");
            manufacturer = AssetDatabase.LoadAssetAtPath(objectPath, typeof(Manufacturer)) as Manufacturer;
        }

    }

    /*
    void OnLostFocus()
    {
        manufacturer = null;
        manufacturerTitle = "";
        manufacturerLogo = null;
    }
    */


    void OnGUI()
    {
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("Manufacturer Editor", EditorStyles.boldLabel);
        if (manufacturer != null)
        {
            if (GUILayout.Button("Show Manufacturer"))
            {
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = manufacturer;
                manufacturerTitle = manufacturer.title;
                manufacturerLogo = manufacturer.logo;
            }
        }
        if (GUILayout.Button("Open Manufacturer"))
        {
            OpenManufacturer();
        }
        if (GUILayout.Button("New Manufacturer"))
        {
            manufacturer = null;
            manufacturerTitle = "";
            manufacturerLogo = null;
            /*
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = manufacturer;
            */
        }


        GUILayout.EndHorizontal();

        if (manufacturer == null)
        {
            //GUILayout.BeginVertical();
            //GUILayout.Space(10);

            manufacturerTitle = EditorGUILayout.TextField("Title", manufacturerTitle, GUILayout.ExpandWidth(false), GUILayout.Width(250));
            manufacturerLogo = EditorGUILayout.ObjectField("Logo", manufacturerLogo, typeof(Texture2D), false, GUILayout.Height(100), GUILayout.Width(250)) as Texture2D;
            
            if (GUILayout.Button("Create Manufacturer", GUILayout.ExpandWidth(true)))
            {
                if (manufacturerTitle != "" && manufacturerLogo != null) {
                    CreateNewManufacturer(manufacturerTitle, manufacturerLogo);
                }
                else {
                    EditorUtility.DisplayDialog("Create manufacturer failed", "Please fil manufacturer Name and Logo", "Ok");
                }
            }
            if (GUILayout.Button("Open Existing Manufacturer", GUILayout.ExpandWidth(true)))
            {
                OpenManufacturer();
            }
            //GUILayout.EndVertical();
        }



        if (manufacturer != null)
        {
            manufacturerTitle = EditorGUILayout.TextField("Title", manufacturerTitle, GUILayout.ExpandWidth(false), GUILayout.Width(250));
            manufacturerLogo = EditorGUILayout.ObjectField("Logo", manufacturerLogo, typeof(Texture2D), false, GUILayout.Height(100), GUILayout.Width(250)) as Texture2D;

            if (GUILayout.Button("Save", GUILayout.ExpandWidth(true)))
            {

                if (manufacturerTitle != "" && manufacturerLogo != null)
                {
                    manufacturer.title = EditorGUILayout.TextField("Title", manufacturerTitle, GUILayout.ExpandWidth(false), GUILayout.Width(250));
                    manufacturer.logo = EditorGUILayout.ObjectField("Logo", manufacturerLogo, typeof(Texture2D), false, GUILayout.Height(100), GUILayout.Width(250)) as Texture2D;
                    AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(manufacturer), manufacturer.title);
                }
                else
                {
                    EditorUtility.DisplayDialog("Save manufacturer failed", "Please fil manufacturer Name and Logo", "Ok");
                }

            }
            
            
        }
        if (GUI.changed)
        {
            if (manufacturer != null)
            {
                EditorUtility.SetDirty(manufacturer);
            }
        }
    }





    void CreateNewManufacturer(string title, Texture2D logo)
    {
        // There is no overwrite protection here!
        // There is No "Are you sure you want to overwrite your existing object?" if it exists.
        // This should probably get a string from the user to create a new name and pass it ...
        //viewIndex = 1;s
        manufacturer = CreateManufacturer.Create(manufacturerTitle, logo) ;
        if (manufacturer)
        {
            string relPath = AssetDatabase.GetAssetPath(manufacturer);
            EditorPrefs.SetString("ObjectPath", relPath);
        }
    }

    void OpenManufacturer()
    {
        string absPath = EditorUtility.OpenFilePanel("Select Manufacturer", "", "");
        if (absPath.StartsWith(Application.dataPath))
        {
            string relPath = absPath.Substring(Application.dataPath.Length - "Assets".Length);
            manufacturer = AssetDatabase.LoadAssetAtPath(relPath, typeof(Manufacturer)) as Manufacturer;
            manufacturerTitle = manufacturer.title;
            manufacturerLogo = manufacturer.logo;
            if (manufacturer)
            {
                EditorPrefs.SetString("ObjectPath", relPath);
            }
        }
    }

    /*
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