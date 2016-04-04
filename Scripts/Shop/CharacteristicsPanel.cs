using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CharacteristicsPanel : MonoBehaviour {

	public Characteristic charactericticSubPanel;

	public void CreateContent (Item item){
		Pair<string, int> level = new Pair<string, int>("Level : ",item.GetComponent<Item> ().level);
		Pair<string, int> combo = new Pair<string, int>("Threshold : ",item.GetComponent<Item> ().comboThreshold);
		Pair<string, int> resistance = new Pair<string, int>("Resistance : ",item.GetComponent<Item> ().breakResistance);
		List< Pair<string, int> > listCharacteristics = new List< Pair<string, int> >();
		listCharacteristics.Add (level);
		listCharacteristics.Add (combo);
		listCharacteristics.Add (resistance);

		RectTransform transform = GetComponent<RectTransform> ();
		float height = transform.rect.height;
		float step = height/listCharacteristics.Count;
		Vector2 offset = new Vector2(transform.rect.center.x,transform.rect.center.y);
		for (int i=0;i<listCharacteristics.Count;i++) {
			Characteristic sub = (Characteristic)Instantiate(charactericticSubPanel);
			sub.transform.SetParent (transform);
			Vector2 sizeSub = new Vector2(transform.rect.width,step);
			sub.GetComponent<RectTransform> ().sizeDelta = sizeSub;
			sub.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
			Vector2 positionPanel = new Vector2 (0, (height-step) / 2 - i*step) + offset;
			sub.GetComponent<RectTransform> ().localPosition = positionPanel;
			sub.UpdateContent (listCharacteristics[i].First, listCharacteristics[i].Second);
		}
	}

	public void Clear(){
		foreach (Transform child in this.transform) {
			Destroy(child.gameObject);
		}
	}
}
