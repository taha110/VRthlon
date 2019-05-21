using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateGunMat : MonoBehaviour {
	
	public Material gunMat1;
	public Material gunMat2;
	public Material gunMat3;
	public Material gunMat4;
	public Material gunMat5;

	// Use this for initialization
	void Start () {


		switch (PlayerPrefs.GetInt("GunMat"))
		{
		case 5:
			this.gameObject.GetComponent<MeshRenderer>().material = gunMat5;
			break;
		case 4:
			this.gameObject.GetComponent<MeshRenderer>().material = gunMat4;
			break;
		case 3:
			this.gameObject.GetComponent<MeshRenderer>().material = gunMat3;
			break;
		case 2:
			this.gameObject.GetComponent<MeshRenderer>().material = gunMat2;
			break;
		case 1:
			this.gameObject.GetComponent<MeshRenderer>().material = gunMat1;
			break;
		default:
			this.gameObject.GetComponent<MeshRenderer>().material = gunMat1;
			break;
		}


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
