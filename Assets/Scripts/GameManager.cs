using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	// for referencing other scripts
	private LevelManager levelManager;
	private PlayerManager playerManager;
	private ScoreController scoreController;
	private DiceController diceController;
	private CurrentController currentController;
	// player variables
	// EDIT	public string[] playerArray = {"Arnold", "Bob", "Claire", "Debra", "Ernie"};
// NEW
	public string[] playerArray;
// END NEW
	public int[] playerScores = {0,0,0,0,0,0};
	public int currentPlayer = 0;
	public int currentRoll = 0;
	// score variables
	public int targetScore;
	public int rollScore = 0;
	public int selectedScore = 0;
	public int currentScore = 0;
	public int currentBank = 0;
	public bool currentBust = false;
	// dice variables
	public int[] diceArray = {0,0,0,0,0,0};
	public int[] scoreArray = {0,0,0,0,0,0}; // the number of each score, so 3 twos and 3 sixes would be [0,3,0,0,0,3] 
	// dice have 3 states: 0 - free, 1 - selected, 2 - locked
	public int[] lockedArray = {0,0,0,0,0,0};
	// win variables
	private bool scoreReached = false;
	private int firstPlayer = 0;

	// Use this for initialization
	void Start(){
		print ("I'm starting!!!");
		// find other scripts
		levelManager = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();
//		playerManager = GameObject.Find ("PlayerManager").GetComponent<PlayerManager> ();
		scoreController = GameObject.Find ("PlayerScores").GetComponent<ScoreController> ();
		diceController = GameObject.Find ("Dice").GetComponent<DiceController> ();
		currentController = GameObject.Find ("CurrentPlayer").GetComponent<CurrentController> ();
		// get player Array from playerManager
// EDIT	playerArray = playerManager.playerArray;
		playerArray = PlayerManager.playerArray;
		targetScore = PlayerManager.targetScore;
		// populate score array to match number of players
		for (int i = 0; i < playerArray.Length; i++){
			scoreArray[i]=0;
		}
		// generate players
		scoreController.generatePlayers ();
		// start game
		startGame ();
	}
	

	// Update is called once per frame
	void Update () {
	
	}

	void displayMessage(string messageStr){
		GameObject message = GameObject.Find("Messages").gameObject;
		GameObject gameMessage = message.transform.Find("GameMessage").gameObject;
		Text MessageText = gameMessage.GetComponent<Text>();
		MessageText.text = messageStr;
	}
	
	public void startGame(){
		print ("startGame()");
		print ("Player number: " + currentPlayer);
		scoreReached = false;
		firstPlayer = 0;
		// set all player scores to zero
		resetScores();
		scoreController.setTarget ();
		scoreController.showScores ();
		// reset to player 1
		currentPlayer = 0;
		currentScore = 0;
		currentRoll = 0;
		currentBank = playerScores[currentPlayer];
		// set current scores to zero
		currentController.ResetPlayer ();
		// unlock all dice
		resetDice();
		showRoll ();
		hideBank ();
		hideNext ();
		hideNew ();
		hideMain ();
		displayMessage ("Let's start! It's "+playerArray[currentPlayer]+" to play. Click the Roll Dice button.");
	}
	
	void showRoll(){
		showButton ("RollDice");
/*		print ("showRoll()");
		GameObject rollDice = GameObject.Find("RollDice").gameObject;
		rollDice.renderer.enabled = true;
		Vector3 buttonPos = new Vector3 (13f, rollDice.transform.position.y, 0f);
		rollDice.transform.position = buttonPos;
*/	}
	
	void hideRoll(){
		hideButton ("RollDice");
		/*		print ("hideRoll()");
		GameObject rollDice = GameObject.Find("RollDice").gameObject;
		rollDice.renderer.enabled = false;
		Vector3 buttonPos = new Vector3 (30f, rollDice.transform.position.y, 0f);
		rollDice.transform.position = buttonPos;
*/	}
	
	void showBank(){
		showButton ("BankPoints");
/*		print ("showBank()");
		GameObject bankPoints = GameObject.Find("BankPoints").gameObject;
		bankPoints.renderer.enabled = true;
		Vector3 buttonPos = new Vector3 (13f, bankPoints.transform.position.y, 0f);
		bankPoints.transform.position = buttonPos;
*/	}
	
	void hideBank(){
		hideButton ("BankPoints");
/*		print ("hideBank()");
		GameObject bankPoints = GameObject.Find("BankPoints").gameObject;
		bankPoints.renderer.enabled = false;
		Vector3 buttonPos = new Vector3 (30f, bankPoints.transform.position.y, 0f);
		bankPoints.transform.position = buttonPos;
*/	}
	
	void showNext(){
		showButton ("NextPlayer");
/*		print ("showNext()");
		GameObject nextPlayer = GameObject.Find("NextPlayer").gameObject;
		nextPlayer.renderer.enabled = true;
		Vector3 buttonPos = new Vector3 (13f, nextPlayer.transform.position.y, 0f);
		nextPlayer.transform.position = buttonPos;
*/	}
	
	void hideNext(){
		hideButton ("NextPlayer");
/*		print ("hideNext()");
		GameObject nextPlayer = GameObject.Find("NextPlayer").gameObject;
		nextPlayer.renderer.enabled = false;
		Vector3 buttonPos = new Vector3 (30f, nextPlayer.transform.position.y, 0f);
		nextPlayer.transform.position = buttonPos;
*/	}
	
	void showMain(){
		showButton ("MainMenu");
/*		print ("showMain()");
		GameObject mainMenu = GameObject.Find("MainMenu").gameObject;
		mainMenu.renderer.enabled = true;
		Vector3 buttonPos = new Vector3 (13f, mainMenu.transform.position.y, 0f);
		mainMenu.transform.position = buttonPos;
*/	}
	
	void hideMain(){
		hideButton ("MainMenu");
/*		print ("hideMain()");
		GameObject mainMenu = GameObject.Find("MainMenu").gameObject;
		mainMenu.renderer.enabled = false;
		Vector3 buttonPos = new Vector3 (30f, mainMenu.transform.position.y, 0f);
		mainMenu.transform.position = buttonPos;
*/	}
	
	void showNew(){
		showButton ("NewGame");
/*		print ("showNew()");
		GameObject newGame = GameObject.Find("NewGame").gameObject;
		newGame.renderer.enabled = true;
		Vector3 buttonPos = new Vector3 (13f, newGame.transform.position.y, 0f);
		newGame.transform.position = buttonPos;
*/	}
	
	void hideNew(){
		hideButton ("NewGame");
/*		print ("hideNew()");
		GameObject newGame = GameObject.Find("NewGame").gameObject;
		newGame.renderer.enabled = false;
		Vector3 buttonPos = new Vector3 (30f, newGame.transform.position.y, 0f);
		newGame.transform.position = buttonPos;
*/	}

	void showButton(string buttonName){
		print ("showButton()");
		GameObject button = GameObject.Find(buttonName).gameObject;
		if (!button.renderer.enabled) {
			Vector3 buttonPos = new Vector3 (button.transform.position.x - 30f, button.transform.position.y - 30f, 0f);
			button.transform.position = buttonPos;
			button.renderer.enabled = true;
		}
	}

	void hideButton(string buttonName){
		print ("hideButton()");
		GameObject button = GameObject.Find(buttonName).gameObject;
		if(button.renderer.enabled){
			Vector3 buttonPos = new Vector3 (button.transform.position.x + 30f, button.transform.position.y + 30f, 0f);
			button.transform.position = buttonPos;
			button.renderer.enabled = false;
		}
	}

	void resetScores(){
		print ("resetScores()");
		for (int i = 0; i < playerScores.Length; i++) {
			playerScores [i] = 0;
		}
	}
	
	void resetDice(){
		print ("resetDice()");
		for (int i = 0; i < lockedArray.Length; i++) {
			lockedArray [i] = 0;
		}
		diceController.hideDice ();
		diceController.moveAllDice ();
	}

	public void clickDie(string dieName){
		print ("clickDie(string dieName)");
		int dieID = int.Parse(dieName.Substring(3, 1));
		int i = dieID-1;
		if (lockedArray [i] != 2) {
			if (lockedArray [i] == 1) {
				lockedArray [i] = 0;
			} else {
				lockedArray [i] = 1;
			}
			changeSelected();
		}
		diceController.moveDie (dieID);
	}
	
	// roll all unlocked dice
	public void rollDice(){
		print ("rollDice()");
		currentRoll++;
		currentScore = selectedScore + currentScore;
		selectedScore = 0;
		currentController.setRollScore ();
		currentController.setCurrentScore ();
		int countFree = 0;
		for (int i = 0; i < diceArray.Length; i++) {
			if (lockedArray [i] == 1) {
				lockedArray [i] = 2;
			}else if (lockedArray [i] == 0) {
				countFree++;
			}
		}
		rollScore = 0;
		//		turnScoreCurrent = turnScoreTemp;
		//		showScore();
		clearScoreArray ();
		for (int i = 0; i < diceArray.Length; i++) {
			if(countFree==0){
				lockedArray [i] = 0;
			}
			if (lockedArray [i] == 0) {
				int rollInt = Random.Range (1, 7);
				diceArray [i] = rollInt;
			}
		}
		diceController.moveAllDice ();
		diceController.showDice ();
		if(checkNoScore ()){
			noScore();
		}else{
			displayMessage ("Click the scoring dice you want to lock. Click them again to unlock if you change your mind.");
		}
		hideRoll ();
		hideBank ();
	}

	bool checkScoreArray(){
		print ("checkScoreArray()");
		bool isEmpty = true;
		for (int i = 0; i < 6; i++){
			if(scoreArray[i]!=0){
				isEmpty = false;
			}
		}
		return isEmpty;
	}
	

	
	// check if player scored nothing
	bool checkNoScore(){
		print ("checkNoScore()");
		clearScoreArray ();
		// put all unlocked dice into score array
		for (int i = 0; i < diceArray.Length; i++){
			if(lockedArray[i] <= 1){
				scoreArray[diceArray[i]-1]++;
			}
		}
		int checkScore = calculateScore();
		if (checkScore == 0) {
			return true;
		} else {
			return false;
		}
	}

	public int calculateScore(){
		print ("calculateScore()");
		// running score
		int runningScore = 0;
		// will hold value of 4 of a kind
		int quartet = 0;
		// will hold value of first 3 of a kind
		int triplet = 0;
		// will hold number of sets of 2
		int numOf2s = 0;
		int count = 0;
		bool oneOfEach = true;
		// loop through scoreArray to see what we have
		for (int i = 0; i < 6; i++){
			count = count+scoreArray[i];
			if(scoreArray[i]==6){
				runningScore = runningScore + 3000;
				scoreArray[i]=0;
			}
			if(scoreArray[i]==5){
				runningScore = runningScore + 2000;
				scoreArray[i]=0;
			}
			if(scoreArray[i]==4){
				quartet=i+1;
				scoreArray[i]=0;
			}
			if(scoreArray[i]==3){
				if(triplet==0){
					triplet=i+1;
					scoreArray[i]=0;
				}else{
					triplet=7;
					scoreArray[i]=0;
				}
			}
			if(scoreArray[i]==2){
				numOf2s++;
			}
			if(scoreArray[i]!=1)oneOfEach=false;
		}
		if(oneOfEach && (count==6)){
			runningScore = runningScore + 1500;
			clearScoreArray();
		}
		if(quartet!=0){
			if(numOf2s==1){
				runningScore = runningScore + 1500;
				clearScoreArray();
			}else{
				runningScore = runningScore + 1000;
				scoreArray[quartet-1]=0;
			}
		}
		if(numOf2s==3){
			runningScore = runningScore + 1500;
			clearScoreArray();
		}
		if(triplet==7){
			runningScore = runningScore + 2500;
			clearScoreArray();
		}else if(triplet==1){
			runningScore = runningScore + 300;
			scoreArray[triplet-1]=0;
		}else if(triplet!=0){
			runningScore = runningScore + triplet*100;
			scoreArray[triplet-1]=0;
		}
		runningScore = runningScore + scoreArray[0]*100;
		//added new
		scoreArray[0]=0;
		runningScore = runningScore + scoreArray[4]*50;
		//added new
		scoreArray[4]=0;
		print(runningScore);
		return runningScore;
	}

	public void changeSelected(){
		print ("changeSelected()");
		clearScoreArray ();
		// put all rolled dice into score array
		for (int i = 0; i < diceArray.Length; i++){
			if(lockedArray[i] == 1){
				scoreArray[diceArray[i]-1]++;
			}
		}
		selectedScore = calculateScore();
		print (selectedScore);
		currentController.setRollScore ();
		if (selectedScore != 0 && checkScoreArray ()) {
			showRoll ();
			if((selectedScore + currentScore + playerScores[currentPlayer]) >= 500){
				showBank ();
				displayMessage ("Finished selecting? Click Roll Dice to roll the unlocked dice again. Or Bank Points to finish and safeguard your points.");
			} else {
				displayMessage ("Finished selecting? You need 500 points before you can Bank so Roll again.");
			}
		} else {
			hideRoll ();
			hideBank ();
			if (selectedScore == 0) {
				displayMessage ("You haven't selected a scoring comnbination yet. Select more dice.");
			} else {
				displayMessage ("Some of the dice you currently have selected do not score points. Change your selection.");
			}
		}
	}

	// when a player rolls no score
	void noScore(){
		print ("noScore()");
		//		lockDice();
//		// --- wait 2 seconds
//		rollScoreCurrent = 0;
//		turnScoreCurrent = 0;
//		turnScoreTemp = 0;
//		showScore();
		// --- display Bust message
		// --- display Next Player button
		displayMessage ("THAT'S FARKLE! Bad luck, you've scored no points this round.");
		showNext ();
	}

	void clearScoreArray(){
		print ("clearScoreArray()");
		for (int i = 0; i < 6; i++){
			scoreArray[i]=0;
		}
	}

	public void bank(){
		print ("bank()");
		currentScore = selectedScore + currentScore;
		playerScores[currentPlayer] = playerScores[currentPlayer] + currentScore;
		if(!scoreReached && (playerScores[currentPlayer] >= targetScore)){
			firstPlayer = currentPlayer;
			scoreReached = true;
		}
		selectedScore = 0;
		currentScore = 0;
		scoreController.showScores();
		nextPlayer();
	}
	
	public void gameOver(){
		print ("gameOver()");
		hideRoll ();
		hideBank ();
		hideNext ();
		showNew ();
		showMain ();
		int winner = 0;
		int winnerScore = 0;
		for (int i = 0; i < playerArray.Length; i++){
			if(playerScores[i]>winnerScore){
				winnerScore = playerScores[i];
				winner = i;
			}
		}
		displayMessage ("GAME OVER! " + playerArray [winner] + " has won with a score of " + winnerScore);
	}
	
	public void nextPlayer(){
		print ("nextPlayer()");
		print (scoreReached);
		print (currentPlayer);
		print (firstPlayer);
		showRoll ();
		hideBank ();
		currentPlayer++;
		if (currentPlayer >= playerArray.Length) {
			currentPlayer = 0;
		}
		if (scoreReached && (currentPlayer == firstPlayer)) {
			gameOver();
		}else{
			currentRoll = 0;
			currentScore = 0;
			currentBank = playerScores[currentPlayer];
			currentController.ResetPlayer ();
			resetDice();
			hideNext ();
			if (scoreReached) {
				displayMessage (playerArray [firstPlayer] + " has reached the target score. All other players have 1 more turn. " + playerArray [currentPlayer] + " to play.");
			} else {
				displayMessage ("It's " + playerArray [currentPlayer] + " to play. Click the Roll Dice button.");
			}
		}
	}
}

