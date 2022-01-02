using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorProjectSettings : SettingsProvider
{
	EditorProjectSettings(string path, SettingsScope scope) : base(path, scope) { }

	[SettingsProvider]
	static private SettingsProvider CreateSettingsProvider()
	{
		return new EditorProjectSettings("Original/General", SettingsScope.Project)
		{
			keywords = new HashSet<string>(new[] { "Original", "Shortcut" })
		};
	}

	public override void OnGUI(string searchContext)
	{
		EditorGUILayout.Toggle("Enable Shortcut", true);
	}
}
