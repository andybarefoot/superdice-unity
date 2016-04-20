using UnityEngine;
using System.Collections;

public class BankPoints : MonoBehaviour {

	
	private GameManager gameManager;
	
	// Use this for initialization
	void Start(){
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}
	
	void OnMouseDown(){
		if (this.renderer.enabled) {
			print ("RollDice:OnMouseDown()");
			gameManager.bank ();	
		}
	}
}
