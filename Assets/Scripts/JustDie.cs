using UnityEngine;
using System.Collections;

public class JustDie : MonoBehaviour {

	private JustPlayManager justPlayManager;
//	private DiceController diceController;
	public Vector3 startPos;
	public Vector3 startRot;

	// Use this for initialization
	void Start(){
		justPlayManager = GameObject.Find ("JustPlayManager").GetComponent<JustPlayManager> ();
//		diceController = GameObject.Find ("Dice").GetComponent<DiceController> ();
		startPos = new Vector3 ( this.transform.position.x, this.transform.position.y,  this.transform.position.z);
		startRot = new Vector3 ( this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y,  this.transform.rotation.eulerAngles.z);
	}

	void OnMouseDown(){
		justPlayManager.clickDie (this.name);	
	}
	
}