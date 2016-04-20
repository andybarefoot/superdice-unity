using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour {

	private GameManager gameManager;
//	private DiceController diceController;
	public Vector3 startPos;
	public Vector3 startRot;

	// Use this for initialization
	void Start(){
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
//		diceController = GameObject.Find ("Dice").GetComponent<DiceController> ();
		startPos = new Vector3 ( this.transform.position.x, this.transform.position.y,  this.transform.position.z);
		startRot = new Vector3 ( this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y,  this.transform.rotation.eulerAngles.z);
	}

	void OnMouseDown(){
		print ("Die:OnMouseDown()");
		gameManager.clickDie (this.name);	
	}

/*
 * public Sprite[] dieSprites;
	private int dieValue;
	private bool rolling = false;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (rolling) {
			dieValue++;	
			if (dieValue >= 6) {
				dieValue = 0;
			}
			int spriteIndex = dieValue;
			this.GetComponent<SpriteRenderer> ().sprite = dieSprites [spriteIndex];
		}
	}
	
	public void RollDie () {
		print ("roll die");
		rolling = true;
	}

	void OnMouseDown(){
		lockDie ();	
	}
	public void lockDie(){
		print ("lock die");
		print (this);
	}
*/

}