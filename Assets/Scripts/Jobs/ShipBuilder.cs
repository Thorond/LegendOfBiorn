using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ShipBuilder : Jobs {

	// Variables
	private bool workInProgress = false;
	private int nbrOfAssignedPeopleChosen = 0;

	// Getters and Setters 
	public bool WorkInProgress{ get { return workInProgress;} set{workInProgress = value;}}
	public int NbrOfAssignedPeopleChosen{ get{return nbrOfAssignedPeopleChosen;} set{ nbrOfAssignedPeopleChosen = value;}}
	
	// Constructor
	public ShipBuilder() : base() {
		durationForOneWorker = 4;
		quantityOfProductBroughtBackForOneWorker = 1;
	}
	
	// Functions 

	public override void determineQuantityAndDuration(){
		// durationOfWork = Math.Max(durationForOneWorker / nbrOfPeopleAssigned , 1); // au moins un jour de travail
		quantityOfProductBroughtBack = 1;
	}

	public void assignWork(){
		if (nbrOfAssignedPeopleChosen > 0 ){
			addOrRemoveSeveralPerson(nbrOfAssignedPeopleChosen);
			workInProgress = true;
			nbrOfAssignedPeopleChosen = 0;
			constructShip();
		}
	}
	public void closeAssignment(){
		if ( !workInProgress) nbrOfAssignedPeopleChosen = 0;
	}

	public void constructShip(){
		
	}
}
