using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuComponent : MonoBehaviour
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("This/is/My MenuItem")]
    static void MenuItem() => Debug.Log("Clicked MyMenuItem");
	[UnityEditor.MenuItem("This/will/Do!! %#&D")]
	static void Do() => Debug.Log("Clicked My MenuItem");
#endif

	[UnityEngine.ContextMenu("My ContextMenu")]
	void ContextMenu() => Debug.Log("Clicked My ContextMenu");

	[UnityEngine.ContextMenuItem("My ContextMenuItem", nameof(ContextMenuItem))]
	public float parameter;

	void ContextMenuItem() => Debug.Log("Clicked My ContextMenuItem");
}
