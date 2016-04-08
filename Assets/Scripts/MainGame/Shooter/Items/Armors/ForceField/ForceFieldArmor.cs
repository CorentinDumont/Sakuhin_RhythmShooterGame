<<<<<<< HEAD
﻿// defines the abstract Armor (that heritates from abstract Item class) class
// attached to every ForceField (armor) objects

using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
using System.Collections;

public class ForceFieldArmor : Armor {

<<<<<<< HEAD
	override public bool CanBeSelected(int combo){ // define the condition for the armor to be selected
=======
	override public bool CanBeSelected(int combo){
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
		return (combo >= comboThreshold);
	}
}
