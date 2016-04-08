<<<<<<< HEAD
﻿// Attached to the borders of the game, destroy any colliding objects (in particular the bullets, laser, asteroid any enemies that are not destroyed by the player)
// avoid objects from becoming too numerous by destroying the objects that are not on the screen anymore)

using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
using System.Collections;

public class GameBorder : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		Destroy (other.gameObject);
	}
}
