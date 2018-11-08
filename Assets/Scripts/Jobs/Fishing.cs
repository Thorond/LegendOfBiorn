using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishing : Jobs {

	public Fishing() : base() {
		durationForOneWorker = 4;
		quantityOfProductBroughtBackForOneWorker = 10;
	}
	
	public override void determineQuantityAndDuration(int nbrOfWorker){
		durationOfWork = nbrOfWorker * durationForOneWorker;
		quantityOfProductBroughtBack = nbrOfWorker * quantityOfProductBroughtBackForOneWorker;
	}
}
