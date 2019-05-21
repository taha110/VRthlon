using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;


public class GameManager : MonoBehaviour {


	private static GameManager instance;

	public static GameManager Instance{
		get{return instance; }
	}

	void Awake(){
		instance = this;
		DontDestroyOnLoad (this.gameObject);


	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GmaeManagerTest () {
		print ("testing gamemanager");
	}

	public void UnlockAchievemnt(string achivementID){
		
		#if UNITY_ANDROID
		Social.ReportProgress (achivementID, 100.0f, (bool success) => {
			Debug.Log ("achivement unlocked   ! ");			
		});
		#endif
	}
}
