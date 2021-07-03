using UnityEngine;
using UnityEditor;

public class UIEditor : EditorWindow
{
    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;

    [MenuItem("Window/UI Editor")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(UIEditor));
    }

    void OnGUI()
    {
        if (GUILayout.Button("Encapsulate children"))
        {

        }
    }
}