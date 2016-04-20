using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	const string NUMBER_OF_PLAYERS_F_KEY = "number_players_f";
	const string PLAYER_NAME_F_1_KEY = "player_f_1";
	const string PLAYER_NAME_F_2_KEY = "player_f_2";
	const string PLAYER_NAME_F_3_KEY = "player_f_3";
	const string PLAYER_NAME_F_4_KEY = "player_f_4";
	const string PLAYER_NAME_F_5_KEY = "player_f_5";
	const string PLAYER_NAME_F_6_KEY = "player_f_6";
	const string TARGET_SCORE_F_KEY = "target_score_f";

	private LevelManager levelManager;
	private EnterPlayers enterPlayers;

	public static int targetScore;
	public static int playerTotal = 6;
	public static string[] playerArray = {"Player 1","Player 2","Player 3","Player 4","Player 5","Player 6"};
	public Slider targetSlider;

	void Awake() {
	}	
	
	void Start(){
		levelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();
		enterPlayers = GameObject.Find ("EnterPlayers").GetComponent<EnterPlayers> ();
		print (GetTargetScore());
		if (GetTargetScore () != 0) {
			targetScore = GetTargetScore ();
		} else {
			targetScore = 10000;
		}
		targetSlider.value = targetScore/500;
		UpdateTargetText ();
		for(int i = 0; i < playerTotal; i++){
			int p=i+1;
			GameObject playerName = GameObject.Find("EnterPlayers/EnterPlayer"+p+"/EnterPlayer");
			if(GetSavedPlayerNames(p)!="") {
				playerName.GetComponent<InputField>().text = GetSavedPlayerNames(p);
			} else {
				playerName.GetComponent<InputField>().text = playerArray[i];
			}
		}
		if (GetNumberPlayers() != 0) {
			enterPlayers.hidePlayers (GetNumberPlayers());
		} else {
			enterPlayers.hidePlayers (playerTotal);
		}
		setPlayers ();
	}

	void Update () {
		int tempTarget = (int) targetSlider.value;
		targetScore = 500 * tempTarget;
		UpdateTargetText ();
	}
	
	public void startGame(){
		setPlayers ();
		setScore ();
		loadGame ();
	}

	void setScore (){
		SetTargetScore (targetScore);
	}
	
	void UpdateTargetText (){
		GameObject scoreText = GameObject.Find ("EnterPlayers/TargetScore/ScoreText");
		scoreText.GetComponent<Text> ().text = "Target score: " + targetScore;
	}
	
	public void setPlayers(){
		playerArray = new string[playerTotal];
		SetNumberPlayers (playerTotal);
		for(int i = 0; i < playerTotal; i++){
			int p=i+1;
			GameObject playerName = GameObject.Find("EnterPlayers/EnterPlayer"+p+"/EnterPlayer");
			if(playerName){
				InputField playerNameF = playerName.GetComponent<InputField>();
				playerArray[i] = playerNameF.text;
				SetSavedPlayerNames(p, playerNameF.text);
			}
		}
	}

	public void loadGame(){
		levelManager.LoadLevel ("Game");
	}



// GAME PREFERENCE HANDLERS

	public static void SetTargetScore (int score){
		if (score >= 500 && score <= 20000) {
			PlayerPrefs.SetInt (TARGET_SCORE_F_KEY, score);
		} else {
			Debug.LogError ("Score out of range");
		}
	}
	
	public static int GetTargetScore(){
		return PlayerPrefs.GetInt (TARGET_SCORE_F_KEY);
	}
	
	public static void SetNumberPlayers (int players){
		if (players >= 1 && players <= 6) {
			PlayerPrefs.SetInt (NUMBER_OF_PLAYERS_F_KEY, players);
		} else {
			Debug.LogError ("Number of players out of range");
		}
	}
	
	public static int GetNumberPlayers(){
		return PlayerPrefs.GetInt (NUMBER_OF_PLAYERS_F_KEY);
	}
	
	public void SetSavedPlayerNames(int playerID, string playerName){
		if (playerID == 1) {
			PlayerPrefs.SetString (PLAYER_NAME_F_1_KEY, playerName);
		} else if (playerID == 2) {
			PlayerPrefs.SetString (PLAYER_NAME_F_2_KEY, playerName);
		} else if (playerID == 3) {
			PlayerPrefs.SetString (PLAYER_NAME_F_3_KEY, playerName);
		} else if (playerID == 4) {
			PlayerPrefs.SetString (PLAYER_NAME_F_4_KEY, playerName);
		} else if (playerID == 5) {
			PlayerPrefs.SetString (PLAYER_NAME_F_5_KEY, playerName);
		} else if (playerID == 6) {
			PlayerPrefs.SetString (PLAYER_NAME_F_6_KEY, playerName);
		} else {
			Debug.LogError ("Player ID out of range");
		}
	}
	
	public static string GetSavedPlayerNames(int playerID){
		if (playerID == 1) {
			return PlayerPrefs.GetString (PLAYER_NAME_F_1_KEY);
		} else if (playerID == 2) {
			return PlayerPrefs.GetString (PLAYER_NAME_F_2_KEY);
		} else if (playerID == 3) {
			return PlayerPrefs.GetString (PLAYER_NAME_F_3_KEY);
		} else if (playerID == 4) {
			return PlayerPrefs.GetString (PLAYER_NAME_F_4_KEY);
		} else if (playerID == 5) {
			return PlayerPrefs.GetString (PLAYER_NAME_F_5_KEY);
		} else if (playerID == 6) {
			return PlayerPrefs.GetString (PLAYER_NAME_F_6_KEY);
		} else {
			Debug.LogError ("Player ID out of range");
			return "";
		}
	}

}
