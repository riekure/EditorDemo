using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorPopupChecker : EditorWindow
{
	[MenuItem("Window/Demo/PopupWindow")]
	static public void CreateWindow()
	{
		EditorWindow.GetWindow<EditorPopupChecker>();
	}

	void OnGUI()
	{
		var rect = new Rect(0f, 0f, 200f, 20f);
		if (GUI.Button(rect, "Show PopupWindow"))
			PopupWindow.Show(rect, new EditorPopupWindow());
	}
}

public class EditorPopupWindow : PopupWindowContent
{
	public override Vector2 GetWindowSize() => new Vector2(300f, 62f);

	public override void OnOpen() => Debug.Log("PopupWindow OnOpen");
	public override void OnClose() => Debug.Log("PopupWindow OnClose");

	public override void OnGUI(Rect rect)
	{
		GUILayout.Label("This is PopupWindow!!");
		GUILayout.Label("GUI Sample");

		using (new GUILayout.HorizontalScope())
		{
			GUILayout.Button("Select", EditorStyles.miniButtonLeft);
			GUILayout.Button("Revert", EditorStyles.miniButtonMid);
			GUILayout.Button("Save", EditorStyles.miniButtonRight);
		}
	}
}
