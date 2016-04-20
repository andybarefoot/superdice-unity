using UnityEngine;
using System.Collections;

public class JustRollDice : MonoBehaviour {

	private JustPlayManager justPlayManager;

	// Use this for initialization
	void Start(){
		justPlayManager = GameObject.Find ("JustPlayManager").GetComponent<JustPlayManager> ();
	}
	
	void OnMouseDown(){
		justPlayManager.rollDice ();	
	}
	
}
