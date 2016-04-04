using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ChoicesPanel : MonoBehaviour {

	public SubPanel subPanel;

	private List<SubPanel> listChoices = new List<SubPanel> ();
	private int size = 10;
	private int selectedChoice = 0;
	private int firstDisplayed = 0;
	private bool hasFocus = false;

	public void CreateChoice(string nameChoice, string displayedText, bool hasCheckbox, bool isChecked){
		RectTransform transform = GetComponent<RectTransform> ();
		SubPanel sub = (SubPanel)Instantiate(subPanel);
		sub.transform.SetParent (transform);
		Vector2 sizePanel = new Vector2(transform.rect.width,transform.rect.height/size);
		sub.GetComponent<RectTransform> ().sizeDelta = sizePanel;
		sub.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
		sub.UpdateContent (nameChoice, displayedText, hasCheckbox, isChecked);
		listChoices.Add (sub);
	}

	public bool HasChoices(){
		return (listChoices.Count > 0);
	}

	public void SetSize(int size){
		this.size = size;
	}

	public string GetSelectedChoice(){
		return listChoices[selectedChoice].nameSubPanel;
	}

	public int GetIndexSelectedChoice(){
		return selectedChoice;
	}

	public void SetFocus(bool b){
		hasFocus = b;
		HighlightChoice ();
	}

	public string ChangeChoice(int direction){
		if (listChoices!=null && listChoices.Count>0) {
			selectedChoice = (int)Mathf.Repeat (selectedChoice + direction, listChoices.Count);
			if(selectedChoice>size-1){
				firstDisplayed = selectedChoice - size + 1;
				Display (firstDisplayed);
			}
			else if(selectedChoice<firstDisplayed){
				firstDisplayed = selectedChoice;
				Display (firstDisplayed);
			}
			HighlightChoice ();
			return GetSelectedChoice();
		}
		return "";
	}

	void HighlightChoice(){
		for (int i=0; i<listChoices.Count; i++){
			if (i == selectedChoice && hasFocus) {
				listChoices [i].Highlight (true);
			}
			else {
				listChoices [i].Highlight (false);
			}
		}
	}

	public void Display(int begining){
		foreach (Transform child in this.transform) {
			child.gameObject.SetActive (false);
		}
		float height = GetComponent<RectTransform> ().rect.height;
		float step = height/size;
		Vector2 offset = new Vector2(GetComponent<RectTransform> ().rect.center.x,GetComponent<RectTransform> ().rect.center.y);
		for (int i=begining; i<Mathf.Min(begining+size,listChoices.Count); i++){
			listChoices [i].gameObject.SetActive (true);
			Vector2 positionPanel = new Vector2 (0, (height-step) / 2 - (i-begining)*step) + offset;
			listChoices [i].GetComponent<RectTransform> ().localPosition = positionPanel;
		}
		HighlightChoice ();
	}

	public void ResetSelection(){
		selectedChoice = 0;
		firstDisplayed = 0;
	}

	public void Clear(){
		foreach (Transform child in this.transform) {
			Destroy(child.gameObject);
		}
		listChoices = new List<SubPanel> ();
	}
}
