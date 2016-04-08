<<<<<<< HEAD
﻿// definition of the MenuChoice abstract class (MenuChoice.cs)
// used for the item of the pauseMenu of the Main game to go back to the main menu (title)

using UnityEngine;
=======
﻿using UnityEngine;
>>>>>>> c231e09f7cec6e7c0dbe4ce60c8437890f4a3479
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenuMainMenu : MenuChoice {

	override protected void Effect(){
		SceneManager.LoadScene ("Title");
	}
}
