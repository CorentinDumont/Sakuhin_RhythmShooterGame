// defines the abstract Weapon (that heritates from abstract Item class) class
// attached to every Laser (weapons) objects

using UnityEngine;
using System.Collections;

public class LaserWeapon : Weapon {

	override public bool CanBeSelected(int combo){ // define the condition for the armor to be selected
		return (combo >= comboThreshold);
	}

}
