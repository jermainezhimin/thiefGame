using UnityEngine;
using System.Collections;

public class CameraTarget : MonoBehaviour {
	private Camera camera;

	protected void Start () {
		camera = Camera.main;
	}

	protected void Update () {
		camera.transform.position = new Vector3 (transform.position.x,
		                                         transform.position.y,
		                                         camera.transform.position.z);
	}
}
