using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorHierarchy : MonoBehaviour
{
    [InitializeOnLoadMethod]
    static void AddHierarchyItemOnGUI()
    {
        EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItemOnGUI;
    }

    static void HierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
    {
        		Rect rect = selectionRect;
		rect.x = rect.xMax - 120f;
		rect.width = 110f;

		if (GUI.Button(rect, "Add Component"))
		{
			var selectedGameObj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
			var add = selectedGameObj?.AddComponent<MyComponent>();
			Undo.RegisterCreatedObjectUndo(add, "Add MyComponent");
		}
    }
}
