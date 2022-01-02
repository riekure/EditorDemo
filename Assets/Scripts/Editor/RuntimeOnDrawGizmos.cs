using UnityEditor;
using UnityEngine;

public class RuntimeOnDrawGizmos : MonoBehaviour
{
#if UNITY_EDITOR
    void OnDrawGizmos()
    {
		var sceneView = SceneView.currentDrawingSceneView;
		var position = this.transform.position;
		var labelPosition = position
			+ Vector3.down * 0.65f
			- sceneView.camera.transform.right * 0.45f;

		using (new Handles.DrawingScope(Color.white * 0.7f))
			Handles.SphereHandleCap(0, position, Quaternion.identity, 1f, Event.current.type);

		Handles.DrawWireCube(position, Vector3.one);
		Handles.Label(labelPosition, "ID : " + this.GetInstanceID());
	}
#endif
}
