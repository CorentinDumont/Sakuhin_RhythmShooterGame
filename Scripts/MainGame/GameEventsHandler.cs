using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameEventsHandler : MonoBehaviour {

	private int lives = 3;
	private int score = 0;
	private int combo = 0;
	private int maxCombo = 0;
	private int[] scores = new int[6] {0, 0, 0, 0, 0, 0};
	private bool canRespawnPlayer = true;

	public PlayerShip playerShip;
	public Item[] allItems;
	public Text scoreText;


	void Start(){
		Game.current = new Game ();
		SaveLoad.Load ();
		AddItemsToPlayer (Game.current.armors);
		AddItemsToPlayer (Game.current.weapons);
	}

	Item GetItemByName(string name){
		foreach (Item item in allItems) {
			if (item.name == name) {
				return item;
			}
		}
		return null;
	}

	void AddItemsToPlayer(string[] items){
		Item newItem;
		foreach (string name in items) {
			newItem = GetItemByName (name);
			if (newItem != null) {
				playerShip.addPossibleItems (newItem);
			}
		}
	}

	public int GetCombo(){
		return combo;
	}

	IEnumerator RespawnPlayer(){
		playerShip.gameObject.SetActive (false);
		playerShip.ResetPosition ();
		yield return new WaitForSeconds (1.0f);
		playerShip.gameObject.SetActive (true);
		canRespawnPlayer = true;
	}

	public void ResetPlayer(){
		if (canRespawnPlayer) {
			canRespawnPlayer = false;
			StartCoroutine (RespawnPlayer ());
		}
	}

	public void UpdateScore(int score){
		scores [score] += 1;
		if (score < 3) {
			combo = 0;
			playerShip.TakeDamage (1);
		}
		else {
			combo += 1;
		}
		if (combo > maxCombo) {
			maxCombo = combo;
		}
		playerShip.UpdateItems ();
	}
}
