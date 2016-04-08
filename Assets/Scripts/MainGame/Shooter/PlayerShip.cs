<<<<<<< HEAD
﻿// Script that defines the behaviour of the player ship in function of the user : pressed keys, score in rhythm game, equipped items...
// Is attached to the playerShip object

using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
using System.Collections;
using System.Collections.Generic;

public class PlayerShip : MonoBehaviour {

	public float speed = 5.0f;
<<<<<<< HEAD
	public GameObject explosion; // prefab of the explosion animation for the player
	public GameEventsHandler handler; // instance of the obect that handles events (combo,...)

	public List<Item> possibleItems = new List<Item>(); // items equipped
	private Vector3 startPosition;
	private int selectedWeapon = -1;
	private Weapon weapon; // currently used weapon
	private int selectedArmor = -1;
	private Armor armor; // currently used armor
=======
	public GameObject explosion;
	public GameEventsHandler handler;

	public List<Item> possibleItems = new List<Item>();
	private Vector3 startPosition;
	private int selectedWeapon = -1;
	private Weapon weapon;
	private int selectedArmor = -1;
	private Armor armor;
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479

	// Use this for initialization
	void Start () {
		startPosition = this.transform.position;
		UpdateItems ();
	}

	// Update is called once per frame
<<<<<<< HEAD
	void Update () { // move the ship in function of the arrows pressed on the keyboard
		GetComponent<Rigidbody>().velocity = new Vector3(Input.GetAxis ("Vertical"),0.0f,-Input.GetAxis ("Horizontal"))*speed;
	}

	///////////////////////////
	/// Gestion of Items //////
	///////////////////////////

=======
	void Update () {
		GetComponent<Rigidbody>().velocity = new Vector3(Input.GetAxis ("Vertical"),0.0f,-Input.GetAxis ("Horizontal"))*speed;
	}

>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
	public void addPossibleItems(Item newItem){
		possibleItems.Add (newItem);
		UpdateItems ();
	}

<<<<<<< HEAD
	// Choose what items to be used in function of damages, combo...
	// In the current state, 1 weapon and 1 armor can be used at a time
	// among the items that can be selected (see CanBeSelected of Items.cs), the items with the best levels are used
=======
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
	public void UpdateItems(){
		int combo = handler.GetCombo ();
		Item checkedItem;
		int maxLevelWeapon = 0;
		int maxLevelArmor = 0;
		for (int i = 0; i < possibleItems.Count; i++) {
			checkedItem = possibleItems [i].transform.GetComponent<Item> ();
			if (checkedItem.tag == "Armor") {
				if (checkedItem.CanBeSelected(combo) && checkedItem.level >= maxLevelArmor) {
					selectedArmor = i;
					maxLevelArmor = checkedItem.level;
				}
			}
			else if (checkedItem.tag == "Weapon") {
				if (checkedItem.CanBeSelected(combo) && checkedItem.level >= maxLevelWeapon) {
					selectedWeapon = i;
					maxLevelWeapon = checkedItem.level;
				}
			}
		}
		if (armor != null) {
			Armor currentArmor = armor.transform.GetComponent<Armor> ();
			if (currentArmor.IsBroken () || maxLevelArmor > currentArmor.level) {
				ChangeArmor ();
			}
		} else {
			ChangeArmor ();
		}
		if (weapon != null) {
			Weapon currentWeapon = weapon.transform.GetComponent<Weapon> ();
			if (currentWeapon.IsBroken () || maxLevelWeapon > currentWeapon.level) {
				ChangeWeapon ();
			}
		} else {
			ChangeWeapon ();
		}
	}

<<<<<<< HEAD
	// Used by UpdateItems to change the armor
=======
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
	void ChangeArmor()
	{
		if (armor != null) {
			Destroy (armor.gameObject);
		}
		if(selectedArmor!=-1){
			Armor objArmor = (Armor)Instantiate (possibleItems [selectedArmor], transform.position, Quaternion.identity);
			armor = objArmor;
			armor.transform.parent = this.transform;
		}
	}

<<<<<<< HEAD
	// Used by UpdateItems to change the weapon
=======
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
	void ChangeWeapon()
	{
		if (weapon != null) {
			Destroy (weapon.gameObject);
		}
		if(selectedWeapon!=-1){
			Weapon objWeapon = (Weapon)Instantiate (possibleItems [selectedWeapon], transform.position + new Vector3 (1.0f, 0.0f, 0.0f), Quaternion.identity);
			weapon = objWeapon;
			weapon.transform.parent = this.transform;
		}
	}

<<<<<<< HEAD
	///////////////////////////
	/// Gestion of damages ////
	///////////////////////////

	public void TakeDamage(int damage){ // When the player miss the rhythm game, the damages are sent to the ship (here)
										//, and the ship send damages to equipped items
=======
	public void TakeDamage(int damage){
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
		if (armor != null) {
			Armor currentArmor = armor.transform.GetComponent<Armor> ();
			currentArmor.TakeDamage (damage);
		}
		if (weapon != null) {
			Weapon currentWeapon = weapon.transform.GetComponent<Weapon> ();
			currentWeapon.TakeDamage (damage);
		}
	}

<<<<<<< HEAD
	// Used by the event handler to respawn the player
=======
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
	public void ResetPosition(){
		this.transform.position = this.startPosition;
		ChangeArmor ();
		ChangeWeapon ();
	}

<<<<<<< HEAD
	// Destroys itself and display an explosion animation
=======
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
	public void Explode() {
		Instantiate (explosion, transform.position, Quaternion.identity);
		handler.ResetPlayer ();
	}
}
