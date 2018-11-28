﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class JobsManager : Singleton<JobsManager> {

	// Variables
	private Btn jobsBtnPressed;
	private Btn upOrDownBtnPressed;
	private Btn woodOrIronBtnPressed;

	private Hunting myHuntingBuilding;
	private Fishing myFishingBuilding;
	private ShipBuilder myShipBuilderBuilding;

	
	[SerializeField] private GameManager gameManager;
	[SerializeField] private Text displayOfNbrOfHunter;
	[SerializeField] private Text displayOfNbrOfFisherMen;
	[SerializeField] private Text displayOfNbrOfShipBuilder;
	[SerializeField] private Text displayOfNbrOfShip;
	[SerializeField] private Text displayOfEfficiencyOfAViking;
	[SerializeField] private Text displayOfEfficiencyOfAShieldMaiden;
	[SerializeField] private Text displayOfEfficiencyOfASlave;

	private enum tagBtnJob{
		huntingBtn,
		fishingBtn,
		shipBuilderBtn,
		rawMaterialBtn
	}
	private enum tagBtn{
		shipBuilderBtnUp,
		applyShipBuilder,
		shipBuilderBtnDown
	}
	private enum tagPanel{
		jobPanel,
		woodBtn,
		ironBtn
	}

	private enum tagUpOrDown{
		upViking,
		downViking,
		upShieldMaiden,
		downShieldMaiden,
		upSlave,
		downSlave
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

		setAllJobPanelInactive();
	}
	
	// Update is called once per frame
	void Update () {
		textDisplay();

	}


	// Functions 
	public void selectedJob(Btn jobSelected){
		jobsBtnPressed = jobSelected;
	}
	public void selectedUpOrDown(Btn btnSelected){
		upOrDownBtnPressed = btnSelected;
	}
	public void selectedWoodOrIron(Btn btnSelected){
		woodOrIronBtnPressed = btnSelected;
	}

	public void jobSettingCreation(){
		
		setAllJobPanelInactive();
		myShipBuilderBuilding.closeAssignment();
		if ( jobsBtnPressed.tag == tagBtnJob.huntingBtn.ToString() || jobsBtnPressed.tag == tagBtnJob.rawMaterialBtn.ToString()){
			GameObject btnToActivate = findGameObject(tagPanel.jobPanel.ToString()); // Afficher le panel de la chasse
			if (btnToActivate) btnToActivate.SetActive(true);
			if (jobsBtnPressed.tag == tagBtnJob.rawMaterialBtn.ToString()){
				btnToActivate = findGameObject(tagPanel.woodBtn.ToString()); // Afficher le panel de la chasse
				if (btnToActivate) btnToActivate.SetActive(true);
				btnToActivate = findGameObject(tagPanel.ironBtn.ToString()); // Afficher le panel de la chasse
				if (btnToActivate) btnToActivate.SetActive(true);
			}
		}
		// else if ( jobsBtnPressed.tag == tagBtnJob.fishingBtn.ToString() ){
		// 	GameObject btnToActivate = findGameObject(tagBtn.fishingBtnUp.ToString()); // Afficher le bouton pour augmenter le nomrbe de pecheurs
		// 	if (btnToActivate) btnToActivate.SetActive(true);
		// 	btnToActivate = findGameObject(tagBtn.fishingBtnDown.ToString()); // Afficher le bouton pour diminuer le nomrbe de pecheurs
		// 	if (btnToActivate) btnToActivate.SetActive(true);
		// }
		// else if ( jobsBtnPressed.tag == tagBtnJob.shipBuilderBtn.ToString() ){
		// 	GameObject btnToActivate = findGameObject(tagBtn.shipBuilderBtnUp.ToString()); // Afficher le bouton pour augmenter le nomrbe de shipbuilder
		// 	if (btnToActivate) btnToActivate.SetActive(true);
		// 	btnToActivate = findGameObject(tagBtn.shipBuilderBtnDown.ToString()); // Afficher le bouton pour diminuer le nomrbe de shipbuilder
		// 	if (btnToActivate) btnToActivate.SetActive(true);
		// 	btnToActivate = findGameObject(tagBtn.applyShipBuilder.ToString()); // Afficher le btn pour appliquer le changement
		// 	if (btnToActivate) btnToActivate.SetActive(true);
		// }
		// else if (jobsBtnPressed.tag == tagBtnJob.rawMaterialBtn.ToString() ){
		// 	GameObject btnToActivate = findGameObject(tagPanel.RawMaterialPanel.ToString()); // Afficher le panel de la maison des matériaux
		// 	if (btnToActivate) btnToActivate.SetActive(true);
		// }

	}

	public void peopleAssignement( ){
		if ( jobsBtnPressed.tag == tagBtnJob.huntingBtn.ToString() ){
			if ( upOrDownBtnPressed.tag == tagUpOrDown.upSlave.ToString() && gameManager.Resources.People.NbrOfSlave > 0 ){
				myHuntingBuilding.assignAnotherSlave();
				gameManager.Resources.People.NbrOfSlave -= 1;
			}
			else if ( upOrDownBtnPressed.tag == tagUpOrDown.downSlave.ToString() && myHuntingBuilding.NbrOfSlaveAssigned > 0 ){
				myHuntingBuilding.removeASlave();
				gameManager.Resources.People.NbrOfSlave += 1;
			} else if ( upOrDownBtnPressed.tag == tagUpOrDown.upViking.ToString() && gameManager.Resources.People.NbrOfVikings > 0 ){
				myHuntingBuilding.assignAnotherViking();
				gameManager.Resources.People.NbrOfVikings -= 1;
			}
			else if ( upOrDownBtnPressed.tag == tagUpOrDown.downViking.ToString() && myHuntingBuilding.NbrOfVikingAssigned > 0 ){
				myHuntingBuilding.removeAViking();
				gameManager.Resources.People.NbrOfVikings += 1;
			} else if ( upOrDownBtnPressed.tag == tagUpOrDown.upShieldMaiden.ToString() && gameManager.Resources.People.NbrOfShieldMaidens > 0 ){
				myHuntingBuilding.assignAnotherShieldMaiden();
				gameManager.Resources.People.NbrOfShieldMaidens -= 1;
			}
			else if ( upOrDownBtnPressed.tag == tagUpOrDown.downShieldMaiden.ToString() && myHuntingBuilding.NbrOfShieldMaidenAssigned > 0 ){
				myHuntingBuilding.removeAShieldMaiden();
				gameManager.Resources.People.NbrOfShieldMaidens += 1;
			}
		} 
		if ( gameManager.Resources.People.NbrOfSlave > 0 ) {
			// if ( jobsBtnPressed.tag.Equals(tagBtn.fishingBtnUp.ToString())){
			// 	myFishingBuilding.assignAnotherPerson();
			// 	gameManager.Resources.People.NbrOfSlave -= 1;
			// } 
			// if (gameManager.Resources.People.NbrOfSlave > myShipBuilderBuilding.NbrOfAssignedPeopleChosen ){
			// 	if ( jobsBtnPressed.tag.Equals(tagBtn.shipBuilderBtnUp.ToString()) && !myShipBuilderBuilding.WorkInProgress ){
			// 		myShipBuilderBuilding.NbrOfAssignedPeopleChosen += 1;
			// 	}
			// }
		}
		// if (jobsBtnPressed.tag.Equals(tagBtn.fishingBtnDown.ToString()) && myFishingBuilding.NbrOfPeopleAssigned > 0  ){
		// 	myFishingBuilding.removeAPerson();
		// 	gameManager.Resources.People.NbrOfSlave += 1;
		// } else if (jobsBtnPressed.tag.Equals(tagBtn.shipBuilderBtnDown.ToString()) && !myShipBuilderBuilding.WorkInProgress){
		// 	if ( myShipBuilderBuilding.NbrOfAssignedPeopleChosen > 0) myShipBuilderBuilding.NbrOfAssignedPeopleChosen -= 1;
		// }
		// if ( jobsBtnPressed.tag.Equals(tagBtn.applyShipBuilder.ToString()) && !myShipBuilderBuilding.WorkInProgress ){
		// 	myShipBuilderBuilding.assignWork(gameManager.Resources.People);
		// }
	}


	public void textDisplay(){
		displayOfNbrOfHunter.text = "Hunting : \n Vikings : " + myHuntingBuilding.NbrOfVikingAssigned.ToString()
				+ "\n ShieldMaidens : "  + myHuntingBuilding.NbrOfShieldMaidenAssigned.ToString()
				+ "\n Slaves : "  + myHuntingBuilding.NbrOfSlaveAssigned.ToString();
		displayOfNbrOfFisherMen.text = "Fishing : \n Vikings :" + myFishingBuilding.NbrOfVikingAssigned.ToString()
				+ "\n ShieldMaidens : "  + myFishingBuilding.NbrOfShieldMaidenAssigned.ToString()
				+ "\n Slaves : "  + myFishingBuilding.NbrOfSlaveAssigned.ToString();
		displayOfNbrOfShipBuilder.text = "Ship building : \n Vikings : " + myShipBuilderBuilding.NbrOfVikingAssigned.ToString()
				+ "\n ShieldMaidens : "  + myShipBuilderBuilding.NbrOfShieldMaidenAssigned.ToString()
				+ "\n Slaves : "  + myShipBuilderBuilding.NbrOfSlaveAssigned.ToString();
		displayOfNbrOfShip.text = "Ships  \n Type 1 : " + gameManager.Resources.Ships.NbrOfShipType1.ToString();

		if (jobsBtnPressed){
			if ( jobsBtnPressed.tag == tagBtnJob.huntingBtn.ToString()  ){
				displayOfEfficiencyOfAViking.text = gameManager.Resources.People.Vikings.FoodGatheringEfficiency.ToString();
				displayOfEfficiencyOfAShieldMaiden.text = gameManager.Resources.People.ShieldMaidens.FoodGatheringEfficiency.ToString();
				displayOfEfficiencyOfASlave.text = gameManager.Resources.People.Slaves.FoodGatheringEfficiency.ToString();
			}

			else if ( jobsBtnPressed.tag == tagBtnJob.rawMaterialBtn.ToString()  ){
				if (woodOrIronBtnPressed){
					if (woodOrIronBtnPressed.tag == tagPanel.ironBtn.ToString()){
						displayOfEfficiencyOfAViking.text = gameManager.Resources.People.Vikings.IronGatheringEfficiency.ToString();
						displayOfEfficiencyOfAShieldMaiden.text = gameManager.Resources.People.ShieldMaidens.IronGatheringEfficiency.ToString();
						displayOfEfficiencyOfASlave.text = gameManager.Resources.People.Slaves.IronGatheringEfficiency.ToString();
					}
					else {
						displayOfEfficiencyOfAViking.text = gameManager.Resources.People.Vikings.WoodGatheringEfficiency.ToString();
						displayOfEfficiencyOfAShieldMaiden.text = gameManager.Resources.People.ShieldMaidens.WoodGatheringEfficiency.ToString();
						displayOfEfficiencyOfASlave.text = gameManager.Resources.People.Slaves.WoodGatheringEfficiency.ToString();
					}
				}
				else {
					displayOfEfficiencyOfAViking.text = gameManager.Resources.People.Vikings.WoodGatheringEfficiency.ToString();
					displayOfEfficiencyOfAShieldMaiden.text = gameManager.Resources.People.ShieldMaidens.WoodGatheringEfficiency.ToString();
					displayOfEfficiencyOfASlave.text = gameManager.Resources.People.Slaves.WoodGatheringEfficiency.ToString();
				}
			}
			
		}
	}

	public void setAllJobPanelInactive(){
		foreach ( GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject))){
			foreach( tagPanel tagou in Enum.GetValues(typeof(tagPanel)))
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
