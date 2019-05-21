using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Gun : MonoBehaviour {

	// static bool
	public static bool _GameOver;
	public GameObject gameOverScreen;

	bool canTakeShot;
	bool bulletsEnd;
	bool isReloading;
	public float shotWaitTime;
	public float reloadWaitTime;
	public int magazineBulletCount;
	public int firedBulletCount;
	public int totalBulletCount;
	public Text txt_bulletcount;
	public Text txt_totalBullets;
	public Text txt_score;
	public Text txt_highScore;

	int totalfiredBulletCount;
	public float _accuracy;
	public float _shotsOnTarget;
	float _totalScore;

	float timeLeftMultiplierOffset;

	public Text txt_accuracy;
	public Text txt__shotsOnTarget;
	public Text txt_totalScore;


	// audio
	public AudioClip audio_shotFire;
	public AudioClip audio_shotEnpty;
	public AudioClip audio_reload;
	public AudioClip audio_click;

	GameObject hitObject;
	public GameObject animatorObject;

	AudioSource audioSource;

	public int currentScore;

	public GameObject bulletPointerPrefab , gunShotParticle , gunBarrelPoint;

	Vector3 hitSpawnPoint;

	Animator _animator;

	bool doOnce;

	void Awake (){

        if(!PlayerPrefs.HasKey("HighScore")){
            PlayerPrefs.SetInt("HighScore", 0);
        }		

		if(!PlayerPrefs.HasKey("Score")){
            PlayerPrefs.SetInt("Score", 0);
        }
    }

	// Use this for initialization
	void Start () {
		canTakeShot=true;
		bulletsEnd = false;
		isReloading = false;
		shotWaitTime=0.5f;
		magazineBulletCount = 5;
		firedBulletCount=0;
		reloadWaitTime=4f;

		audioSource = GetComponent<AudioSource>();


		txt_totalBullets.text = totalBulletCount.ToString();
		txt_bulletcount.text = magazineBulletCount.ToString();

		PlayerPrefs.SetInt("Score", 0);

		txt_score.text = currentScore.ToString();
		txt_highScore.text = PlayerPrefs.GetInt("HighScore").ToString();

		_animator = animatorObject.GetComponent<Animator> ();

		_GameOver = false;
		timeLeftMultiplierOffset = 0;

		doOnce = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space") ){
			if(canTakeShot && !bulletsEnd && !isReloading){
				StartCoroutine (Shot ());
				audioSource.PlayOneShot(audio_shotFire, 0.7F);
			}else{
				audioSource.PlayOneShot(audio_shotEnpty, 0.7F);
			}				
		}

		if (_GameOver && doOnce) {
			doOnce = false;
			GameOver ();

		}

		
	}

	public void GameOver(){
		if(_shotsOnTarget < 5){
			timeLeftMultiplierOffset = 0;
		}else if(_shotsOnTarget >= 5 && _shotsOnTarget < 10){
			timeLeftMultiplierOffset = 0.5f;
		}else if(_shotsOnTarget >= 10 && _shotsOnTarget < 15){
			timeLeftMultiplierOffset = 1;
		}else if(_shotsOnTarget >= 15 && _shotsOnTarget < 20){
			timeLeftMultiplierOffset = 1.5f;
		}else if(_shotsOnTarget >= 20 && _shotsOnTarget < 25){
			timeLeftMultiplierOffset = 2;
		}else if(_shotsOnTarget >= 25 && _shotsOnTarget < 30){
			timeLeftMultiplierOffset = 3;
		}else if(_shotsOnTarget >= 30){
			timeLeftMultiplierOffset = 5;
		}

		float temp_timeLeft;
		temp_timeLeft = this.GetComponent<LimitedTimeMode> ()._timeLeft * timeLeftMultiplierOffset;

		txt_accuracy.text = "Accuracy : " +(_accuracy*100).ToString ("F1") + " %";
		txt__shotsOnTarget.text = "Shots on Target : " + _shotsOnTarget.ToString();
		txt_totalScore.text = "Total Score : " + ((_shotsOnTarget*5) * (_accuracy+1) + temp_timeLeft).ToString();

		print (  "acc : " + _accuracy + "  SOT"+ _shotsOnTarget + "  tS" + ((_shotsOnTarget*5) * (_accuracy+1) + temp_timeLeft)  + " TFBC "+ totalfiredBulletCount);
	
		PlayerPrefs.SetInt("TotalScore", PlayerPrefs.GetInt("TotalScore") + (int)(((_shotsOnTarget*5) * (_accuracy+1) + temp_timeLeft)));


		PlayerPrefs.SetFloat ("Accuracy", ((((PlayerPrefs.GetFloat("Accuracy") /100 )* (PlayerPrefs.GetInt("TotalGamePlayed")-1)) + _accuracy ) / PlayerPrefs.GetInt("TotalGamePlayed"))*100);

	}

	public void Shoot_UI(){
		if(!_GameOver){
		if(canTakeShot && !bulletsEnd && !isReloading){
				StartCoroutine (Shot ());
				audioSource.PlayOneShot(audio_shotFire, 0.7F);
				totalfiredBulletCount++;

				PlayerPrefs.SetInt("TotalShots", PlayerPrefs.GetInt("TotalShots") + 1);

				if(totalfiredBulletCount == 5){
					_GameOver = true;
					gameOverScreen.SetActive (true);
				}

				_accuracy =   (_shotsOnTarget / totalfiredBulletCount) ;
				print ("acccccuracy   :  " + _accuracy);

			
			}else{
				audioSource.PlayOneShot(audio_shotEnpty, 0.7F);
			}
	}
	}

	public void Reload_UI(){
		if(firedBulletCount != 0 && !_GameOver){
				StartCoroutine(Reload());
		}
	}

	IEnumerator Shot ()
	{
		canTakeShot=false;
		print("Fireeeeeeeee !!!!!!!!");
		firedBulletCount++;
		txt_bulletcount.text = (magazineBulletCount - firedBulletCount).ToString();
		if(firedBulletCount==magazineBulletCount){
			bulletsEnd = true;
		}

		_animator.SetTrigger ("Shot");

		Instantiate (gunShotParticle, gunBarrelPoint.transform.position , Quaternion.Euler(gunShotParticle.transform.eulerAngles.x , gunShotParticle.transform.eulerAngles.y , gunShotParticle.transform.eulerAngles.z));


		yield return new WaitForSeconds (shotWaitTime);
		canTakeShot = true;

		hitObject = gameObject.GetComponent<RaycastScript>().rayHitObject;


		if(hitObject != null){
			print (" hit target " + hitObject.name);
			
			
			hitSpawnPoint = this.GetComponent<RaycastScript>().hitPos;


			Instantiate (bulletPointerPrefab, hitSpawnPoint, Quaternion.identity);

			hitObject.GetComponent<ResetTargetPosition>().ResetPosition();			
			Scoring();

			_shotsOnTarget++;
			_accuracy =   (_shotsOnTarget / totalfiredBulletCount) ;

			// if limited time mode
			this.GetComponent<LimitedTimeMode> ().HitBonus ();

			PlayerPrefs.SetInt("ShotsOnTarget", PlayerPrefs.GetInt("ShotsOnTarget") + 1);

			//ach_2   ach_3
			if(PlayerPrefs.GetInt("ShotsOnTarget") == 15){
				
			}else if(PlayerPrefs.GetInt("ShotsOnTarget") == 50){
				
			}
		}
	}


		IEnumerator Reload ()
	{		
		audioSource.PlayOneShot(audio_reload, 0.7F);
		isReloading=true;
		print("Reloaddd !!!!!!!!");	
		yield return new WaitForSeconds (reloadWaitTime);
		isReloading = false;
		totalBulletCount -=firedBulletCount;
		firedBulletCount = 0; 
		bulletsEnd = false;
		txt_totalBullets.text = totalBulletCount.ToString();
		txt_bulletcount.text = magazineBulletCount.ToString();
	}

	public void Scoring(){
		currentScore ++;
		PlayerPrefs.SetInt("Score", currentScore);
		txt_score.text = currentScore.ToString();



		if(PlayerPrefs.GetInt("HighScore") < currentScore){
			PlayerPrefs.SetInt("HighScore", currentScore);
			txt_highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
		}
	}


	// GAME OVER UI
	public void GotoMainMenu(){
		
		audioSource.PlayOneShot(audio_click, 0.7F);
		SceneManager.LoadScene("MainMenu_UI", LoadSceneMode.Single);

	}


}
