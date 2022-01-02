using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

[EditorTool(displayName: "Original Tool", typeof(MyComponent))]
public class EditorToolOriginal : EditorTool
{
	[SerializeField]
	private Texture2D iconImage;

	public override GUIContent toolbarIcon => new GUIContent()
	{
		image = iconImage,
		text = "Original Tool",
		tooltip = "Movable Y-Axis",
	};

	public override void OnToolGUI(EditorWindow window)
	{
		using (var check = new EditorGUI.ChangeCheckScope())
		{
			Vector3 position = Tools.handlePosition;

			using (new Handles.DrawingScope(Color.magenta))
				position = Handles.Slider(position, Vector3.up);

			if (check.changed)
			{
				Vector3 delta = position - Tools.handlePosition;

				Undo.RecordObjects(Selection.transforms, "Move Transform");

				foreach (var transform in Selection.transforms)
					transform.position += delta;
			}
		}
	}
}
