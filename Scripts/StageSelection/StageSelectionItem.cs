using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StageSelectionItem : MonoBehaviour {

	public string stageName;
	public float scrollSpeed = 0.2f;

	private bool active = false;
	private GameObject texture;

	void Start(){
		foreach (Transform child in transform) {
			texture = child.gameObject;
		}
	}

	void Update()
	{
		if (active) {
			texture.GetComponent<Renderer> ().material.SetTextureOffset ("_MainTex", new Vector2 (Time.time * scrollSpeed, 0));
		}
	}

	public void SetActivation(bool active){
		this.active = active;
		if (active) {
			transform.rotation = Quaternion.Euler (20, 0, 0);
			if (GetComponent<AudioSource> () != null) {
				GetComponent<AudioSource> ().Play ();
			}
		}
		else {
			transform.rotation = Quaternion.Euler (0, 0, 0);
			if (GetComponent<AudioSource> () != null) {
				GetComponent<AudioSource> ().Stop ();
			}
		}
	}

	public void OnChosen(){
		//Debug.Log (stageName);
		SceneManager.LoadSceneAsync (stageName);
	}
}
