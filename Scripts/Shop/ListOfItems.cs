using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;


public class ListOfItems : MonoBehaviour {

	public Item[] items;

	public ChoicesPanel typePanel;
	public ChoicesPanel itemPanel;
	public GameObject detailsPanel;
	public CharacteristicsPanel characteristicsPanel;
	public DescriptionPanel descriptionPanel;

	private Dictionary< string,List<Item> > objects;

	private int selectedMenu = 0;

	private Item testItem;

	private class SorterText : IComparer<Text> {
		int IComparer<Text>.Compare(Text a, Text b){ 
			return String.Compare(a.text,b.text);
		}
	}

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

		Rect rect = GetComponent<RectTransform> ().rect;
		typePanel.GetComponent<RectTransform> ().sizeDelta = new Vector2(rect.width/3, typePanel.GetComponent<RectTransform> ().sizeDelta.y);
		itemPanel.GetComponent<RectTransform> ().sizeDelta = new Vector2(rect.width/3, itemPanel.GetComponent<RectTransform> ().sizeDelta.y);
		detailsPanel.GetComponent<RectTransform> ().sizeDelta = new Vector2(rect.width/3, detailsPanel.GetComponent<RectTransform> ().sizeDelta.y);

		typePanel.SetSize(5);
		foreach (string key in objects.Keys) {
			typePanel.CreateChoice (key,key,false,false);
		}
		objects ["Main Menu"] = new List<Item>();
		typePanel.CreateChoice ("Main Menu","Main Menu",false,false);
		typePanel.Display(0);
		typePanel.SetFocus (true);

		SelectType (typePanel.GetSelectedChoice());
		itemPanel.Display (0);
	}

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

	void SelectType(string type){
		itemPanel.Clear ();
		foreach (Item item in objects[type]) {
			itemPanel.CreateChoice (item.name,item.itemName,true,Game.IsSaved (item.name));
		}
		itemPanel.Display (0);
	}

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



	void RemoveCharacteristics(){
		if (testItem != null) {
			Destroy (testItem.gameObject);
		}
		characteristicsPanel.Clear();
		descriptionPanel.Clear();
	}

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
