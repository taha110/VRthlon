using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour {



	// Use this for initialization
	void Start () {
		ParticleSystem exp = GetComponent<ParticleSystem>();
        exp.Play();
        Destroy(gameObject, exp.duration);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
