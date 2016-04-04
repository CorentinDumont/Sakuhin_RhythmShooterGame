using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShip : MonoBehaviour {

	public float speed = 5.0f;
	public GameObject explosion;
	public GameEventsHandler handler;

	public List<Item> possibleItems = new List<Item>();
	private Vector3 startPosition;
	private int selectedWeapon = -1;
	private Weapon weapon;
	private int selectedArmor = -1;
	private Armor armor;

	// Use this for initialization
	void Start () {
		startPosition = this.transform.position;
		UpdateItems ();
	}

	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().velocity = new Vector3(Input.GetAxis ("Vertical"),0.0f,-Input.GetAxis ("Horizontal"))*speed;
	}

	public void addPossibleItems(Item newItem){
		possibleItems.Add (newItem);
		UpdateItems ();
	}

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

	public void TakeDamage(int damage){
		if (armor != null) {
			Armor currentArmor = armor.transform.GetComponent<Armor> ();
			currentArmor.TakeDamage (damage);
		}
		if (weapon != null) {
			Weapon currentWeapon = weapon.transform.GetComponent<Weapon> ();
			currentWeapon.TakeDamage (damage);
		}
	}

	public void ResetPosition(){
		this.transform.position = this.startPosition;
		ChangeArmor ();
		ChangeWeapon ();
	}

	public void Explode() {
		Instantiate (explosion, transform.position, Quaternion.identity);
		handler.ResetPlayer ();
	}
}
