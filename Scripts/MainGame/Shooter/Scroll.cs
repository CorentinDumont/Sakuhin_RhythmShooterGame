using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public float scrollSpeed = -0.1f;

	void Update()
	{
		GetComponent<Renderer> ().material.SetTextureOffset ("_MainTex", new Vector2 (Time.time * scrollSpeed,0));
	}
}
