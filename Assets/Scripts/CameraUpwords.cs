using UnityEngine;
using System.Collections;

public class CameraUpwords : MonoBehaviour {

	private float cameraSpeed = 1.5f;
	private float maxCameraSpeed = 5f;
	private Vector3 currentV;

	void Start() {
		//InvokeRepeating("UpdateSpeed", 5f, 5f);
	}

	void UpdateSpeed() {
		cameraSpeed *= 1.05f;
		//Debug.Log("cameraSpeed : "+cameraSpeed);
		if(cameraSpeed >= maxCameraSpeed) {
			cameraSpeed = maxCameraSpeed;
			CancelInvoke("UpdateSpeed");
		} 
			
	}
	
	void Update() {
		//transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime * cameraSpeed, transform.position.z);
	}
}
