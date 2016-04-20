using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CurrentController : MonoBehaviour {

	private GameManager gameManager;
	
	// Use this for initialization
	void Start(){
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}

	// Update is called once per frame
	void Update () {
		
	}
	
	public void setRollScore(){
		print ("CurrentController:setRollScore(int playerID)");
		GameObject currentBank = transform.Find("RollScore").gameObject;
		Text currentBankText = currentBank.GetComponent<Text>();
		currentBankText.text = "" + gameManager.selectedScore;
	}
	
	public void setCurrentScore(){
		print ("CurrentController:setCurrentScore(int playerID)");
		GameObject currentScore = transform.Find("CurrentScore").gameObject;
		Text currentScoreText = currentScore.GetComponent<Text>();
		currentScoreText.text = "" + gameManager.currentScore;
	}
	
	public void ResetPlayer(){
		print ("CurrentController:ResetPlayer(int playerID)");
		GameObject currentName = transform.Find("CurrentName").gameObject;
		Text currentNameText = currentName.GetComponent<Text>();
		currentNameText.text = "" + gameManager.playerArray[gameManager.currentPlayer];
		GameObject currentBank = transform.Find("RollScore").gameObject;
		Text currentBankText = currentBank.GetComponent<Text>();
		currentBankText.text = "" + gameManager.selectedScore;
		GameObject currentScore = transform.Find("CurrentScore").gameObject;
		Text currentScoreText = currentScore.GetComponent<Text>();
		currentScoreText.text = "" + gameManager.currentScore;
	}
	
}
