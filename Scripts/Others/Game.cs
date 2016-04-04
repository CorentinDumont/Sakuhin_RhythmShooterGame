using UnityEngine;
using System.Collections;

[System.Serializable]
public class Game { 

	public static Game current;
	public string[] weapons;
	public string[] armors;

	public Game () {
		weapons = new string[] {"LaserLevel0","","",""};
		armors = new string[] {"","","",""};
	}

	static bool IsInArray(string[] array, string s){
		foreach (string str in array) {
			if (str == s) {
				return true;
			}
		}
		return false;
	}

	public static bool IsSaved(string itemName){
		return (IsInArray (current.weapons, itemName) || IsInArray (current.armors, itemName));
	}

}