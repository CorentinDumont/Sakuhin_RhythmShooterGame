﻿// Script that defines the functionning of the menu of the Shop
// attached to the panel that contains the menu
// as most of the objects contained in the menu changes in function of the user actions, most of them cannot be placed and/or
// with the graphic interface of Unity, so they are instantiate, positionned and resized in this script, which also uses
// ChoicesPanel.cs, CharacteristicsPanel.cs and DescriptionPanel.cs

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;


public class ListOfItems : MonoBehaviour {

	public Item[] items; // Items to be displayed

	public ChoicesPanel typePanel; // panel displaying the categories of the items
	public ChoicesPanel itemPanel; // panel displaying the list of the items in the category selected in typePanel
	public GameObject detailsPanel; // panel containing the characteristicsPanel and descriptionPanel, necessary to position these two panels correctly
	public CharacteristicsPanel characteristicsPanel; // panel where the characteristics can be written
	public DescriptionPanel descriptionPanel; // panel where the descriptions can be written

	private Dictionary< string,List<Item> > objects; // dictionnary used to classify items by categories

	private int selectedMenu = 0; // 0 if the player is focusing on the typePanel (chosing categories), 1 for itemPanel (choosing items)

	private Item testItem; // Item instance used to show the weapon working on the screen (demonstration) while choosing

	// Used to sort the items in the menus
	private class SorterText : IComparer<Text> {
		int IComparer<Text>.Compare(Text a, Text b){ 
			return String.Compare(a.text,b.text);
		}
	}

	// Used to sort the items in the menus
	private class SorterItem : IComparer<Item> {
		int IComparer<Item>.Compare(Item a, Item b){
			int levelA = a.level;
			int levelB = b.level;
			if (levelA > levelB) {
				return 1;
			}
			else if (levelA < levelB) {
				return -1;
			}
			else {
				return String.Compare(a.name,b.name);
			}
		}
	}

	// Use this for initialization
	void Start () {
		// Loads the already equipped items from the save data, or start a new game if no data
		Game.current = new Game ();
		SaveLoad.Load ();
		objects = new Dictionary< string,List<Item> >();
		string tag;
		List<Item> list;
		for (int i = 0; i < items.Length; i++) {
			tag = items[i].tag;
			if (objects.ContainsKey(tag)) {
				objects [tag].Add (items [i]);
			} 
			else {
				list = new List<Item>();
				list.Add (items [i]);
				objects [tag] = list;
			}
		}
		foreach (string key in objects.Keys) {
			objects[key].Sort((IComparer<Item>)new SorterItem());
		}

		// Sizes correctly the different panels so that the menu is always entirely visible, whatever the ration and size of the screen
		Rect rect = GetComponent<RectTransform> ().rect;
		typePanel.GetComponent<RectTransform> ().sizeDelta = new Vector2(rect.width/3, typePanel.GetComponent<RectTransform> ().sizeDelta.y);
		itemPanel.GetComponent<RectTransform> ().sizeDelta = new Vector2(rect.width/3, itemPanel.GetComponent<RectTransform> ().sizeDelta.y);
		detailsPanel.GetComponent<RectTransform> ().sizeDelta = new Vector2(rect.width/3, detailsPanel.GetComponent<RectTransform> ().sizeDelta.y);

		typePanel.SetSize(5);
		foreach (string key in objects.Keys) {
			typePanel.CreateChoice (key,key,false,false);
		}
		// Adds a choice to go back to the main menu
		objects ["Main Menu"] = new List<Item>();
		typePanel.CreateChoice ("Main Menu","Main Menu",false,false);
		typePanel.Display(0);
		typePanel.SetFocus (true);

		SelectType (typePanel.GetSelectedChoice());
		itemPanel.Display (0);
	}

	// Defines the behaviour of the menu when the user select an item or press an arrow or return/enter
	// selection of an item : displays characteristics, description and demonstration item
	// up / down naviguates vertically
	// left / right alternates between the typePanel and the itemPanel (categories and items selection)
	// enter on Main Menu goes back to main menu
	// enter on an item menu equips or desequips the item (ToggleItem function)
	void Update () {
		if (Input.GetKeyDown("down")) {
			if (selectedMenu == 0) {
				SelectType (typePanel.ChangeChoice (1));
				itemPanel.ResetSelection ();
			}
			else if (selectedMenu == 1) {
				itemPanel.ChangeChoice (1);
				DisplayCharacteristics ();
			}
		}
		else if (Input.GetKeyDown("up")) {
			if (selectedMenu == 0) {
				SelectType (typePanel.ChangeChoice (-1));
				itemPanel.ResetSelection ();
			}
			else if (selectedMenu == 1) {
				itemPanel.ChangeChoice (-1);
				DisplayCharacteristics ();
			}
		}
		else if (Input.GetKeyDown("right")) {
			if (itemPanel.HasChoices()) {
				itemPanel.SetFocus (true);
				selectedMenu = 1;
				DisplayCharacteristics ();
			}
		}
		else if (Input.GetKeyDown("left")) {
			itemPanel.SetFocus (false);
			selectedMenu = 0;
			RemoveCharacteristics ();
		}
		if (Input.GetKeyDown("return")) {
			string selectedType = typePanel.GetSelectedChoice ();
			if (selectedMenu == 0 && selectedType == "Main Menu") {
				SceneManager.LoadScene ("Title");
			}
			if (selectedMenu == 1) {
				ToggleItem (objects [selectedType] [itemPanel.GetIndexSelectedChoice()]);
				SelectType (selectedType);
			}
		}
	}

	// Update the content of the itemPanel in function of the category choosen in the typePanel
	void SelectType(string type){
		itemPanel.Clear ();
		foreach (Item item in objects[type]) {
			itemPanel.CreateChoice (item.name,item.itemName,true,Game.IsSaved (item.name));
		}
		itemPanel.Display (0);
	}

	// displays the characteristics of the currently selected item
	void DisplayCharacteristics(){
		RemoveCharacteristics ();
		Item selectedObject = objects [typePanel.GetSelectedChoice()] [itemPanel.GetIndexSelectedChoice()];
		Vector3 testItemPosition;
		if (selectedObject.tag == "Weapon") {
			testItemPosition = new Vector3 (1f, 0f, 0f);
		}
		else {
			testItemPosition = new Vector3 (0f, 0f, 0f);
		}
		testItem = (Item)Instantiate(selectedObject,testItemPosition,Quaternion.identity);

		characteristicsPanel.CreateContent (selectedObject);

		descriptionPanel.SetDescription (selectedObject.GetComponent<Item>().description);
	}
		
	// Empties the characteristicsPanel
	void RemoveCharacteristics(){
		if (testItem != null) {
			Destroy (testItem.gameObject);
		}
		characteristicsPanel.Clear();
		descriptionPanel.Clear();
	}

	// Equips or Desequips an item and save
	void ToggleItem(Item item){
		if (item.tag == "Weapon") {
			if (Game.current.weapons [item.level] == item.name) {
				Game.current.weapons [item.level] = "";
			}
			else {
				Game.current.weapons [item.level] = item.name;
			}
		}
		else if (item.tag == "Armor") {
			if (Game.current.armors [item.level] == item.name) {
				Game.current.armors [item.level] = "";
			}
			else {
				Game.current.armors [item.level] = item.name;
			}
		}
		SaveLoad.Save();
	}
}
