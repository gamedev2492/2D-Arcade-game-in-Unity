using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TweeningHandler : MonoBehaviour {

	public static TweeningHandler instance;

	void Awake() {
		instance = this;
	}

	void Start () {

	}

	public void SlideAnything(Vector2 targetPosition, GameObject gO, string fName){
//		iTween.ValueTo(gO, iTween.Hash(
//			"from", gO.GetComponent<RectTransform>().anchoredPosition,
//			"to", targetPosition,
//			"time", .2f,
//			"onupdatetarget", this.gameObject, 
//			"onupdate", fName
//		));
	}

	public void MoveAnything(Vector2 position){
//		welcomeHome.GetComponent<RectTransform>().anchoredPosition = position;
	}
}
