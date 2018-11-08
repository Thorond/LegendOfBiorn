using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ShipBuilder : Jobs {

	public ShipBuilder() : base() {
		durationForOneWorker = 4;
		quantityOfProductBroughtBackForOneWorker = 1;
	}
	
	public override void determineQuantityAndDuration(){
		// durationOfWork = Math.Max(durationForOneWorker / nbrOfPeopleAssigned , 1); // au moins un jour de travail
		quantityOfProductBroughtBack = 1;
	}
}
