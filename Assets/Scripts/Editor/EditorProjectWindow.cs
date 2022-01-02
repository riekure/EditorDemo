using UnityEngine;
using UnityEditor;

public class EditorProjectWindow : MonoBehaviour
{
    [InitializeOnLoadMethod]
    static void AddProjectWindowItemOnGUI()
    {
        EditorApplication.projectWindowItemOnGUI += ProjectWindowItemOnGUI;
    }

    static void ProjectWindowItemOnGUI(string guid, Rect selectionRect)
    {
        Rect rect = selectionRect;
        rect.x = rect.xMax - 120f;
        rect.width = 110f;

        if (GUI.Button(rect, "Copy Path"))
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            EditorGUIUtility.systemCopyBuffer = path;
        }
    }
}
