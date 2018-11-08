using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobsManager : Singleton<JobsManager> {

	private JobsBtn jobsBtnPressed;
	private Hunting myHuntingBuilding;
	private Fishing myFishingBuilding;
	private ShipBuilder myShipBuilderBuilding;

	

	// Use this for initialization
	void Start () {
		myHuntingBuilding = new Hunting();
		myFishingBuilding = new Fishing();
		myShipBuilderBuilding = new ShipBuilder();
	}
	
	// Update is called once per frame
	void Update () {
	}

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
		Debug.Log("nbr of people assigned to hunting :" + myHuntingBuilding.NbrOfPeopleAssigned);
		Debug.Log("nbr of people assigned to fishing :" + myFishingBuilding.NbrOfPeopleAssigned);
		Debug.Log("nbr of people assigned to ship building :" + myShipBuilderBuilding.NbrOfPeopleAssigned);
		Debug.Log("nbr of slave available :" + gameManager.People.NbrOfSlave);
	}
}
