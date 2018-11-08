using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunting : Jobs {

	// Variables

	public Hunting() : base() {
		durationForOneWorker = 2;
		quantityOfProductBroughtBackForOneWorker = 5;
	}
	
	public override void determineQuantityAndDuration(int nbrOfWorker){
		durationOfWork = nbrOfWorker * durationForOneWorker;
		quantityOfProductBroughtBack = nbrOfWorker * quantityOfProductBroughtBackForOneWorker;
	}


}
