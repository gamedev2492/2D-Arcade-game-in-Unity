using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class StartTheGame : MonoBehaviour, IPointerDownHandler {

	public GameObject startSprite;

	public virtual void OnPointerDown(PointerEventData pData) {
		PlayerPhysics.instance.playerR.isKinematic = false;
		startSprite.GetComponent<UnityEngine.UI.Image>().CrossFadeAlpha(0, 0.5f, true);
		Invoke("DestroyThis", 1f);
		GameManager.instance.allContainer.GetComponent<CameraUpwords>().enabled = true;
		GameManager.instance.StartTimerPointUpdate();
	
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) {
			PlayerPhysics.instance.playerR.isKinematic = false;
			startSprite.GetComponent<UnityEngine.UI.Image>().CrossFadeAlpha(0, 0.5f, true);
			Invoke("DestroyThis", 1f);
			GameManager.instance.allContainer.GetComponent<CameraUpwords>().enabled = true;
			GameManager.instance.StartTimerPointUpdate();
		}
	}

	void DestroyThis() {
		Destroy(startSprite);
		Destroy(this);
	}
}
