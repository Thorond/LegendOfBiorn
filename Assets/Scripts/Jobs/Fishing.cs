﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : Jobs {

	public Fishing() : base() {
		durationForOneWorker = 4;
		quantityOfProductBroughtBackForOneWorker = 2;
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
