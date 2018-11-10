using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeManager : Singleton<TimeManager> {
	
	// Variables
	private DateTime inGameDate;
	private int timeInYear;
	private int timeInDay;
	[SerializeField] private Text timeElapsedText;

	// Use this for initialization
	void Start () {
		inGameDate = DateTime.Now;
		timeInYear = 803;
		timeInDay = 0;
		updateTimeElapsed();
		textDisplay();
	}
	
	// Update is called once per frame
	void Update () {
		updateTimeElapsed();
		textDisplay();
	}

	// Functions 
	
	void updateTimeElapsed(){
		if ( DateTime.Now.Subtract(inGameDate).Seconds > 60 ){
			timeInDay +=1;
			if (timeInDay == 365 ) {
				timeInDay = 0;
				timeInYear += 1;
			}
			inGameDate = DateTime.Now;
		}
	}

	void textDisplay(){
		timeElapsedText.text = "Year " + timeInYear.ToString() + " - Day " + timeInDay.ToString();
	}
}
