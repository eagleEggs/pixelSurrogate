using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(pixelSurrogateController))]
public class pixelSurrogateEditor : Editor
{

    private GUIStyle miniLabelStyle = new GUIStyle();


    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();


        pixelSurrogateController matGate = (pixelSurrogateController)target;
        miniLabelStyle.wordWrap = true;
        GUILayout.Space(6);
        EditorGUILayout.LabelField("General Controls", EditorStyles.boldLabel);
        GUILayout.Label("Texture to Pixels Settings");
        EditorGUILayout.BeginVertical("Box");
        GUILayout.Label("Select your Source Texture, Click Update, then Hatchemall. This will store the Width and Height of the texture for you. WARNING: Using anything other than Quads or a texture over 128x128 may freeze. This will generate a lot of objects in the scene!", miniLabelStyle);
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical("Box");
        if (GUILayout.Button("Update"))
        {
            matGate.updateWH();
        }
        if (GUILayout.Button("Hatchemall"))
        {
            matGate.hatchemall();
        }
        EditorGUILayout.EndVertical();





    }




}