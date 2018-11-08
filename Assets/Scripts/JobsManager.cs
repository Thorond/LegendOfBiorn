using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobsManager : Singleton<JobsManager> {

	private JobsBtn jobsBtnPressed;
	private Hunting myHuntingBuilding;
	private Fishing myFishingBuilding;
	private ShipBuilder myShipBuilderBuilding;

	
	[SerializeField] private Text displayOfNbrOfHunter;
	[SerializeField] private Text displayOfNbrOfFisherMen;
	[SerializeField] private Text displayOfNbrOfShipBuilder;

	// Use this for initialization
	void Start () {
		myHuntingBuilding = new Hunting();
		myFishingBuilding = new Fishing();
		myShipBuilderBuilding = new ShipBuilder();

		textDisplay();
	}
	
	// Update is called once per frame
	void Update () {
		textDisplay();
	}


	// Functions 
	public void selectedJob(JobsBtn jobSelected){
		jobsBtnPressed = jobSelected;
	}

	public void peopleAssignement(GameManager gameManager){
		if ( gameManager.People.NbrOfSlave > 0 ) {
			if ( jobsBtnPressed.tag == "huntingBtn"){
				myHuntingBuilding.assignAnotherPerson();
				gameManager.People.NbrOfSlave -= 1;
			}
			if ( jobsBtnPressed.tag == "fishingBtn"){
				myFishingBuilding.assignAnotherPerson();
				gameManager.People.NbrOfSlave -= 1;
			}
			if ( jobsBtnPressed.tag == "shipBuilderBtn"){
				myShipBuilderBuilding.assignAnotherPerson();
				gameManager.People.NbrOfSlave -= 1;
			}
		}
	}

	public void textDisplay(){
		displayOfNbrOfHunter.text = "Hunters : " + myHuntingBuilding.NbrOfPeopleAssigned.ToString();
		displayOfNbrOfFisherMen.text = "Fisher men : " + myFishingBuilding.NbrOfPeopleAssigned.ToString();
		displayOfNbrOfShipBuilder.text = "Ship builder : " + myShipBuilderBuilding.NbrOfPeopleAssigned.ToString();
	}
}
