using UnityEngine;
using System.Collections;

abstract public class MenuChoice : MonoBehaviour {

	public void OnChoosen(){
		Effect ();
	}

	abstract protected void Effect ();
}
