﻿// attached to the panel where the characteristics of items is displayed
// necessary to adapt the size and position of the sub Panel objects containing the characteristics

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CharacteristicsPanel : MonoBehaviour {

	public Characteristic charactericticSubPanel; // prefab used to instantiate sub Panel, see Characteristic.cs

	public void CreateContent (Item item){

		// Create sub Panel from the charactericticSubPanel Prefab and fill them with the characteristics of the Item

		Pair<string, int> level = new Pair<string, int>("Level : ",item.GetComponent<Item> ().level);
		Pair<string, int> combo = new Pair<string, int>("Threshold : ",item.GetComponent<Item> ().comboThreshold);
		Pair<string, int> resistance = new Pair<string, int>("Resistance : ",item.GetComponent<Item> ().breakResistance);
		List< Pair<string, int> > listCharacteristics = new List< Pair<string, int> >();
		listCharacteristics.Add (level);
		listCharacteristics.Add (combo);
		listCharacteristics.Add (resistance);

		// Position and size the sub Panels

		RectTransform transform = GetComponent<RectTransform> ();
		float height = transform.rect.height;
		float step = height/listCharacteristics.Count;
		Vector2 offset = new Vector2(transform.rect.center.x,transform.rect.center.y);
		for (int i=0;i<listCharacteristics.Count;i++) {
			Characteristic sub = (Characteristic)Instantiate(charactericticSubPanel);
			sub.transform.SetParent (transform);
			Vector2 sizeSub = new Vector2(transform.rect.width,step);
			sub.GetComponent<RectTransform> ().sizeDelta = sizeSub;
			sub.GetComponent<RectTransform> ().localScale = Vector3.one;
			sub.GetComponent<RectTransform> ().localRotation = Quaternion.Euler(Vector3.zero);
			Vector2 positionPanel = new Vector2 (0, (height-step) / 2 - i*step) + offset;
			sub.GetComponent<RectTransform> ().localPosition = positionPanel;
			sub.UpdateContent (listCharacteristics[i].First, listCharacteristics[i].Second);
		}
	}

	public void Clear(){ // Clear the panel
		foreach (Transform child in this.transform) {
			Destroy(child.gameObject);
		}
	}
}