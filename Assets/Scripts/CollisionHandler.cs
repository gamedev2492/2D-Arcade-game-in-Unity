using UnityEngine;
using System.Collections;

public class CollisionHandler : MonoBehaviour {
	public Transform leftP, rightP;

//	void OnCollisionEnter2D(Collision2D col) {
//
//		//Debug.Log("OnCollisionEnter2D : "+col.collider.gameObject.name);
//
//	}

	void OnTriggerEnter2D(Collider2D col) {
		if(col.CompareTag("Point")) {
			GameManager.instance.UpdatePoints(5);
			GameManager.instance.PositionAtRandom();

			col.gameObject.GetComponent<EdgeCollider2D>().enabled = false;
		}

		if(col.CompareTag("Border")) {
			//Debug.Log("Border");
			if(col.gameObject.name == "LeftSensor") {
				//Debug.Log("BorderRight");
				this.transform.position = new Vector3(rightP.position.x, this.transform.position.y, rightP.position.z);
			}
			else if(col.gameObject.name == "RightSensor") {
				//Debug.Log("BorderLeft");
				this.transform.position = new Vector3(leftP.position.x, this.transform.position.y, leftP.position.z);
			}
		}

		if(col.gameObject.CompareTag("Spike") || col.gameObject.CompareTag("PrimaryObstacle")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene(0);
		}
		if(col.gameObject.CompareTag("Obstacle")) {
			if(!PlayerPhysics.instance.powerActive) {
				Debug.Log("are yar");
				UnityEngine.SceneManagement.SceneManager.LoadScene(0);
			}
			else {
				Debug.Log("lai le le");
				GameManager.instance.UpdatePoints(10);
				Destroy(col.gameObject);
			}
		}
	}
}
