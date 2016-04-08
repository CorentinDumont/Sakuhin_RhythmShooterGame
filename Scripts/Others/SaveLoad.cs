﻿// script used to save and load into binary format the contents of the static Game class, see Game.cs

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad {

	public static Game savedGame = new Game();

	//it's static so we can call it from anywhere
	public static void Save() {
		SaveLoad.savedGame = Game.current;
		BinaryFormatter bf = new BinaryFormatter();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		FileStream file = File.Create (Application.persistentDataPath + "/savedGame.gd"); // choose here the name and extention of the save file
		bf.Serialize(file, SaveLoad.savedGame);
		file.Close();
	}   

	public static void Load() {
		if(File.Exists(Application.persistentDataPath + "/savedGame.gd")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedGame.gd", FileMode.Open);
			SaveLoad.savedGame = (Game)bf.Deserialize(file);
			Game.current = SaveLoad.savedGame;
			file.Close();
		}
	}
}