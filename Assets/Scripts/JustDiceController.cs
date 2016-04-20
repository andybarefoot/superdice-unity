using UnityEngine;
using System.Collections;

public class JustDiceController : MonoBehaviour {

	private JustPlayManager justPlayManager;
	public Sprite[] dieSprites;
	public int[] occupiedLocks = {0,0,0,0,0,0,0,0,0,0,0,0};
	
	// Use this for initialization
	void Start(){
		justPlayManager = GameObject.Find ("JustPlayManager").GetComponent<JustPlayManager> ();
	}
	
	public void hideDice(){
		for(int i = 1; i <= 12; i++){
			GameObject die = transform.Find("Die" + i).gameObject;
			die.renderer.enabled = false;
		}
	}
	
	public void hideDiceID(int ID){
		GameObject die = transform.Find("Die" + ID).gameObject;
		die.renderer.enabled = false;
	}
	
	public void showDice(){
		for (int i = 0; i < justPlayManager.diceArray.Length; i++){
			if(justPlayManager.lockedArray[i]!=2){
				int p = i+1;
				GameObject die = transform.Find("Die" + p).gameObject;
				print ("Debug");
				print (justPlayManager.diceArray[i]-1);
				die.GetComponent<SpriteRenderer> ().sprite = dieSprites [justPlayManager.diceArray[i]-1];
			}
		}
		for(int i = 1; i <= 12; i++){
			if(justPlayManager.lockedArray[i-1]!=2){
				GameObject die = transform.Find("Die" + i).gameObject;
				die.renderer.enabled = true;
			}
			if(justPlayManager.lockedArray[i-1]==0){
				moveDie(i);
			}
		}
	}	

	public void moveDie(int dieID){
		int i = dieID-1;
		GameObject die = transform.Find("Die" + dieID).gameObject;
		print (die);
		if (justPlayManager.lockedArray [i] == 1) {
			print ("debug1");
			bool found = false;
			for(int x=0; x<12; x++){
				if(!found && occupiedLocks[x]==0){
					Vector3 diePos = new Vector3 ( 10.2f,8.25F-(x*1.5f), 0f);
					if(x<6){
						diePos = new Vector3 ( 10.2f,8.25F-(x*1.5f), 0f);
					}else{
						diePos = new Vector3 ( 11.75f,8.25F-((x-6)*1.5f), 0f);
					}
					Vector3 dieRot = new Vector3 ( 0, 0, 0);
					die.transform.position = diePos;
					die.transform.localEulerAngles = dieRot;
					occupiedLocks[x] = dieID;
					found = true;
				}
			}
		} else if(justPlayManager.lockedArray [i] == 0) {
			print ("debug2");
			for(int x=0; x<12; x++){
				if(occupiedLocks[x] == dieID){
					occupiedLocks[x] = 0;
				}
			}
			Vector3 diePos = die.GetComponent<JustDie> ().startPos;
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
