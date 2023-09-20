//Simple class to display a color
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ColorSwatch : MonoBehaviour {

	SpriteRenderer Sprite;
	[System.Serializable]
	public class SimpleEvent : UnityEvent { };
	// ...
	public SimpleEvent OnColorChange = new SimpleEvent();
	public Color Color { 
		/*get { return Sprite.color; } 
		set { Sprite.color = value; }*/
		get { return Sprite.color; }
		set
		{
			if (Sprite.color == value) return;
			Sprite.color = value;
			if (OnColorChange != null)
				OnColorChange.Invoke();
		}
	}

	
	[SerializeField]
	void Start () {
		Sprite = GetComponent<SpriteRenderer> ();
	}
}
