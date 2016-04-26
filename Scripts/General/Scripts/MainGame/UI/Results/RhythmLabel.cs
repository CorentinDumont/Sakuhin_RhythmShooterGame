using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RhythmLabel : MonoBehaviour {

	void Awake(){
		DisplayLabels ();
	}

	void OnRectTransformDimensionsChange()
	{
		DisplayLabels ();
	}

	public void DisplayLabels(){
		int i = 0;
		Vector2 sizePanel = GetComponent<RectTransform> ().sizeDelta;
		foreach (RectTransform child in transform) {
			child.sizeDelta = new Vector2 (sizePanel.x/6, sizePanel.y);
			child.localPosition = new Vector3 ((sizePanel.x/6)*(i-2.5f), 0, 0);
			i++;
		}
	}
}
