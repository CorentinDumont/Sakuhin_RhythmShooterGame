using UnityEngine;
using System.Collections;

public class ForceFieldArmor : Armor {

	override public bool CanBeSelected(int combo){
		return (combo >= comboThreshold);
	}
}
