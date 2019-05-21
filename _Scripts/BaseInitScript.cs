using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInitScript : MonoBehaviour {

	void Awake (){
		

		if (!PlayerPrefs.HasKey ("Accuracy")) {
			PlayerPrefs.SetFloat ("Accuracy", 0.0f);
		}
		if (!PlayerPrefs.HasKey ("TotalShots")) {
			PlayerPrefs.SetInt ("TotalShots", 0);
		}
		if (!PlayerPrefs.HasKey ("ShotsOnTarget")) {
			PlayerPrefs.SetInt ("ShotsOnTarget", 0);
		}
		if (!PlayerPrefs.HasKey ("TotalGamePlayed")) {
			PlayerPrefs.SetInt ("TotalGamePlayed", 0);
		}
		if (!PlayerPrefs.HasKey ("TimePlayed")) {
			PlayerPrefs.SetInt ("TimePlayed", 0);
		}
		if (!PlayerPrefs.HasKey ("TotalScore")) {
			PlayerPrefs.SetInt ("TotalScore", 0);
		}
		if (!PlayerPrefs.HasKey ("HighScore")) {
			PlayerPrefs.SetInt ("HighScore", 0);
		}
		if (!PlayerPrefs.HasKey ("GunMat")) {
			PlayerPrefs.SetInt ("GunMat", 1);
		}
	}

	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteAll ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
