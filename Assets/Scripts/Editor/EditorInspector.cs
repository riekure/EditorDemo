using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MyComponent))]
public class EditorInspector : Editor
{
    void OnSceneGUI()
    {
        var sceneView = SceneView.currentDrawingSceneView;
        var component = this.target as MyComponent;
        var position = component.transform.position;

        var screenPos = sceneView.camera.WorldToViewportPoint(position);
        var size = new Vector2(60f, EditorGUIUtility.singleLineHeight);
        var rect = new Rect(
            sceneView.position.width * screenPos.x - size.x * 0.5f,
            sceneView.position.height * (1f - screenPos.y) + size.y * 0.5f,
            size.x,
            size.y);

        Handles.BeginGUI();
        EditorGUI.LabelField(rect, "ID: " + component.GetInstanceID());
        var windowRect = sceneView.position;
        using (new GUILayout.AreaScope(new Rect(Vector2.zero, windowRect.size)))
        {
            using (new GUILayout.HorizontalScope(GUI.skin.box))
            {
                GUILayout.Label("MyComponent ‚ðŠÜ‚ñ‚¾ GameObject ‚ð‘I‘ð‚µ‚Ä‚¢‚Ü‚·");
            }
        }
        Handles.EndGUI();
    }
}
