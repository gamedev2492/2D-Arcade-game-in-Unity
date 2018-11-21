using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickRoundScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler {

    Image bgImage, jSImage;
    public Vector2 inputV;
    public float speed;
	public Rigidbody2D characterR;
	public static JoystickRoundScript instance;

	void Awake() {
		instance = this;
	}

	void Start () {
	    bgImage = GetComponent<Image>();
		jSImage = transform.Find("TouchHolder").GetComponent<Image>();
	}

	void LateUpdate() {
		characterR.velocity = new Vector2(Horizontal(), Vertical());
	}

    public virtual void OnPointerUp(PointerEventData pData) {
		inputV = Vector2.zero;
		jSImage.rectTransform.anchoredPosition = inputV;
    }

    public virtual void OnPointerDown(PointerEventData pData)
    {
        //OnDrag(pData);
    }

    public virtual void OnDrag(PointerEventData pData)
    {
		if(true) {
			Vector2 pos;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImage.rectTransform, pData.position, pData.pressEventCamera, out pos)) {

				pos.x = (pos.x / bgImage.rectTransform.sizeDelta.x) * 2;
				pos.y = (pos.y / bgImage.rectTransform.sizeDelta.y) * 2;

				inputV = new Vector2(pos.x, pos.y);

				inputV = (inputV.magnitude > 1.0f) ? inputV.normalized : inputV;

				jSImage.rectTransform.anchoredPosition = new Vector2(inputV.x * (bgImage.rectTransform.sizeDelta.x / 2), inputV.y * (bgImage.rectTransform.sizeDelta.y / 2));
				jSImage.rectTransform.anchoredPosition = new Vector2(inputV.x * (bgImage.rectTransform.sizeDelta.x / 2), 
					jSImage.rectTransform.anchoredPosition.y);
			}
		}
    }

    public float Horizontal() {
		if (inputV.x != 0f)
			return inputV.x * speed;
		else
			return Input.GetAxis("Horizontal") * speed;
    }

    public float Vertical()
    {
        if (inputV.y != 0f)
            return inputV.y * speed;
        else
            return Input.GetAxis("Vertical") * speed;
    }
}
