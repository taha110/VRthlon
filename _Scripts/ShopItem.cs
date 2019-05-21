using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ShopItem : MonoBehaviour {

	public Material gunMat1;
	public Material gunMat2;
	public Material gunMat3;
	public Material gunMat4;
	public Material gunMat5;

	public GameObject GunObj;

	// Use this for initialization
	void Start () {
		switch (PlayerPrefs.GetInt("GunMat"))
		{
		case 5:
			GunObj.GetComponent<MeshRenderer>().material = gunMat5;
			break;
		case 4:
			GunObj.GetComponent<MeshRenderer>().material = gunMat4;
			break;
		case 3:
			GunObj.GetComponent<MeshRenderer>().material = gunMat3;
			break;
		case 2:
			GunObj.GetComponent<MeshRenderer>().material = gunMat2;
			break;
		case 1:
			GunObj.GetComponent<MeshRenderer>().material = gunMat1;
			break;
		default:
			GunObj.GetComponent<MeshRenderer>().material = gunMat1;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetGunTex1(){
		GunObj.GetComponent<MeshRenderer>().material = gunMat1;
		PlayerPrefs.SetInt ("GunMat", 1);

	}
	public void SetGunTex2(){
		GunObj.GetComponent<MeshRenderer>().material = gunMat2;
		PlayerPrefs.SetInt ("GunMat", 2);

	}
	public void SetGunTex3(){
		GunObj.GetComponent<MeshRenderer>().material = gunMat3;
		PlayerPrefs.SetInt ("GunMat", 3);

	}
	public void SetGunTex4(){
		GunObj.GetComponent<MeshRenderer>().material = gunMat4;
		PlayerPrefs.SetInt ("GunMat", 4);

	}
	public void SetGunTex5(){
		GunObj.GetComponent<MeshRenderer>().material = gunMat5;
		PlayerPrefs.SetInt ("GunMat", 5);

	}
	public void BackButton(){
		SceneManager.LoadScene("MainMenu_UI", LoadSceneMode.Single);
	}
}


