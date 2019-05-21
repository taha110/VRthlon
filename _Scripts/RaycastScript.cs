using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastScript : MonoBehaviour {

	public float rayLength;
	RaycastHit hit;

	public Text _txtResult;

	public float upperLimit , lowerLimit , value_X , value_Y , windRangeMin , windRangeMax , temp_highValue;

	public GameObject w_direction_img , rayHitObject;
	float windDirectionAngle , windSpeed;

	public Text windText;

	public Vector3 hitPos;
	


	// Use this for initialization
	void Start () {
		rayLength = 100f;

		value_X =  Random.Range(lowerLimit, upperLimit);
		value_Y =  Random.Range(lowerLimit, upperLimit);

		if(value_X == 0){
			value_X = 0.1f;
		} else if(value_Y == 0){
			value_Y = 0.1f;
		}

		if(Mathf.Abs(value_X) >= Mathf.Abs(value_Y)){
			temp_highValue = Mathf.Abs(value_X);
		}else{
			temp_highValue = Mathf.Abs(value_Y);
		}
		
		// First Quater !!!!!!!!!!!!  0 - 90

		if(value_X > 0 && value_Y > 0){
			if(value_X< value_Y){
				windDirectionAngle = (value_X/value_Y) * 45;
			}else if(value_X > value_Y){
				windDirectionAngle = ((1-(value_Y/value_X)) * 45) + 45 ;
			}else{
				windDirectionAngle = 45;
			}
			print ("X = " + value_X + "    Y = " + value_Y  +  "      ANGLEEEEEEE : " + windDirectionAngle  + "    First Quater ");
			w_direction_img.transform.rotation = Quaternion.Euler(0,0,360-windDirectionAngle);

			}


		// Second Quater !!!!!!!!!!!!   90 - 180

		if(value_X > 0 && value_Y < 0){
			if(value_X > Mathf.Abs(value_Y)){
				windDirectionAngle = ((Mathf.Abs(value_Y)/value_X) * 45) + 90;
			}else if(value_X < Mathf.Abs(value_Y)){
				windDirectionAngle = ((1-(value_X/Mathf.Abs(value_Y))) * 45) + 135 ;
			}else{
				windDirectionAngle = 135;
			}
			print ("X = " + value_X + "    Y = " + value_Y  +  "      ANGLEEEEEEE : " + windDirectionAngle  + "    Second Quater ");
			w_direction_img.transform.rotation = Quaternion.Euler(0,0,360-windDirectionAngle);
			}		


		// Third Quater !!!!!!!!!!!!   180 - 270

		if(value_X < 0 && value_Y < 0){
			if(Mathf.Abs(value_Y) > Mathf.Abs(value_X)){
				windDirectionAngle = ((Mathf.Abs(value_X)/Mathf.Abs(value_Y)) * 45) + 180;
			}else if(Mathf.Abs(value_X) > Mathf.Abs(value_Y)){
				windDirectionAngle = ((1-(Mathf.Abs(value_Y)/Mathf.Abs(value_X))) * 45) + 225 ;
			}else{
				windDirectionAngle = 225;
			}
			print ("X = " + value_X + "    Y = " + value_Y  +  "      ANGLEEEEEEE : " + windDirectionAngle  + "    Third Quater ");
			w_direction_img.transform.rotation = Quaternion.Euler(0,0,360-windDirectionAngle);
			}	


		// Fourth Quater !!!!!!!!!!!!   270 - 360

		if(value_X < 0 && value_Y > 0){
			if(Mathf.Abs(value_Y) < Mathf.Abs(value_X)){
				windDirectionAngle = ((Mathf.Abs(value_Y)/Mathf.Abs(value_X)) * 45) + 270;
			}else if(Mathf.Abs(value_X) < Mathf.Abs(value_Y)){
				windDirectionAngle = ((1-(Mathf.Abs(value_X)/Mathf.Abs(value_Y))) * 45) + 315 ;
			}else{
				windDirectionAngle = 315;
			}
			print ("X = " + value_X + "    Y = " + value_Y  +  "      ANGLEEEEEEE : " + windDirectionAngle  + "    Fourth Quater ");
			w_direction_img.transform.rotation = Quaternion.Euler(0,0,360-windDirectionAngle);
			}



		windSpeed = ((windRangeMax-windRangeMin)*(temp_highValue - 0));
		windSpeed = (windSpeed/(upperLimit - 0))  + windRangeMin;

		windText.text = (int)windSpeed + " mph";
	}
	
	// Update is called once per frame
	void Update () {
		Ray landingRay = new Ray(new Vector3(this.transform.position.x+(value_X) , this.transform.position.y+(value_Y) , this.transform.position.z)  , this.transform.forward);

		Debug.DrawRay(new Vector3(this.transform.position.x+(value_X) , this.transform.position.y+(value_Y) , this.transform.position.z) , this.transform.forward * 100 ,Color.green);

		Physics.Raycast(landingRay , out hit, rayLength);

		if(hit.collider != null){
			_txtResult.text = hit.collider.name;
			rayHitObject = hit.collider.gameObject;
			hitPos = hit.point;
			
			

		}else{
			_txtResult.text = "nothingggg";
			rayHitObject = null;
		}
		//_txtResult.text = this.transform.rotation.x+ " ";
	}
}
