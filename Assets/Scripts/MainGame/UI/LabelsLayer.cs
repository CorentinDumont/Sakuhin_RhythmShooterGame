using UnityEngine;
using System.Collections;

public class LabelsLayer : MonoBehaviour {

	void Awake () {
		if (GameValuesContainer.container == null) {
			GameValuesContainer.container = new GameValuesContainer ();
		}
		GameValuesContainer.container.labelsLayer = this;
	}
}
