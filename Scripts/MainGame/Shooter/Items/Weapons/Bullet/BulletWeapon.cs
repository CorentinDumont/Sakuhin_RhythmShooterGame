using UnityEngine;
using System.Collections;

public class BulletWeapon : Weapon {

	override public bool CanBeSelected(int combo){
		return (combo >= comboThreshold);
	}

}
