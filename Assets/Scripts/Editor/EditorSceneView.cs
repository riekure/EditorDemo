using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorSceneView
{
    [InitializeOnLoadMethod]
    static void AddDuringSceneGUI()
    {
        SceneView.duringSceneGui += SceneViewWindowItemOnGUI;
    }

    static void SceneViewWindowItemOnGUI(SceneView sceneView)
    {
		Handles.BeginGUI();
		var camera = sceneView.camera;
		var windowRect = sceneView.position;
		using (new GUILayout.AreaScope(new Rect(Vector2.zero, windowRect.size)))
		{
			using (new GUILayout.HorizontalScope(GUI.skin.box))
			{
				EditorGUILayout.LabelField("Camera Shortcut");
				if (GUILayout.Button("Sync"))
				{
					Undo.RecordObject(Camera.main.transform, "Camera Sync");
					Camera.main.transform.position = camera.transform.position;
					Camera.main.transform.rotation = camera.transform.rotation;
				}

				GUILayout.FlexibleSpace();
			}

			using (new GUILayout.HorizontalScope(GUI.skin.box))
			{
				EditorGUILayout.LabelField("Create Shortcut");
				if (GUILayout.Button("Cube"))
				{
					var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
					Undo.RegisterCreatedObjectUndo(cube, "Create Cube");
				}
				if (GUILayout.Button("Sphere"))
				{
					var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
					Undo.RegisterCreatedObjectUndo(sphere, "Create Sphere");
				}

				GUILayout.FlexibleSpace();
			}
		}
		Handles.EndGUI();
	}
}
