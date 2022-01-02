using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyComponentAttibute : PropertyAttribute { }

public class MyComponent : MonoBehaviour
{

	public int hoge;

	[SerializeField, MyComponentAttibute]
	private float editorPropertyDrawer;

	[SerializeField]
	private ItemData.Item item;

	[Header("Built'in PropertyDrawer(Attribute)")]
	[SerializeField, Range(0.0f, 10.0f)]
	private float range;

	[SerializeField, Min(0.5f)]
	private float min;

	[Space(30f)]
	[SerializeField, Multiline(3)]
	private string multiline;

	[SerializeField, TextArea(2, 3)]
	private string textarea;

	[SerializeField, Tooltip("This is tooltip")]
	private int tooltip;
}
