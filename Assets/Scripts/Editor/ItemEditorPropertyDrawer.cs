using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ItemData.Item))]
public class ItemEditorPropertyDrawer : PropertyDrawer
{
	private Vector2 layout;
	private Rect prefixRect;

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		return EditorGUIUtility.singleLineHeight * 5.5f;
	}

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		this.layout = Vector2.zero;
		var idProperty = property.FindPropertyRelative("id");
		var nameProperty = property.FindPropertyRelative("name");
		var captionProperty = property.FindPropertyRelative("caption");
		var typeProperty = property.FindPropertyRelative("type");

		using (new EditorGUI.PropertyScope(position, label, property))
		{
			position = prefixRect = EditorGUI.PrefixLabel(position, label);
			position.height = EditorGUIUtility.singleLineHeight;

			Rect propRect;
			EditorGUIUtility.labelWidth = 50f;

			propRect = MakeRect(0f, 0.5f, -10f, in position);
			EditorGUI.PropertyField(propRect, idProperty, new GUIContent("ID"));

			propRect = MakeRect(10f, 0.5f, 0f, in position);
			EditorGUI.LabelField(propRect, "Type");
			EditorGUI.PropertyField(propRect, typeProperty);

			propRect = MakeRectWithNewLine(0f, 1f, 0f, in position);
			EditorGUI.PropertyField(propRect, nameProperty);

			propRect = MakeRectWithNewLine(0f, 1f, 0f, in position);
			propRect.height = EditorGUIUtility.singleLineHeight * 3f;
			propRect = EditorGUI.PrefixLabel(propRect, new GUIContent("Caption"));
			var text = EditorGUI.TextArea(propRect, captionProperty.stringValue);
			captionProperty.stringValue = text;
		}
	}

	Rect MakeRect(float widthStartOffset, float widthEndRatio, float widthEndOffset, in Rect position)
	{
		Rect work = position;
		work.y = prefixRect.yMin + this.layout.y;
		work.xMin = prefixRect.xMin + this.layout.x + widthStartOffset;
		work.width = position.width * widthEndRatio + widthEndOffset;
		this.layout.x += work.width;
		return work;
	}

	Rect MakeRectWithNewLine(float widthStartOffset, float widthEndRatio, float widthEndOffset, in Rect position)
	{
		this.layout.x = 0f;
		this.layout.y += EditorGUIUtility.singleLineHeight + 2f;
		return MakeRect(widthStartOffset, widthEndRatio, widthEndOffset, in position);
	}
}
