using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JustPlayManager : MonoBehaviour {
	// for referencing other scripts
	private LevelManager levelManager;
	private JustDiceController diceController;
	public int diceTotal;
	// dice array holds values of each dice
	public int[] diceArray = {0,0,0,0,0,0,0,0,0,0,0,0};
	// locked array holds status of each dice
	public int[] lockedArray = {0,0,0,0,0,0,0,0,0,0,0,0};
	// 0 - unlocked and playing
	// 1 - locked and playing
	// 2 - not playing

	void Start(){
		levelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();
		diceController = GameObject.Find ("Dice").GetComponent<JustDiceController> ();
		diceTotal = JustDiceManager.diceTotal;
		for (int i = 1; i < 13; i++) {
			if(i>diceTotal){
//				diceController.hideDiceID(i);
				lockedArray[i-1] = 2;
			}
		}
		diceController.hideDice ();
		diceController.moveAllDice ();
	}

	public void clickDie(string dieName){
		int dieID = int.Parse(dieName.Substring(3));
		int i = dieID-1;
		if (lockedArray [i] == 1) {
			lockedArray [i] = 0;
		} else {
			lockedArray [i] = 1;
		}
		diceController.moveDie (dieID);
	}

	public void rollDice(){
		for (int i = 0; i < diceArray.Length; i++) {
			if (lockedArray [i] == 0) {
				int rollInt = Random.Range (1, 7);
				diceArray [i] = rollInt;
			}
		}
//		diceController.moveAllDice ();
		diceController.showDice ();
	}
	
}

