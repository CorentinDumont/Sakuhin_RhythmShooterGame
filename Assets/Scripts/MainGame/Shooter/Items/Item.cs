using UnityEngine;
using System.Collections;

abstract public class Item : MonoBehaviour {

	public string itemName;
	public int level;
	public int comboThreshold;
	public int breakResistance;
	public string description;
	private int damage = 0;

	public int TakenDamage(){
		return damage;
	}

	public void TakeDamage(int damage){
		this.damage += damage;
	}

	public bool IsBroken(){
		if (breakResistance < 0) {
			return false;
		}
		else {
			return (damage > breakResistance);
		}
	}

	abstract public bool CanBeSelected (int combo);
}
