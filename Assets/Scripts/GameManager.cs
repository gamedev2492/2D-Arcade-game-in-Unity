using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject[] instantiatedObstacles;
	public GameObject obstacle;

	private int toBePositionedNext;
	private float minXPos, maxXPos;
	public GameObject allContainer;

	private int points = 0;
	public Text pointText;

	public static GameManager instance;

	private float currentYposOfInst = -12f;

	public enum ObstacleType {
		Static = 0,
		Round = 1,
		MoveScreen = 2,
		MoveMain = 3,
		FromToScreen = 4,
		Bomb = 5
	}
	public ObstacleType currentObstacleType;
	public float[] randomObstacleLimit;
	public GameObject[] randomObstacles;
	private GameObject[,] instantiatedRandomObstacles;
	public int[] toBeSpawned;
	private byte onscreenObstLimit = 8;

	void Awake() {
		instance = this;

		instantiatedRandomObstacles = new GameObject[System.Enum.GetNames(typeof(ObstacleType)).Length, onscreenObstLimit];
		ResizeSpriteToScreen(allContainer);
		List<string> tempList = new List<string>();
		tempList.Add("Border");
		tempList.Add("Spike");
		ParentingAllFromContainerByTag(tempList);

		PositionAtRandom();
		PositionAtRandom();
	}

	// Use this for initialization
	void Start () {
		//Debug.Log(obstaclePiece.transform.localScale.x);
		minXPos = obstacle.transform.Find("Obstacle").localScale.x*(-1f/3f);
		maxXPos = obstacle.transform.Find("Obstacle").localScale.x*(1f/3f);

		//Debug.Log("minXPos : "+minXPos+ "--"+ "maxXPos : "+maxXPos);

		UpdatePoints(0);
	}

	public void StartTimerPointUpdate() {
		InvokeRepeating("TimerPointUpdate", 0, 0.25f);
	}

	void TimerPointUpdate() {
		UpdatePoints(1);
	}

	public void PositionAtRandom() {
		//Debug.Log(toBePositionedNext);
		currentYposOfInst += 12f;
		
		Vector3 position = new Vector3(Random.Range(minXPos, maxXPos), currentYposOfInst, 0);
		instantiatedObstacles[toBePositionedNext] = SpawnAndPosition(instantiatedObstacles[toBePositionedNext], obstacle, position);
		instantiatedObstacles[toBePositionedNext].transform.Find("Point").GetComponent<EdgeCollider2D>().enabled = true;

		float Ypos1 = currentYposOfInst + 3;
		float Ypos2 = currentYposOfInst + 9;

		//FirstObstacle
		Vector3 position1 = new Vector3(Random.Range(-randomObstacleLimit[0], randomObstacleLimit[0]), Ypos1, 0);
		instantiatedRandomObstacles[0, toBeSpawned[0]] = SpawnAndPosition(instantiatedRandomObstacles[0, toBeSpawned[0]], randomObstacles[0], position1);
		toBeSpawned[0]++;
		if(toBeSpawned[0] == onscreenObstLimit)
			toBeSpawned[0] = 0;

		//SecondObstacle
//		Vector3 position2 = new Vector3(Random.Range(-randomObstacleLimit[1], randomObstacleLimit[1]), Ypos2, 0);
//		instantiatedRandomObstacles[1, toBeSpawned[1]] = SpawnAndPosition(instantiatedRandomObstacles[1, toBeSpawned[1]], randomObstacles[1], position2);
//		toBeSpawned[1]++;
//		if(toBeSpawned[1] == onscreenObstLimit)
//			toBeSpawned[1] = 0;

		toBePositionedNext++;
		if(toBePositionedNext == 4)
			toBePositionedNext = 0;

		//Debug.Log(toBePositionedNext+1);
	}

	GameObject SpawnAndPosition(GameObject instG, GameObject toInstG, Vector3 toPos) {
		if(instG == null) {
			instG = Instantiate(toInstG, Vector3.zero, Quaternion.identity) as GameObject;
			instG.transform.parent = allContainer.transform;

		}
		instG.transform.localPosition = toPos;
		//Debug.Log(instG.name);
		return instG;
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
				t.parent = Camera.main.transform;
			}	
		}
	}

	public void UpdatePoints(int incr) {
		points += incr;
		pointText.text = points.ToString();
	}
}
