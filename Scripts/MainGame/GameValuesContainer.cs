using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameValuesContainer {

	public static GameValuesContainer container;

	public ShooterEventsHandler shooterHandler;
	public RhythmEventsHandler rhythmHandler;
	public MenuWrapper menuWrapper;

	public MovingObjectsContainer movingObjectsContainers;
	public GameObject particlesContainer;
	public GameObject enemiesContainer;
	public GameObject bubblesContainer;

	public float stageDuration;

	public int shootingScore = 0;
	public int lives = 3;
	public Armor[] possibleArmors;
	public int currentArmor = -1;
	public Weapon[] possibleWeapons;
	public int currentWeapon = -1;

	public int combo = 0; // current combo
	public int maxCombo = 0; // biggest combo the player has done in the play
	public int[] rhythmScores = new int[6] {0, 0, 0, 0, 0, 0}; // number of Miss, Bad, Almost, Good, Great and Fantastic respectively

}
