using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Circle : MonoBehaviour {

	public GamePlayManager.ObjectColor myColor;

	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D col) {
		//Debug.Log(""+col.name);
		//Time.timeScale = 0;


	}
}
