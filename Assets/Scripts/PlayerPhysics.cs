using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class PlayerPhysics : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

	public Rigidbody2D playerR;

	public bool left, right;
	public Vector2 leftForce, rightForce, zeroForce;
	private float speed = 2.5f;
	private float gravityOfPlayer;

	private Vector2 touchPos;
	private float screenWidth;
	bool allowTouch;

	List<int> touchIDs = new List<int>();
	private float holdTime;
	private bool touchDown;
	public GameObject powerS;
	public bool powerActive;

	public static PlayerPhysics instance;
	private bool velocityWillChange;

	void Awake() {
		instance = this;
	}

	void Start() {
		gravityOfPlayer = playerR.gravityScale;
		allowTouch = true;
		screenWidth = Screen.width;

		leftForce = leftForce.normalized;
		rightForce = rightForce.normalized;

		velocityWillChange = true;
	}

	void Update() {
		if(allowTouch) {

			if(touchDown) {
				float t = Time.time - holdTime;
				//Debug.Log(t);
				if(t > 0.2f) {
					//Debug.Log("YAY!");
					powerS.SetActive(true);
					powerActive = true;
				}
			}
		}

		if(Input.GetKeyDown(KeyCode.A)) {
			if(allowTouch) {
				touchDown = true;
				holdTime = Time.time;

				left = true;

				playerR.velocity = speed/5f * playerR.velocity.normalized;

				playerR.gravityScale = 0f;
			}
		}

		if(Input.GetKeyDown(KeyCode.D)) {
			if(allowTouch) {
				touchDown = true;
				holdTime = Time.time;

				right = true;

				playerR.velocity = speed/5f * playerR.velocity.normalized;

				playerR.gravityScale = 0f;
			}
		}

		if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) {
			if(allowTouch) {
				//Debug.Log("OnPointerUp");
				touchDown = false;
				holdTime = 0f;

				if(powerS.activeSelf)
					powerS.SetActive(false);
				powerActive = false;

				left = false;
				right = false;

				playerR.gravityScale = gravityOfPlayer;
			}
		}

	}

	public virtual void OnPointerUp(PointerEventData pData) {
		
		if(allowTouch) {
			//Debug.Log("OnPointerUp");
			touchDown = false;
			holdTime = 0f;

			if(powerS.activeSelf)
				powerS.SetActive(false);
			powerActive = false;

			left = false;
			right = false;

			playerR.gravityScale = gravityOfPlayer;
		}

	}

	public virtual void OnPointerDown(PointerEventData pData) {
		
		//Debug.Log(pData.pointerId);

		if(allowTouch) {
			velocityWillChange = true;
			touchDown = true;
			holdTime = Time.time;


			// REMAINING CODE START
			// pointerID is used here for discarding other touches other than first
			if(!touchIDs.Contains(pData.pointerId)) {
				touchIDs.Add(pData.pointerId);
			}
			//END


			touchPos = pData.position;

			if(touchPos.x < screenWidth/2) {
				//Debug.Log("Left");
				left = true;
			} else {
				//Debug.Log("Right");
				right = true;
			}

			if(left && velocityWillChange) {
				playerR.velocity = speed*leftForce*3f;

				Debug.Log("LeftV");
				velocityWillChange = false;

			} else if(right && velocityWillChange) {
				playerR.velocity = speed*rightForce*3f;
				Debug.Log("RightV");
				velocityWillChange = false;
			}

			playerR.gravityScale = 0f;
		}

	}

//	void OnGUI() {
//		foreach(int i in touchIDs) {
//			GUILayout.Button(i.ToString());
//		}
//	}
}
