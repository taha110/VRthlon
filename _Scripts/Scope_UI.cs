using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope_UI : MonoBehaviour {


	public GameObject ScopeObj;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClickScope(){
		if(!Gun._GameOver){
			ScopeObj.SetActive(true);

		}
	}

	public void OnReleaseScope(){
		ScopeObj.SetActive(false);

	}
}
