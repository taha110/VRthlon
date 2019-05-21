using UnityEngine;
using System.Collections;


/// <summary>
/// Leaderboard view.
/// Auther : Nikunj Rola
/// </summary>

public class LeaderboardView : MonoBehaviour {



	string leaderBoardID = "PROVIDE_YOUR_LEADERBOARD_ID_HERE";


	// Use this for initialization
	void Start () {
		
		#if UNITY_IOS
		long score_long = Convert.ToInt64(PlayerPrefs.GetInt("HighScore"));
		OnPostScore_IOS (score_long);
		#endif
	}



	public void OnLogin_IOS(string id){
		#if UNITY_IOS
		LeaderboardManager.AuthenticateToGameCenter();
		#endif
	}
		

	public void OnShowLeaderboard_IOS(){
		#if UNITY_IOS
		LeaderboardManager.ShowLeaderboard();
		#endif
	}


	public void OnPostScore_IOS(long highScore){		
		#if UNITY_IOS
		LeaderboardManager.ReportScore(highScore , leaderBoardID);
		#endif
	}


	public void DoAchievement_IOS(){
		#if UNITY_IOS
		LeaderboardManager.ReportAchievement(string achievementID);
		#endif
	}
}
