using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JustDiceManager : MonoBehaviour {

	const string JUST_DICE_NO_KEY = "number_dice_j";

	private LevelManager levelManager;

	public static int diceTotal = 6;
	public Slider targetSlider;
	public Sprite[] dieSprites1;
	public Sprite[] dieSprites2;

	void Awake() {
	}	
	
	void Start(){
		levelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();
		if (GetDiceNumber () != 0) {
			diceTotal = GetDiceNumber ();
		} else {
			diceTotal = 6;
		}
		targetSlider.value = diceTotal;
	}

	void Update () {
		diceTotal = (int) targetSlider.value;
		if (diceTotal > 6) {
			GameObject.Find ("NumberDie2").gameObject.renderer.enabled = true;
			Sprite dieSprite2 = GameObject.Find ("NumberDie2").gameObject.GetComponent<SpriteRenderer> ().sprite = dieSprites2 [diceTotal - 7];
			Sprite dieSprite1 = GameObject.Find ("NumberDie1").gameObject.GetComponent<SpriteRenderer> ().sprite = dieSprites1 [5];
		} else {
			GameObject.Find ("NumberDie2").gameObject.renderer.enabled = false;
			Sprite dieSprite1 = GameObject.Find ("NumberDie1").gameObject.GetComponent<SpriteRenderer> ().sprite = dieSprites1 [diceTotal - 1];
		}
	}
	
	public void startGame(){
		setDice ();
		loadGame ();
	}

	void setDice (){
		SetDiceNumber (diceTotal);
	}
	
	public void loadGame(){
		levelManager.LoadLevel ("JustDice");
	}



// GAME PREFERENCE HANDLERS

	public static void SetDiceNumber (int diceNumber){
		if (diceNumber >= 1 && diceNumber <= 12) {
			PlayerPrefs.SetInt (JUST_DICE_NO_KEY, diceNumber);
		} else {
			Debug.LogError ("Dice Number out of range");
		}
	}
	
	public static int GetDiceNumber(){
		return PlayerPrefs.GetInt (JUST_DICE_NO_KEY);
	}
	

}
