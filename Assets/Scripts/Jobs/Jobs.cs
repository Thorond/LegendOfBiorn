using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Jobs  {


	// Variables
	protected int nbrOfPeopleAssigned;
	protected int durationOfWork;
	protected int durationForOneWorker;
	protected int quantityOfProductBroughtBack;
	protected int quantityOfProductBroughtBackForOneWorker;

	
	// Constructor
	public Jobs(){
		nbrOfPeopleAssigned = 0;
		durationOfWork = 0;
		quantityOfProductBroughtBack = 0;
	}



	// Functions
	public void assignAnotherPerson(){
		nbrOfPeopleAssigned += 1;
	}
	public void removeAPerson(){
		nbrOfPeopleAssigned -= 1;
	}
	public void addOrRemoveSeveralPerson(int nbr){
		nbrOfPeopleAssigned = nbr;
	}

	public abstract void determineQuantityAndDuration();


	// Getters and Setters
	public int NbrOfPeopleAssigned{
		get{
			return nbrOfPeopleAssigned;
		}
		set{
			nbrOfPeopleAssigned = value;
		}
	}
}
