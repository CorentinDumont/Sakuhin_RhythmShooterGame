<<<<<<< HEAD
﻿// definition of the MenuChoice abstract class (MenuChoice.cs)
// used for the item of the pauseMenu of the Main game to quit the application

using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
using System.Collections;

public class PauseMenuQuit : MenuChoice {

	override protected void Effect(){
		Application.Quit();
	}
}
