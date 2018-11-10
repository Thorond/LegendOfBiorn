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
	private int timeChoice;
	[SerializeField] private Text timeElapsedText;

	private enum tagTime{ addTime, removeTime, applyTime }

	// Use this for initialization
	void Start () {
		inGameDate = DateTime.Now;
		timeInYear = 803;
		timeInDay = 0;
		timeChoice = 0;
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

	public void timeManagement(Btn btnSelected){
		if ( btnSelected ){
			if ( btnSelected.tag.Equals(tagTime.removeTime.ToString()) ){
				if (timeChoice > 0) timeChoice -= 1;
			} else if ( btnSelected.tag.Equals(tagTime.addTime.ToString())){
				timeChoice += 1;
			} else if ( btnSelected.tag.Equals(tagTime.applyTime.ToString())){
				timeChoice = 0;
				// TODO fonction de gestion du temps
			}
		}
	}

	void textDisplay(){
		timeElapsedText.text = "Year " + timeInYear.ToString() + " - Day " + timeInDay.ToString()
			+ "\n How many days do you want to skip : " + timeChoice.ToString();
	}
}
