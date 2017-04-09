using UnityEngine;
using System.Collections;

public class WorldCursor : MonoBehaviour {
	private MeshRenderer meshRenderer;

	public Camera _camera;

	// Use this for initialization
	void Start () {
		// Grab the mesh renderer that's on the same object as this script.
		meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (this._camera == null)
			return;
		
		var headPosition = this._camera.transform.position;
		var gazeDirection = this._camera.transform.forward;

		RaycastHit hitInfo;
		if (Physics.Raycast (headPosition, gazeDirection, out hitInfo)) {
			meshRenderer.enabled = true;
			this.transform.position = hitInfo.point;
			this.transform.rotation = Quaternion.FromToRotation (Vector3.up, hitInfo.normal);
		} else {
			meshRenderer.enabled = false;
		}
	}
}
