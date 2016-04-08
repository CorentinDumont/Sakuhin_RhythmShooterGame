<<<<<<< HEAD
﻿// attached to the background of the shooter game to give the illusion of movement by scrolling the background

using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
using System.Collections;

public class Scroll : MonoBehaviour {

	public float scrollSpeed = -0.1f;

	void Update()
	{
		GetComponent<Renderer> ().material.SetTextureOffset ("_MainTex", new Vector2 (Time.time * scrollSpeed,0));
	}
}
