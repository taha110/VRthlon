using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SplashScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SceneManager.LoadScene("MainMenu_UI", LoadSceneMode.Single);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
