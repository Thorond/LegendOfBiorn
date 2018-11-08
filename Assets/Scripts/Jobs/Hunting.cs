using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunting : Jobs {

	// Variables

	public Hunting() : base() {
		durationForOneWorker = 2;
		quantityOfProductBroughtBackForOneWorker = 1;
	}
	
	public override void determineQuantityAndDuration(){
		// durationOfWork = nbrOfPeopleAssigned * durationForOneWorker;
		quantityOfProductBroughtBack = nbrOfPeopleAssigned * quantityOfProductBroughtBackForOneWorker;
	}

	public void updateFood(GameManager gameManager){
		determineQuantityAndDuration();
		gameManager.Resources.Food += quantityOfProductBroughtBack;
	}


}
