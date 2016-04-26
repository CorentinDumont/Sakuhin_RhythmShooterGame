﻿// attached to the panel that contains the characteristics of items
// necessary to position and size correctly the objects inside the panel
// used by CharacteristicsPanel.cs

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Characteristic : MonoBehaviour {

	public Text displayedText;
	public GameObject bar;

	void Start(){
		Rect rect = GetComponent<RectTransform> ().rect;
		displayedText.GetComponent<RectTransform> ().sizeDelta = new Vector2(rect.width*0.5f, displayedText.GetComponent<RectTransform> ().sizeDelta.y);
	}

	public void UpdateContent(string displayedText, int value){
		this.displayedText.text = displayedText+value;
		bar.GetComponent<Slider> ().value = value;
	}
}