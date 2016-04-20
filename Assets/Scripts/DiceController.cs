using UnityEngine;
using System.Collections;

public class DiceController : MonoBehaviour {

	private GameManager gameManager;
	public Sprite[] dieSprites;
	private int[] occupiedLocks = {0,0,0,0,0,0};

	// Use this for initialization
	void Start(){
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void hideDice(){
		print ("DiceController:hideDice()");
		for(int i = 1; i <= 6; i++){
			GameObject die = transform.Find("Die" + i).gameObject;
			die.renderer.enabled = false;
		}
	}
	
	public void hideDiceID(int ID){
		GameObject die = transform.Find("Die" + ID).gameObject;
		die.renderer.enabled = false;
	}
	
	public void showDice(){
		print ("DiceController:showDice()");
		for (int i = 0; i < gameManager.diceArray.Length; i++){
			int p = i+1;
			GameObject die = transform.Find("Die" + p).gameObject;
			die.GetComponent<SpriteRenderer> ().sprite = dieSprites [gameManager.diceArray[i]-1];
		}
		for(int i = 1; i <= 6; i++){
			GameObject die = transform.Find("Die" + i).gameObject;
			die.renderer.enabled = true;
		}
	}	

	public void moveDie(int dieID){
		print ("DiceController:moveDie(int dieID)");
		int i = dieID-1;
		GameObject die = transform.Find("Die" + dieID).gameObject;
		if (gameManager.lockedArray [i] == 1) {
			bool found = false;
			for(int x=0; x<6; x++){
				if(!found && occupiedLocks[x]==0){
					Vector3 diePos = new Vector3 ( 10.2f,8.25F-(x*1.5f), 0f);
					Vector3 dieRot = new Vector3 ( 0, 0, 0);
					die.transform.position = diePos;
					die.transform.localEulerAngles = dieRot;
					occupiedLocks[x] = dieID;
					found = true;
				}
			}
		} else if(gameManager.lockedArray [i] == 0) {
			for(int x=0; x<6; x++){
				if(occupiedLocks[x] == dieID){
					occupiedLocks[x] = 0;
				}
			}
			Vector3 diePos = die.GetComponent<Die> ().startPos;
			Vector3 dieRot = new Vector3 (0, 0, Random.Range(0,360));
			die.transform.position = diePos;
			die.transform.localEulerAngles = dieRot;
		}
	}

	public void moveAllDice(){
		print ("DiceController:moveAllDice()");
		for(int i = 1; i <= 6; i++){
			moveDie (i);
		}
	}
}
