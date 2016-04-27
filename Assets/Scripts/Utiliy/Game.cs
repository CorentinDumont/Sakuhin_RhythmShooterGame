//Definition of the class that contains the data to be saved
//put here, as arguments of the Game class the information that you want to save

//Also see the Script that save and load (make the translation between the Game class and the binary save file), SaveLoad.cs

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable] // so that the Game class can be converted to binary format and be saved
public class Game { 

	public static Game current; // static, so can be called from anywhere by Came.current, it represents the current save
	public string[] weapons; // weapons that are attached to the playership
	public string[] armors; // armors that are attached to the playership
	public Dictionary<string,int> bestScore;
	public Dictionary<string,int> bestCombo;
	public Dictionary<string,int[]> bestRhythmScores;
	public Dictionary<string,int> bestGrade;

	public Game () {
		weapons = new string[] {"LaserLevel0","","",""};
		armors = new string[] {"","","",""};
		bestScore = new Dictionary<string,int> ();
		bestCombo = new Dictionary<string,int> ();
		bestRhythmScores = new Dictionary<string,int[]> ();
		bestGrade = new Dictionary<string,int> ();
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