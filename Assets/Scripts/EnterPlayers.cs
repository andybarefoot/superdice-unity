using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnterPlayers : MonoBehaviour {

	private PlayerManager playerManager;
	public Slider playerSlider;
	public Sprite[] dieSprites;

	// Use this for initialization
	void Start(){
		playerManager = GameObject.Find ("PlayerManager").GetComponent<PlayerManager> ();
	}

	void Update () {
		int tempPlayers = (int) playerSlider.value;
		hidePlayers(tempPlayers);
	}

	public void hidePlayers(int nPlayers){
//		print ("EnterPlayers:hidePlayers()");
		playerSlider.value = nPlayers;
		PlayerManager.playerTotal = nPlayers;
		Sprite dieSprite = GameObject.Find("NumberDie").gameObject.GetComponent<SpriteRenderer> ().sprite = dieSprites [nPlayers -1];

		for(int i = 1; i <= 6; i++){
			GameObject player = transform.Find("EnterPlayer" + i).gameObject;
			if(i<=nPlayers){
				//show
				player.SetActive(true);
			}else{
				//hide
				player.SetActive(false);
			}
		}
	}
}
