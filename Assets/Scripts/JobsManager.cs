using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class JobsManager : Singleton<JobsManager> {

	// Variables
	private Btn jobsBtnPressed;
	private Hunting myHuntingBuilding;
	private Fishing myFishingBuilding;
	private ShipBuilder myShipBuilderBuilding;

	
	[SerializeField] private GameManager gameManager;
	[SerializeField] private Text displayOfNbrOfHunter;
	[SerializeField] private Text displayOfNbrOfFisherMen;
	[SerializeField] private Text displayOfNbrOfShipBuilder;
	[SerializeField] private Text displayOfNbrOfShip;

	private enum tagBtnJob{
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
		applyShipBuilder,
		shipBuilderBtnDown
	}

	// Getters and Setters

	public Hunting MyHuntingBuilding { get{return myHuntingBuilding;}}
	public Fishing MyFishingBuilding { get{return myFishingBuilding;}}
	public ShipBuilder MyShipBuilderBuilding { get{return myShipBuilderBuilding;}}

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
	public void selectedJob(Btn jobSelected){
		jobsBtnPressed = jobSelected;
	}

	public void jobSettingCreation(){
		
		setAllUpAndDownBtnInactive();
		myShipBuilderBuilding.closeAssignment();
		if ( jobsBtnPressed.tag == tagBtnJob.huntingBtn.ToString() ){
			GameObject btnToActivate = findGameObject(tagBtn.huntingBtnUp.ToString()); // Afficher le bouton pour augmenter le nomrbe de chasseurs
			if (btnToActivate) btnToActivate.SetActive(true);
			btnToActivate = findGameObject(tagBtn.huntingBtnDown.ToString()); // Afficher le bouton pour diminuer le nomrbe de chasseurs
			if (btnToActivate) btnToActivate.SetActive(true);
		}
		else if ( jobsBtnPressed.tag == tagBtnJob.fishingBtn.ToString() ){
			GameObject btnToActivate = findGameObject(tagBtn.fishingBtnUp.ToString()); // Afficher le bouton pour augmenter le nomrbe de pecheurs
			if (btnToActivate) btnToActivate.SetActive(true);
			btnToActivate = findGameObject(tagBtn.fishingBtnDown.ToString()); // Afficher le bouton pour diminuer le nomrbe de pecheurs
			if (btnToActivate) btnToActivate.SetActive(true);
		}
		else if ( jobsBtnPressed.tag == tagBtnJob.shipBuilderBtn.ToString() ){
			GameObject btnToActivate = findGameObject(tagBtn.shipBuilderBtnUp.ToString()); // Afficher le bouton pour augmenter le nomrbe de shipbuilder
			if (btnToActivate) btnToActivate.SetActive(true);
			btnToActivate = findGameObject(tagBtn.shipBuilderBtnDown.ToString()); // Afficher le bouton pour diminuer le nomrbe de shipbuilder
			if (btnToActivate) btnToActivate.SetActive(true);
			btnToActivate = findGameObject(tagBtn.applyShipBuilder.ToString()); // Afficher le btn pour appliquer le changement
			if (btnToActivate) btnToActivate.SetActive(true);
		}

	}

	public void peopleAssignement( ){
		if ( gameManager.Resources.People.NbrOfSlave > 0 ) {
			if (  jobsBtnPressed.tag.Equals(tagBtn.huntingBtnUp.ToString())){
				myHuntingBuilding.assignAnotherPerson();
				gameManager.Resources.People.NbrOfSlave -= 1;
			} else if ( jobsBtnPressed.tag.Equals(tagBtn.fishingBtnUp.ToString())){
				myFishingBuilding.assignAnotherPerson();
				gameManager.Resources.People.NbrOfSlave -= 1;
			} 
			if (gameManager.Resources.People.NbrOfSlave > myShipBuilderBuilding.NbrOfAssignedPeopleChosen ){
				if ( jobsBtnPressed.tag.Equals(tagBtn.shipBuilderBtnUp.ToString()) && !myShipBuilderBuilding.WorkInProgress ){
					myShipBuilderBuilding.NbrOfAssignedPeopleChosen += 1;
				}
			}
		}
		if (jobsBtnPressed.tag.Equals(tagBtn.huntingBtnDown.ToString()) && myHuntingBuilding.NbrOfPeopleAssigned > 0 ){
			myHuntingBuilding.removeAPerson();
			gameManager.Resources.People.NbrOfSlave += 1;
		} else if (jobsBtnPressed.tag.Equals(tagBtn.fishingBtnDown.ToString()) && myFishingBuilding.NbrOfPeopleAssigned > 0  ){
			myFishingBuilding.removeAPerson();
			gameManager.Resources.People.NbrOfSlave += 1;
		} else if (jobsBtnPressed.tag.Equals(tagBtn.shipBuilderBtnDown.ToString()) && !myShipBuilderBuilding.WorkInProgress){
			if ( myShipBuilderBuilding.NbrOfAssignedPeopleChosen > 0) myShipBuilderBuilding.NbrOfAssignedPeopleChosen -= 1;
		}
		if ( jobsBtnPressed.tag.Equals(tagBtn.applyShipBuilder.ToString()) && !myShipBuilderBuilding.WorkInProgress ){
			myShipBuilderBuilding.assignWork(gameManager.Resources.People);
		}
	}


	public void textDisplay(){
		displayOfNbrOfHunter.text = "Hunters : " + myHuntingBuilding.NbrOfPeopleAssigned.ToString();
		displayOfNbrOfFisherMen.text = "Fisher men : " + myFishingBuilding.NbrOfPeopleAssigned.ToString();
		displayOfNbrOfShipBuilder.text = "Ship builder : " + myShipBuilderBuilding.NbrOfPeopleAssigned.ToString();
		displayOfNbrOfShip.text = "Ships  \n Type 1 : " + gameManager.Resources.Ships.NbrOfShipType1.ToString();
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
