﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class JobsManager : Singleton<JobsManager> {
	[SerializeField] private GameObject upBtn;

	private JobsBtn jobsBtnPressed;
	private Hunting myHuntingBuilding;
	private Fishing myFishingBuilding;
	private ShipBuilder myShipBuilderBuilding;

	
	[SerializeField] private Text displayOfNbrOfHunter;
	[SerializeField] private Text displayOfNbrOfFisherMen;
	[SerializeField] private Text displayOfNbrOfShipBuilder;

	private enum tabBtnJob{
		huntingBtn,
		fishingBtn,
		shipBuilderBtn
	}
	private enum tagBtn{
		huntingBtnUp,
		huntingBtnDown,
		fishingBtnUp,
		fishingBtnDown,
		shipBuilderBtnUp,
		shipBuilderBtnDown
	}

	// Use this for initialization
	void Start () {
		myHuntingBuilding = new Hunting();
		myFishingBuilding = new Fishing();
		myShipBuilderBuilding = new ShipBuilder();

		textDisplay();

		setAllUpAndDownBtnInactive();
	}
	
	// Update is called once per frame
	void Update () {
		textDisplay();
	}


	// Functions 
	public void selectedJob(JobsBtn jobSelected){
		jobsBtnPressed = jobSelected;
	}
	public void jobSettingCreation(GameManager gameManager){
		
		setAllUpAndDownBtnInactive();
		if ( jobsBtnPressed.tag == tabBtnJob.huntingBtn.ToString() ){
			GameObject btnToActivate = findGameObject(tagBtn.huntingBtnUp.ToString()); // Afficher le bouton pour augmenter le nomrbe de chasseurs
			if (btnToActivate) btnToActivate.SetActive(true);
			btnToActivate = findGameObject(tagBtn.huntingBtnDown.ToString()); // Afficher le bouton pour diminuer le nomrbe de chasseurs
			if (btnToActivate) btnToActivate.SetActive(true);
		}
		else if ( jobsBtnPressed.tag == tabBtnJob.fishingBtn.ToString() ){
			GameObject btnToActivate = findGameObject(tagBtn.fishingBtnUp.ToString()); // Afficher le bouton pour augmenter le nomrbe de pecheurs
			if (btnToActivate) btnToActivate.SetActive(true);
			btnToActivate = findGameObject(tagBtn.fishingBtnDown.ToString()); // Afficher le bouton pour diminuer le nomrbe de pecheurs
			if (btnToActivate) btnToActivate.SetActive(true);
		}
		else if ( jobsBtnPressed.tag == tabBtnJob.shipBuilderBtn.ToString() ){
			GameObject btnToActivate = findGameObject(tagBtn.shipBuilderBtnUp.ToString()); // Afficher le bouton pour augmenter le nomrbe de shipbuilder
			if (btnToActivate) btnToActivate.SetActive(true);
			btnToActivate = findGameObject(tagBtn.shipBuilderBtnDown.ToString()); // Afficher le bouton pour diminuer le nomrbe de shipbuilder
			if (btnToActivate) btnToActivate.SetActive(true);
		}

	}

	public void peopleAssignement( GameManager gameManager){
		if ( gameManager.People.NbrOfSlave > 0 ) {
			if (  jobsBtnPressed.tag.Equals(tagBtn.huntingBtnUp.ToString())){
				myHuntingBuilding.assignAnotherPerson();
				gameManager.People.NbrOfSlave -= 1;
			} else if ( jobsBtnPressed.tag.Equals(tagBtn.fishingBtnUp.ToString())){
				myFishingBuilding.assignAnotherPerson();
				gameManager.People.NbrOfSlave -= 1;
			} else if ( jobsBtnPressed.tag.Equals(tagBtn.shipBuilderBtnUp.ToString())){
				myShipBuilderBuilding.assignAnotherPerson();
				gameManager.People.NbrOfSlave -= 1;
			}
		}
		if (jobsBtnPressed.tag.Equals(tagBtn.huntingBtnDown.ToString()) && myHuntingBuilding.NbrOfPeopleAssigned > 0 ){
			myHuntingBuilding.removeAPerson();
			gameManager.People.NbrOfSlave += 1;
		} else if (jobsBtnPressed.tag.Equals(tagBtn.fishingBtnDown.ToString()) && myFishingBuilding.NbrOfPeopleAssigned > 0  ){
			myFishingBuilding.removeAPerson();
			gameManager.People.NbrOfSlave += 1;
		} else if (jobsBtnPressed.tag.Equals(tagBtn.shipBuilderBtnDown.ToString()) && myShipBuilderBuilding.NbrOfPeopleAssigned > 0 ){
			myShipBuilderBuilding.removeAPerson();
			gameManager.People.NbrOfSlave += 1;
		}
	}


	public void textDisplay(){
		displayOfNbrOfHunter.text = "Hunters : " + myHuntingBuilding.NbrOfPeopleAssigned.ToString();
		displayOfNbrOfFisherMen.text = "Fisher men : " + myFishingBuilding.NbrOfPeopleAssigned.ToString();
		displayOfNbrOfShipBuilder.text = "Ship builder : " + myShipBuilderBuilding.NbrOfPeopleAssigned.ToString();
	}

	public void setAllUpAndDownBtnInactive(){
		foreach ( GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject))){
			foreach( tagBtn tagou in Enum.GetValues(typeof(tagBtn)))
				if ( go.tag.Equals(tagou.ToString())) go.SetActive(false);
		} ;
	}
	public GameObject findGameObject(string tagou){
		foreach ( GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject))){
			if ( go.tag.Equals(tagou)) return go;
		} ;
		return null;
	}
	
}
