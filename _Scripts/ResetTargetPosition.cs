using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTargetPosition : MonoBehaviour {

	public float X_min , X_max , Y_min , Y_max , Z_min , Z_max , _X , _Y , _Z; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ResetPosition(){
		_X = Random.Range(X_min, X_max);
		_Y = Random.Range(Y_min, Y_max);
		_Z = Random.Range(Z_min, Z_max);


		this.transform.position = new Vector3(_X , _Y , _Z);
	}

}
