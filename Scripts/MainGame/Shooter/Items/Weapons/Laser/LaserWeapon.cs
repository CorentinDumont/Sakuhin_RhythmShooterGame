using UnityEngine;
using System.Collections;

public class LaserWeapon : Weapon {

	override public bool CanBeSelected(int combo){
		return (combo >= comboThreshold);
	}

}
