// script that handle the events that influence both the shooter and rhythm game (update combo, set items of player...)

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ShooterEventsHandler : MonoBehaviour {

	public PlayerShip playerShip; // player ship object

	public EnemySpawner enemySpawner;
	public GameObject enemyDirectionTarget;
	public GameObject bossDirectionTarget;
	public ItemsContainer allItems; // all items, some of them (choosen in the shop) will be attached to the player ship
	public LifePanel lifePanel;
	public Text scoreText;

	private bool canRespawnPlayer = true; // can the player ship been respawn?

	void Awake(){
		Time.timeScale = 1.0f;
		Game.current = new Game (); // new Game if the load doesn't work
		SaveLoad.Load (); // loads the game save that contains the items that have to be attached to the player
		if (GameValuesContainer.container == null) {
			GameValuesContainer.container = new GameValuesContainer ();
		}
		GameValuesContainer.container.shooterHandler = this;
	}

	void Start(){
		SetPossibleArmors (Game.current.armors); // attaches selected armors to the player ship
		SetPossibleWeapons (Game.current.weapons); // attaches selected weapons to the player ship
		playerShip.Initialize ();
	}

	public void Initialize(){
		IncreaseScore(0);
	}

	public void Clear(){
		GameValuesContainer.container.movingObjectsContainers.ClearShooterObjects ();
		GameValuesContainer.container.shootingScore = 0;
		IncreaseScore(0);
		GameValuesContainer.container.lives = 3;
		lifePanel.SetLives ();
		canRespawnPlayer = false;
		StartCoroutine (RespawnPlayer (0.3f));
	}

	///////////////////////////////
	// Attaching items to player //
	///////////////////////////////

	Item GetItemByName(string name, Item[] items){
		foreach (Item item in items) {
			if (item.name == name) {
				return item;
			}
		}
		return null;
	}

	void SetPossibleArmors(string[] savedArmors){
		List<Armor> possibleArmors = new List<Armor>();
		Armor armor;
		foreach (string name in savedArmors) {
			armor = (Armor)GetItemByName (name,allItems.armors);
			if (armor != null) {
				possibleArmors.Add(armor);
			}
		}
		GameValuesContainer.container.possibleArmors = possibleArmors.ToArray();
	}

	void SetPossibleWeapons(string[] savedWeapons){
		List<Weapon> possibleWeapons = new List<Weapon>();
		Weapon weapon;
		foreach (string name in savedWeapons) {
			weapon = (Weapon)GetItemByName (name,allItems.weapons);
			if (weapon != null) {
				possibleWeapons.Add(weapon);
			}
		}
		GameValuesContainer.container.possibleWeapons = possibleWeapons.ToArray();
	}

	///////////////////////////////
	//     Respawning player     //
	///////////////////////////////

	IEnumerator RespawnPlayer(float delay){
		playerShip.gameObject.SetActive (false);
		playerShip.ResetPosition ();
		yield return new WaitForSeconds (delay);
		playerShip.gameObject.SetActive (true);
		canRespawnPlayer = true;
	}

	public void ResetPlayer(){
		if (lifePanel.LivesDown ()) {
			if (canRespawnPlayer) {
				canRespawnPlayer = false;
				StartCoroutine (RespawnPlayer (1.0f));
			}
		}
		else {
			playerShip.gameObject.SetActive (false);
			GameValuesContainer.container.menuWrapper.ToggleGameOver ();
		}
	}

	//////////////
	/// Update shooter score
	//////////////

	public void IncreaseScore(int points){
		GameValuesContainer.container.shootingScore += points * Mathf.Max(1,GameValuesContainer.container.combo);
		int buff = GameValuesContainer.container.shootingScore;
		int unit;
		string score = "";
		for (int i = 0; i < 9; i++) {
			unit = buff / (int)Mathf.Pow (10, 8 - i);
			buff = buff - unit * (int)Mathf.Pow (10, 8 - i);
			score += ""+unit;
			if (i==2 || i==5) {
				score += " ";
			}
		}
		scoreText.text = score;
	}
}
