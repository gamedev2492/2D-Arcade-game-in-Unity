using UnityEngine;
using System.Collections;

public class OfsettedCameraFollow : MonoBehaviour {

	public Transform target;
	public float damping = 1;
	public float offsetY = 3.0f;
	private Vector3 m_LastTargetPosition;
	private Vector3 m_CurrentVelocity;

	// Use this for initialization
	private void Start()
	{
		transform.parent = null;
		m_LastTargetPosition = transform.position;
	}


	// Update is called once per frame
	void FixedUpdate() {
		float yDist = target.position.y - transform.position.y;
		//Debug.Log(yDist);

		if(yDist > offsetY) {
			m_LastTargetPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);
		}
		transform.position = Vector3.SmoothDamp(transform.position, m_LastTargetPosition, ref m_CurrentVelocity, damping);
	}
}
