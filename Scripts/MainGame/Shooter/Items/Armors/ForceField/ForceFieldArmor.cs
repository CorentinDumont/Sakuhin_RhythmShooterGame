// defines the abstract Armor (that heritates from abstract Item class) class
// attached to every ForceField (armor) objects

using UnityEngine;
using System.Collections;

public class ForceFieldArmor : Armor {

	override public bool CanBeSelected(int combo){ // define the condition for the armor to be selected
		return (combo >= comboThreshold);
	}
}
