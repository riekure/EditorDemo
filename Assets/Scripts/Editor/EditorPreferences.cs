using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorPreferences : SettingsProvider
{
	EditorPreferences(string path, SettingsScope scope) : base(path, scope) { }

	[SettingsProvider]
	static private SettingsProvider CreateSettingsProvider()
	{
		return new EditorPreferences("Original/General", SettingsScope.User)
		{
			keywords = new HashSet<string>(new[] { "Original", "Color" })
		};
	}

	public override void OnGUI(string searchContext)
	{
		EditorGUILayout.Toggle("Enable Shortcut", true);
	}
}
