using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class Menu : MonoBehaviour {

	public MenuChoice[] choices;
	public Color selectedColor;
	public Color NonSelectedColor;
	private int selected;

	// Use this for initialization
	void Start () {
		HighlightChoice ();
		OnStart ();
	}

	abstract protected void OnStart ();

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("down") || Input.GetKeyDown("right")) {
			ChangeChoice(1);
		}
		else if (Input.GetKeyDown("up") || Input.GetKeyDown("left")) {
			ChangeChoice(-1);
		}
		if (Input.GetKeyDown("return")) {
			choices [selected].OnChoosen ();
		}
	}

	void HighlightChoice(){
		for (int i = 0; i < choices.Length; i++) {
			if (i == selected) {
				choices [i].GetComponent<Text> ().color = selectedColor;
			}
			else {
				choices [i].GetComponent<Text> ().color = NonSelectedColor;
			}
		}
	}

	void ChangeChoice(int direction){
		selected = (int)Mathf.Repeat (selected + direction, choices.Length);
		HighlightChoice ();
	}
}
