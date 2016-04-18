// Script that defines the behaviour of the player ship in function of the user : pressed keys, score in rhythm game, equipped items...
// Is attached to the playerShip object

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShip : MonoBehaviour {

	public float speed = 5.0f;
	public GameObject explosion; // prefab of the explosion animation for the player

	private Vector3 startPosition;
	private Weapon weapon; // currently used weapon
	private Armor armor; // currently used armor

	void Start(){
		startPosition = this.transform.position;
		GameValuesContainer.container.shooterHandler.Initialize ();
		GameValuesContainer.container.rhythmHandler.Initialize ();
	}

	// Update is called once per frame
	void Update () { // move the ship in function of the arrows pressed on the keyboard
		GetComponent<Rigidbody>().velocity = new Vector3(Input.GetAxis ("Vertical"),0.0f,-Input.GetAxis ("Horizontal"))*speed;
	}

	public void Initialize(){
		UpdateItems ();
		if (armor != null) {
			armor.gameObject.SetActive (true);
		}
		if (weapon != null) {
			weapon.gameObject.SetActive (true);
		}
	}

	///////////////////////////
	/// Gestion of Items //////
	///////////////////////////

	// Choose what items to be used in function of damages, combo...
	// In the current state, 1 weapon and 1 armor can be used at a time
	// among the items that can be selected (see CanBeSelected of Items.cs), the items with the best levels are used
	public void UpdateItems(){
		UpdateArmors ();
		UpdateWeapons ();
	}

	public void UpdateArmors(){
		int buffCurrentArmor = GameValuesContainer.container.currentArmor;
		Armor newArmor = null;
		int maxLevelArmor;
		if (this.armor == null || this.armor.IsBroken ()) {
			maxLevelArmor = -1;
		}
		else {
			maxLevelArmor = this.armor.level;
		}
		for (int i = 0; i < GameValuesContainer.container.possibleArmors.Length; i++) {
			newArmor = GameValuesContainer.container.possibleArmors [i];
			if (newArmor.CanBeSelected () && newArmor.level > maxLevelArmor) {
				GameValuesContainer.container.currentArmor = i;
				maxLevelArmor = newArmor.level;
			}
		}
		if (GameValuesContainer.container.currentArmor != buffCurrentArmor) {
			SetArmor (GameValuesContainer.container.possibleArmors [GameValuesContainer.container.currentArmor]);
		}
	}

	public void UpdateWeapons(){
		int buffCurrentWeapon = GameValuesContainer.container.currentWeapon;
		Weapon newWeapon = null;
		int maxLevelWeapon;
		if (this.weapon == null || this.weapon.IsBroken ()) {
			maxLevelWeapon = -1;
		}
		else {
			maxLevelWeapon = this.weapon.level;
		}
		for (int i = 0; i < GameValuesContainer.container.possibleWeapons.Length; i++) {
			newWeapon = GameValuesContainer.container.possibleWeapons [i];
			if (newWeapon.CanBeSelected () && newWeapon.level > maxLevelWeapon) {
				GameValuesContainer.container.currentWeapon = i;
				maxLevelWeapon = newWeapon.level;
			}
		}
		if (GameValuesContainer.container.currentWeapon != buffCurrentWeapon){
			SetWeapon (GameValuesContainer.container.possibleWeapons [GameValuesContainer.container.currentWeapon]);
		}
	}

	// Used by UpdateItems to change the armor
	void SetArmor(Armor newArmor)
	{
		if (armor != null) {
			Destroy (armor.gameObject);
		}
		if (newArmor != null) {
			armor = (Armor)Instantiate (newArmor, transform.position, transform.rotation);
			armor.transform.parent = this.transform;
		}
	}

	// Used by UpdateItems to change the weapon
	void SetWeapon(Weapon newWeapon)
	{
		if (weapon != null) {
			Destroy (weapon.gameObject);
		}
		if (newWeapon != null) {
			weapon = (Weapon)Instantiate (newWeapon, transform.position + new Vector3 (1.0f, 0.0f, 0.0f), transform.rotation);
			weapon.transform.parent = this.transform;
		}
		weapon.Initialize ();
	}

	///////////////////////////
	/// Gestion of damages ////
	///////////////////////////

	public void TakeDamage(int damage){ // When the player miss the rhythm game, the damages are sent to the ship (here)
										//, and the ship send damages to equipped items
		if (armor != null) {
			armor.TakeDamage (damage);
		}
		if (weapon != null) {
			weapon.TakeDamage (damage);
		}
		UpdateItems ();
	}

	// Used by the event handler to respawn the player
	public void ResetPosition(){
		this.transform.position = this.startPosition;
		weapon.Initialize ();
	}

	// Destroys itself and display an explosion animation
	public void Explode() {
		GameObject particle = (GameObject)Instantiate (explosion, transform.position, Quaternion.identity);
		particle.transform.SetParent (GameValuesContainer.container.particlesContainer.transform);
		GameValuesContainer.container.shooterHandler.ResetPlayer ();
	}
}
