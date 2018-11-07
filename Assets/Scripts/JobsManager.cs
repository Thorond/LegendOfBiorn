using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobsManager : MonoBehaviour {

	private JobsBtn jobsBtnPressed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void selectedJob(JobsBtn jobSelected){
		jobsBtnPressed = jobSelected;
		// Debug.Log("Pressed :" + jobsBtnPressed.gameObject);
	}
}
