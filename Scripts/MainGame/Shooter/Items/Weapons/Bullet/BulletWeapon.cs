// defines the abstract Weapon (that heritates from abstract Item class) class
// attached to every Bullet (weapons) objects

using UnityEngine;
using System.Collections;

public class BulletWeapon : Weapon {

	override public bool CanBeSelected(int combo){ // define the condition for the armor to be selected
		return (combo >= comboThreshold);
	}

}
