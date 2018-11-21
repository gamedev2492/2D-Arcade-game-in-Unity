using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PositionAndCountDown : MonoBehaviour {

	public Transform ball;
	//public RectTransform canvasRect;
	//private RectTransform thisRect;
	private int seconds = 10;
	private float decreaseRate = 1f;
	public GamePlayManager gPM;

	void Start () {
		Vector2 viewPos = Camera.main.WorldToViewportPoint(ball.position);
		//thisRect = GetComponent<RectTransform>();

		ResetTime();
	}

	void UpdateTime() {
		Debug.Log("UpdateTime");
		if(gPM.touched)
			CancelInvoke("UpdateTime");
		else {
			seconds--;
			GetComponent<TextMesh>().text = seconds.ToString();

			if(seconds == 0) {

				CancelInvoke("UpdateTime");



				gPM.GameOver();
			}
		}
	}
	
//	// Update is called once per frame
//	void Update () {
//		Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, ball.position);
//
//		thisRect.anchoredPosition = screenPoint - canvasRect.sizeDelta / 2f;
//	}

	public void ResetTime() {
		seconds = 10;
		GetComponent<TextMesh>().text = seconds.ToString();
		InvokeRepeating("UpdateTime", decreaseRate, decreaseRate);

		decreaseRate /= 1.05f;
		if(decreaseRate < 0.5f)
			decreaseRate = 0.5f;
		Debug.Log(decreaseRate);
	}
}
