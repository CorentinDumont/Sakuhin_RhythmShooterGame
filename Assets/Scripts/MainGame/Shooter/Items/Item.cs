<<<<<<< HEAD
﻿// abstract class from which all the items (weapons and armors) heritates
// defines the properties that are common to all items

using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
using System.Collections;

abstract public class Item : MonoBehaviour {

<<<<<<< HEAD
	public string itemName; // name of the item
	public int level; // level of the item
	public int comboThreshold; // combo that is needed to be able to use the item
	public int breakResistance; // number of miss, bad and almost (combo break) the item can resist before breaking
	public string description; // description of the item displayed in the shop
	private int damage = 0; // number of miss, bad and almost (combo break) the item has taken
=======
	public string itemName;
	public int level;
	public int comboThreshold;
	public int breakResistance;
	public string description;
	private int damage = 0;
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479

	public int TakenDamage(){
		return damage;
	}

	public void TakeDamage(int damage){
		this.damage += damage;
	}

	public bool IsBroken(){
		if (breakResistance < 0) {
			return false;
		}
		else {
			return (damage > breakResistance);
		}
	}

<<<<<<< HEAD
	abstract public bool CanBeSelected (int combo); // has to be redefined for each item, says if the item can be used in function of the comboThreshold, the damages...
=======
	abstract public bool CanBeSelected (int combo);
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
}
