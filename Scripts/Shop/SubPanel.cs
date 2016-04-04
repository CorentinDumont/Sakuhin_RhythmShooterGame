using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SubPanel : MonoBehaviour {

	public string nameSubPanel = "";
	public Text displayedText;
	public GameObject checkedBox;
	public GameObject uncheckedBox;

	public Color selectedColor = Color.gray;
	public Color nonSelectedColor = Color.white;
	public int selectedFontSize = 22;
	public int nonSelectedFontSize = 20;

	public void UpdateContent(string nameChoice, string displayedText, bool hasCheckbox, bool isChecked){
		nameSubPanel = nameChoice;
		this.displayedText.text = displayedText;
		Rect rect = GetComponent<RectTransform> ().rect;
		float ratioText = 1f;
		if (hasCheckbox) {
			if (isChecked) {
				checkedBox.SetActive (true);
			}
			else {
				uncheckedBox.SetActive (true);
			}
			ratioText = 0.85f;
		}
		this.displayedText.GetComponent<RectTransform> ().sizeDelta = new Vector2(rect.width*ratioText, this.displayedText.GetComponent<RectTransform> ().sizeDelta.y);
	}

	public void Highlight(bool b){
		if (b) {
			GetComponent<Image>().color = selectedColor;
			displayedText.fontSize = selectedFontSize;
		}
		else {
			GetComponent<Image>().color = nonSelectedColor;
			displayedText.fontSize = nonSelectedFontSize;
		}
	}
}
