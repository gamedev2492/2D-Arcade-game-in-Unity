using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour {

	public GameObject allContainer;
	private float circleGroupX;
	public GameObject circleGroup;
	private float circleGroupSpeedLimit = 2f;
	public Transform ball;
	private float ballY;
	private float ballSpeed = 1f;
	public bool touched = false;
	private float circleGroupYLimit = 2.3f;
	private int numPlay;
	//private float circleGroupSpeedLimit
	private int score;
	private Text scoreT;

	public enum ObjectColor {
		Red = 0,
		Green = 1,
		Cyan = 2,
		Yellow = 3,
		Magenta = 4
	}

	void Awake() {
		//QualitySettings.vSyncCount = 0;
		//Application.targetFrameRate = 50;
	}

	void Start () {
		ResizeSpriteToScreen(allContainer);
		List<string> tempList = new List<string>();
		tempList.Add("Border");
		tempList.Add("Spike");
		ParentingAllFromContainer();

		//Debug.Log(Camera.main.GetComponent<Camera>().pixelWidth +" : "+ Camera.main.GetComponent<Camera>().pixelHeight);
		Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector2(Camera.main.GetComponent<Camera>().pixelWidth, Camera.main.GetComponent<Camera>().pixelHeight));
		//Debug.Log(pos);
		circleGroupX = pos.x;
		ballY = pos.y;
	}

	public void CircleGroupTweenStart() {
		int signInt = -1;

		if(Random.Range(0,2) == 1) {
			signInt = 1;
		}
		circleGroup.transform.position = new Vector3(0, 5.6f, 0);
		Vector3 dest = new Vector3(0,Random.Range(-circleGroupYLimit, circleGroupYLimit),0);

		circleGroup.transform.DOLocalMove(dest, 0.2f).SetEase(Ease.Linear).OnComplete(()=>{
			float speed;
			if(numPlay > 2)
				speed = Random.Range(0.8f,circleGroupSpeedLimit);
			else {
				numPlay++;
				speed = 2f;
			}
			Debug.Log(speed);
			circleGroup.transform.DOLocalMoveX(signInt*circleGroupX, speed/2).SetEase(Ease.Linear).OnComplete(()=>{

				circleGroup.transform.DOLocalMoveX(-signInt*circleGroupX, speed).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
			});
		});


	}

	void ResizeSpriteToScreen(GameObject fitMe)
	{
		SpriteRenderer sR = fitMe.GetComponent<SpriteRenderer>();
		if (sR == null) return;
		float width = sR.sprite.bounds.size.x;
		float height = sR.sprite.bounds.size.y;
		float worldScreenHeight = Camera.main.orthographicSize * 2f;
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
		float x1,y1,z1;
		x1 = worldScreenWidth / width;
		y1 = worldScreenHeight / height;
		z1 = fitMe.transform.localScale.z;
		fitMe.transform.localScale = new Vector3(x1, y1, z1);

	}

	void ParentingAllFromContainerByTag(List<string> allTags) {
		Transform[] childs = allContainer.GetComponentsInChildren<Transform>();
		foreach(Transform t in childs) {
			if(allTags.Contains(t.tag)) {
				t.parent = transform.root.parent;
			}	
		}
	}

	void ParentingAllFromContainer() {
		Transform[] childs = allContainer.GetComponentsInChildren<Transform>();
		foreach(Transform t in childs) {
			if(t.parent == allContainer.transform) {
//				Debug.Log(transform.root.name);
				t.parent = transform.root.parent;
			}	
		}
	}

	public void OnScreenClicked() {
		Debug.Log("Click");
		if(!touched) {
			touched = true;
			ball.transform.DOMoveY(ballY+2, ballSpeed).OnComplete(()=>{ //.SetEase(Ease.InExpo)
				//Debug.Log("ball moved");
			});
		}
	}

	public void UpdateScore() {
		score++;
		//scoreT.text = score.ToString();
	}

	public void SetScore() {
		PlayerPrefs.SetInt("LastScore", score);

		if(score > PlayerPrefs.GetInt("BestScore"))
			PlayerPrefs.SetInt("BestScore", score);
	}

	public void GameOver() {
		Debug.Log("GameOver");

		circleGroup.transform.DOKill(false);

		Camera.main.gameObject.GetComponent<CameraShake>().enabled = true;

		SetScore();
	}
}
