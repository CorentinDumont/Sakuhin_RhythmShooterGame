// script that handle the events that influence both the shooter and rhythm game (update combo, set items of player...)

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameEventsHandler : MonoBehaviour {

	//private int lives = 3;
	//private int score = 0;
	private int combo = 0; // current combo
	private int maxCombo = 0; // biggest combo the player has done in the play
	private int[] scores = new int[6] {0, 0, 0, 0, 0, 0}; // number of Miss, Bad, Almost, Good, Great and Fantastic respectively
	private bool canRespawnPlayer = true; // can the player ship been respawn?

	public PlayerShip playerShip; // player ship object
	public Item[] allItems; // all items, some of them (choosen in the shop) will be attached to the player ship
	//public Text scoreText;


	void Start(){
		Game.current = new Game (); // new Game if the load doesn't work
		SaveLoad.Load (); // loads the game save that contains the items that have to be attached to the player
		AddItemsToPlayer (Game.current.armors); // attaches selected armors to the player ship
		AddItemsToPlayer (Game.current.weapons); // attaches selected weapons to the player ship
	}

	///////////////////////////////
	// Attaching items to player //
	///////////////////////////////

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

	///////////////////////////////
	//      Updating Combo       //
	///////////////////////////////

	public int GetCombo(){
		return combo;
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

	///////////////////////////////
	//     Respawning player     //
	///////////////////////////////

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
}
