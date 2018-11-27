using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viking : Inhabitant {

	public Viking() : base() {
		this.foodGatheringEfficiency = 5;
		this.woodGatheringEfficiency = 5;
		this.ironGatheringEfficiency = 5;
		this.shipConstructionEffeciency = 5;
		this.battleEfficiency = 10;
	}
}
