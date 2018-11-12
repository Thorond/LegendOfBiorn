using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ShipBuilder : Jobs {

	// Variables
	private bool workInProgress = false;
	private int nbrOfAssignedPeopleChosen = 0;
	private int remainingTimeForConstruction = 0;

	// Getters and Setters 
	public bool WorkInProgress{ get { return workInProgress;} set{workInProgress = value;}}
	public int NbrOfAssignedPeopleChosen{ get{return nbrOfAssignedPeopleChosen;} set{ nbrOfAssignedPeopleChosen = value;}}
	public int RemainingTimeForConstruction{get{return remainingTimeForConstruction;} set{ remainingTimeForConstruction = value;}}

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

	public void assignWork(People people){
		if (nbrOfAssignedPeopleChosen > 0 ){
			addOrRemoveSeveralPerson(nbrOfAssignedPeopleChosen);
			workInProgress = true;
			people.NbrOfSlave -= nbrOfAssignedPeopleChosen;
			nbrOfAssignedPeopleChosen = 0;
			constructShip();
		}
	}
	public void closeAssignment(){
		if ( !workInProgress) nbrOfAssignedPeopleChosen = 0;
	}

	public void constructShip(){
		remainingTimeForConstruction = 4;
	}
	public void inConstruction(Ships ships, People people){
		if ( workInProgress) {
			if ( remainingTimeForConstruction <= 0 ){
				// rajouter un navire dans Ships, differencier en fonction du type
				ships.NbrOfShipType1 +=1;
				// rajouter le nombre de slave
				people.NbrOfSlave += nbrOfPeopleAssigned;
				nbrOfPeopleAssigned = 0;
				workInProgress = false;
			} else if ( remainingTimeForConstruction > 0 ){
				remainingTimeForConstruction -= 1;
			}
		} 
	}
}
