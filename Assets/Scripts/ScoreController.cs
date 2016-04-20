using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour {

	private GameManager gameManager;

	void Start(){
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}
	
	public void generatePlayers(){
		print ("ScoreController:generatePlayers()");
		for (int i = 0; i < 6; i++){
			int p = i+1;
			GameObject playerDisplay = transform.Find("PlayerDisplay" + p).gameObject;
			if(i < gameManager.playerArray.Length){
				GameObject playerName = playerDisplay.transform.Find("PlayerName").gameObject;
				Text nameText = playerName.GetComponent<Text>();
				nameText.text = gameManager.playerArray[i];
			}else{
				Destroy (playerDisplay);
			}
		}
	}

	public void setTarget(){
		print ("ScoreController:setTarget()");
		GameObject targetDisplay = transform.Find("Target").gameObject;
		GameObject targetScore = targetDisplay.transform.Find("TargetScore").gameObject;
		Text targetText = targetScore.GetComponent<Text>();
		targetText.text = gameManager.targetScore.ToString();
	}

	public void showScores(){
		print ("ScoreController:showScores()");
		for (int i = 0; i < gameManager.playerArray.Length; i++){
			int p = i+1;
			GameObject playerDisplay = transform.Find("PlayerDisplay" + p).gameObject;
			GameObject playerScore = playerDisplay.transform.Find("PlayerScore").gameObject;
			Text scoreText = playerScore.GetComponent<Text>();
			scoreText.text = gameManager.playerScores[i].ToString ();
		}
	}
	
}