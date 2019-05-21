using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GooglePlayGames;



public class MainMenu_UI : MonoBehaviour {

	public GameObject currScreen, mainMenuScreen, playScreen, statsScreen , googleConnectionIcon;
	Vector3 transformPosition;

	// audio
	public AudioClip audio_click;
	AudioSource audioSource;

	public Text txt_accuracy, txt_totalShots, txt_shotsOnTarget, txt_totalGamePlayed, 
		txt_timePlayed, txt_totalScore, txt_highScore, txt_gunSkinOwn;

	void Awake(){
		// Google play services
		#if UNITY_ANDROID
		PlayGamesPlatform.Activate();
		OnConnectionResponse (PlayGamesPlatform.Instance.localUser.authenticated);
		#endif
	}

	// Use this for initialization
	void Start () {
		#if UNITY_ANDROID
		ReportScore (PlayerPrefs.GetInt("HighScore"));
		#endif

		#if UNITY_IOS
		#endif

		audioSource = GetComponent<AudioSource>();

		SetStats ();

		//ach_4 ach_5
		if ((PlayerPrefs.GetInt ("TimePlayed") / 60 == 30)) {
			
		}else if ((PlayerPrefs.GetInt ("TimePlayed") / 60 == 300)) {

		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadShop(){
		SceneManager.LoadScene("Shop", LoadSceneMode.Single);

		audioSource.PlayOneShot(audio_click, 0.7F);

	}

	public void LoadPlayArcade(){
		SceneManager.LoadScene("main", LoadSceneMode.Single);

		audioSource.PlayOneShot(audio_click, 0.7F);

		PlayerPrefs.SetInt("TotalGamePlayed", PlayerPrefs.GetInt("TotalGamePlayed") + 1);

	}


	public void ChangeScreenTo(string _ScreenState){


		switch (_ScreenState)
		{
		case "mainmenu":
			print ("main menu screen open");
			currScreen.SetActive (false); 
			currScreen = mainMenuScreen;
			mainMenuScreen.SetActive (true);

			//UnlockAchievemnt (VRTHGPS.achievement_ach2_reload);

			audioSource.PlayOneShot(audio_click, 0.7F);


			break;
		case "play":
			print ("play screen open");
			currScreen.SetActive (false); 
			currScreen = playScreen;
			playScreen.SetActive (true);


			//transformPosition = currScreen.transform.localPosition;
			/*if (pageTransition == "right")
			{
				currScreen.transform.localPosition = new Vector3(transformPosition.x + Screen.width, transformPosition.y, transformPosition.z);
			}
			else if (pageTransition == "left")
			{
				currScreen.transform.localPosition = new Vector3(transformPosition.x - Screen.width, transformPosition.y, transformPosition.z);
			}
*/


			//currScreen.transform.localPosition = new Vector3(transformPosition.x + Screen.width, transformPosition.y, transformPosition.z);

			//LeanTween.reset();
			//LeanTween.moveX(currScreen, 0, 0.5f).setEase(LeanTweenType.easeOutExpo);


			//ach_1
			//UnlockAchievemnt (VRTHGPS.achievement_ach3_shoot);

			audioSource.PlayOneShot(audio_click, 0.7F);

			break;
		case "stats":
			print ("stats screen open");
			currScreen.SetActive (false); 
			currScreen = statsScreen;
			statsScreen.SetActive (true);


			//UnlockAchievemnt (VRTHGPS.achievement_ach4_scope);

			audioSource.PlayOneShot(audio_click, 0.7F);

			break;
		}

	}

	// Google play services

	public void OnConnectClick(){
		#if UNITY_ANDROID
		Social.localUser.Authenticate ((bool success) => {
			OnConnectionResponse(success);
		});
		#endif
	}

	private void OnConnectionResponse(bool authenticated){
		#if UNITY_ANDROID

		if(authenticated){

			UnlockAchievemnt (VRTHGPS.achievement_recruit);

			googleConnectionIcon.SetActive (true);
		}else{
			googleConnectionIcon.SetActive (false);
		}

		#endif
	}


	//Achivement
	public void OnAchievementClick(){
		#if UNITY_ANDROID
		if(Social.localUser.authenticated){
			Social.ShowAchievementsUI ();
		}

		audioSource.PlayOneShot(audio_click, 0.7F);
		#endif
	}

	public void UnlockAchievemnt(string achivementID){
		#if UNITY_ANDROID
		Social.ReportProgress (achivementID, 100.0f, (bool success) => {
			Debug.Log ("achivement unlocked   ! ");			
		});
		#endif
	}

	//Leaderboard
	public void OnLeaderboardClick(){
		#if UNITY_ANDROID
		if(Social.localUser.authenticated){
			Social.ShowLeaderboardUI ();
		}
		audioSource.PlayOneShot(audio_click, 0.7F);
		#endif
	}


	public void ReportScore(int _highscore){
		#if UNITY_ANDROID
		Social.ReportScore (_highscore , VRTHGPS.leaderboard_highscore , (bool success) => {
			Debug.Log ("score submitted  ! ");			
		});
		#endif
	}


	public void SetStats(){
	
		txt_accuracy.text = "Accuracy : " + PlayerPrefs.GetFloat("Accuracy") + " %";

		txt_totalShots.text = "Total Shots : " + PlayerPrefs.GetInt("TotalShots");

		txt_shotsOnTarget.text = "Shots on Target : " + PlayerPrefs.GetInt("ShotsOnTarget");

		txt_totalGamePlayed.text = "Total games played : " + PlayerPrefs.GetInt("TotalGamePlayed");

		txt_timePlayed.text = "Time Played : " + (PlayerPrefs.GetInt("TimePlayed") / 60) + " min";

		txt_totalScore.text = "Total Score : " + PlayerPrefs.GetInt("TotalScore");

		txt_highScore.text = "Highscore : " + PlayerPrefs.GetInt("HighScore");

		txt_gunSkinOwn.text = "Gun Skins Owned : " + "03";

	}

}
