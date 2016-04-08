<<<<<<< HEAD
﻿// definition of the MenuChoice abstract class (MenuChoice.cs)
// used for the item of the Main Menu of the Title scene to quit the application

using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
using System.Collections;

public class MainMenuQuit : MenuChoice {

	override protected void Effect(){
		Application.Quit ();
	}
}
