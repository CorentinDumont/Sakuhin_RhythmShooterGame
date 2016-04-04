using UnityEngine;
using System.Collections;

public class CanvasRatio : MonoBehaviour {

	// set the desired aspect ratio
	public float ratio = 16.0f / 9.0f;

	// Use this for initialization
	void Start () {

		Rect rect = this.GetComponent<Canvas> ().pixelRect;
		rect.width = 300;
	
	}
}
