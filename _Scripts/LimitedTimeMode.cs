using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitedTimeMode : MonoBehaviour {

	public float gameTime;
	public float hitBonus;
	public float survivingTime;
	public Text txt_gameTime;


	public GameObject gameOverScreen;

	bool once;
	public float _timeLeft;
	public Text txt_gameOverTimeLeft;

	// Use this for initialization
	void Start () {
		once = true;
	}


	// Update is called once per frame
	void Update () {
		_timeLeft = gameTime;

		if (gameTime > 0 && !Gun._GameOver) {
			gameTime -= Time.deltaTime;
			survivingTime += Time.deltaTime;
			//int _tempGameTime = (int)(gameTime);
			txt_gameTime.text = "Time : " + gameTime.ToString ("F1");

		} else {
			
			if (once) {
				GameOver ();

			}
		}
	}

	public void HitBonus(){
		float _shotsOnTarget;
		_shotsOnTarget = this.GetComponent<Gun>()._shotsOnTarget;

		if(_shotsOnTarget < 5){
			hitBonus = 7;
		}else if(_shotsOnTarget >= 5 && _shotsOnTarget < 10){
			hitBonus = 6f;
		}else if(_shotsOnTarget >= 10 && _shotsOnTarget < 15){
			hitBonus = 5;
		}else if(_shotsOnTarget >= 15 && _shotsOnTarget < 20){
			hitBonus = 4f;
		}else if(_shotsOnTarget >= 20 && _shotsOnTarget < 25){
			hitBonus = 3;
		}else if(_shotsOnTarget >= 25 && _shotsOnTarget < 30){
			hitBonus = 2;
		}else if(_shotsOnTarget >= 30){
			hitBonus = 1;
		}

		gameTime += hitBonus;
	}


	public void GameOver(){
		Gun._GameOver = true;
		gameOverScreen.SetActive (true);
		once = false;

		txt_gameOverTimeLeft.text = "Time Left : " + _timeLeft.ToString ("F1") + " sec";

		PlayerPrefs.SetInt("TimePlayed", PlayerPrefs.GetInt("TimePlayed") + (int)survivingTime);


		// Calling Achivements

		#if UNITY_ANDROID

		if( PlayerPrefs.GetInt("TimePlayed")/60 >= 300){
			GameManager.Instance.UnlockAchievemnt(VRTHGPS.achievement_gamer);
		}
		if( PlayerPrefs.GetInt("TimePlayed")/60 >= 30){
			GameManager.Instance.UnlockAchievemnt(VRTHGPS.achievement_passionate);
		}

		if(this.gameObject.GetComponent<Gun>()._accuracy == 1){
			GameManager.Instance.UnlockAchievemnt(VRTHGPS.achievement_awper);
		}

		if(PlayerPrefs.GetInt("TotalScore") >= 1000){
			GameManager.Instance.UnlockAchievemnt(VRTHGPS.achievement_john_wick);
		}
		if(PlayerPrefs.GetInt("TotalScore") >= 5000){
			GameManager.Instance.UnlockAchievemnt(VRTHGPS.achievement_god_father);
		}


		if(PlayerPrefs.GetInt("ShotsOnTarget") >= 15){
			GameManager.Instance.UnlockAchievemnt(VRTHGPS.achievement_marksmani);
		}
		if(PlayerPrefs.GetInt("ShotsOnTarget") >= 50){
			GameManager.Instance.UnlockAchievemnt(VRTHGPS.achievement_marksmanii);
		}
		#endif

		#if UNITY_IOS

		if( PlayerPrefs.GetInt("TimePlayed")/60 >= 300){
		}
		if( PlayerPrefs.GetInt("TimePlayed")/60 >= 30){
		}

		if(this.gameObject.GetComponent<Gun>()._accuracy == 1){
		}

		if(PlayerPrefs.GetInt("TotalScore") >= 1000){
		}
		if(PlayerPrefs.GetInt("TotalScore") >= 5000){
		}


		if(PlayerPrefs.GetInt("ShotsOnTarget") >= 15){
		}
		if(PlayerPrefs.GetInt("ShotsOnTarget") >= 50){
		}

		#endif


	}
}
