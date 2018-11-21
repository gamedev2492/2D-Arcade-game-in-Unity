using UnityEngine;
using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	public GamePlayManager.ObjectColor ballColor;
	public GameObject[] circles;
	private List<int> randomCircle = new List<int>();
	private Color[] randomColor;
	public GamePlayManager gPM;
	private float pullForce = 7;
	private bool inCircle;
	private Collider2D circleCollider;
	private Vector3 ballStartPosition;
	private PositionAndCountDown pCD;
	public GameObject[] otherObjectsForColor;
	public Text scoreText;

	System.Random rand = new System.Random();
	public void Shuffle(List<int> deck) //http://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
	{
		for (int n = deck.Count - 1; n > 0; --n)
		{
			int k = rand.Next(n + 1);
			int temp = deck[n];
			deck[n] = deck[k];
			deck[k] = temp;
		}
	}

	void Start () {

		pCD = GetComponentInChildren<PositionAndCountDown>();

		ballStartPosition = transform.position;

		FillVariables();

		gPM.CircleGroupTweenStart();
		InitiateNewGroup();
		SetObjectColors();
	}

	void InitiateNewGroup() {
		Shuffle(randomCircle);

		ballColor = (GamePlayManager.ObjectColor) UnityEngine.Random.Range(0, circles.Length);


		for(int i = 0; i < circles.Length; i++) circles[i].GetComponent<Circle>().myColor = (GamePlayManager.ObjectColor)randomCircle[i];
	}

	void FillVariables() {
		randomColor = new Color[circles.Length];

		ColorUtility.TryParseHtmlString ("#FBE365FF", out randomColor[0]);
		ColorUtility.TryParseHtmlString ("#F069F0FF", out randomColor[1]);
		ColorUtility.TryParseHtmlString ("#50F7E6FF", out randomColor[2]);
		ColorUtility.TryParseHtmlString ("#23FB23FF", out randomColor[3]);
		ColorUtility.TryParseHtmlString ("#FF7347FF", out randomColor[4]);


		for(int i = 0; i < circles.Length; i++) randomCircle.Add(i);

	}
	
	void SetObjectColors() {
		GetComponent<SpriteRenderer>().color = randomColor[(int)ballColor];
		GetComponentInChildren<TextMesh>().color = randomColor[(int)ballColor];

		for(int i = 0; i < circles.Length; i++) 
			circles[i].GetComponent<SpriteRenderer>().color = randomColor[(int)circles[i].GetComponent<Circle>().myColor];

		for(int i = 0; i < otherObjectsForColor.Length; i++) 
			otherObjectsForColor[i].GetComponent<SpriteRenderer>().color = randomColor[(int)ballColor];

		scoreText.color = randomColor[(int)ballColor];
	}

	void ReSetObjectColors() {
		GetComponent<SpriteRenderer>().color = Color.white;

		for(int i = 0; i < circles.Length; i++) 
			circles[i].GetComponent<SpriteRenderer>().color = Color.white;

		for(int i = 0; i < otherObjectsForColor.Length; i++) 
			otherObjectsForColor[i].GetComponent<SpriteRenderer>().color = Color.white;

		scoreText.color = Color.white;
	}

	void OnTriggerEnter2D(Collider2D col) {

		if(col.CompareTag("Circle")) {
			Debug.Log("Circle");
			gPM.circleGroup.transform.DOKill(false);

			for(int i = 0; i < circles.Length; i++) {
				circles[i].GetComponent<Collider2D>().enabled = false;
			}

			circleCollider = col;
			transform.DOKill(false);
			Vector3 temp = circleCollider.transform.position - transform.position;
			Vector2 forceDirection = new Vector2(temp.x, temp.y);
			GetComponent<Rigidbody2D>().velocity = forceDirection.normalized * pullForce;

			inCircle = true;
		}
		else if(col.CompareTag("Spike") && !inCircle) {
			Debug.Log("Spike");
			transform.DOKill(false);

			for(int i = 0; i < circles.Length; i++) {
				circles[i].GetComponent<Collider2D>().enabled = false;
			}

			gPM.GameOver();
		}
	}

	void FixedUpdate() {
		if(inCircle) {

			Vector3 temp = circleCollider.transform.position - transform.position;
			if(temp.magnitude < 0.1f) {
				inCircle = false;
				GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				transform.position = circleCollider.transform.position;

				gPM.circleGroup.transform.parent = transform;

				//Sequence mySequence = DOTween.Sequence();

				transform.DOMoveX(0, 0.3f).OnComplete(()=>{ //.SetEase(Ease.InExpo)
					Debug.Log("ball centered");

					gPM.circleGroup.transform.parent = transform.parent;

					int tempI = (int)circleCollider.GetComponent<Circle>().myColor;
					if(ballColor == circleCollider.GetComponent<Circle>().myColor) {
						Debug.Log("Win");

						ReSetObjectColors();
						InitiateNewGroup();


						transform.DOMoveY(ballStartPosition.y, 0.5f).OnComplete(()=>{ //.SetEase(Ease.InExpo)

							for(int i = 0; i < circles.Length; i++) {
								circles[i].GetComponent<Collider2D>().enabled = true;
							}

							gPM.touched = false;

							pCD.ResetTime();
						});

						gPM.circleGroup.transform.DOLocalMove(new Vector3(0, -5.6f, 0), 0.2f).SetEase(Ease.Linear).OnComplete(()=>{
							gPM.CircleGroupTweenStart();
							SetObjectColors();
						});


						gPM.UpdateScore();
					}else {
						Debug.Log("Lose");
						gPM.GameOver();
						//UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
					}
				});

				circleCollider.transform.DORotate(new Vector3(0,0,360), 0.3f, RotateMode.FastBeyond360).SetEase(Ease.Linear).OnComplete(()=>{ //.SetEase(Ease.InExpo)
					Debug.Log("circle rotated");
					Debug.Log(circleCollider.transform.localEulerAngles);
					circleCollider.transform.rotation = Quaternion.identity;

				});
			}
		}
	}
}
