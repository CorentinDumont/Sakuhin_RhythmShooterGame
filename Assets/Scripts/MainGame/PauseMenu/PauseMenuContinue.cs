<<<<<<< HEAD
﻿// definition of the MenuChoice abstract class (MenuChoice.cs)
// used for the item of the pauseMenu of the Main game to unpause the game

using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
using System.Collections;

public class PauseMenuContinue : MenuChoice {

	public PauseMenuWrapper pauseMenuWrapper;

	override protected void Effect(){
<<<<<<< HEAD
		pauseMenuWrapper.TogglePause ();	// unpause the game (the item is not active when the game is unpaused, so it cannot be used to pause)
=======
		pauseMenuWrapper.TogglePause ();
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
	}
}
