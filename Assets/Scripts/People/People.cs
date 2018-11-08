using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People  {

	// Variables
	private Slaves[] slaves;
	private int nbrOfSlave;
	private Viking[] vikings;
	private int nbrOfVikings;
	private ShieldMaiden[] shieldMaidens;
	private int nbrOfShielMaidens;

	// Getters and Setters 

	public int NbrOfSlave{
		get{
			return nbrOfSlave;
		}
		set{
			nbrOfSlave = value;
		}
	}
	public int NbrOfVikings{
		get{
			return nbrOfVikings;
		}
		set{
			nbrOfVikings = value;
		}
	}
	public int NbrOfShielMaidens{
		get{
			return nbrOfShielMaidens;
		}
		set{
			nbrOfShielMaidens = value;
		}
	}

	// Constructor
	public People(){
		nbrOfSlave = 5;
		nbrOfVikings = 20;
		nbrOfShielMaidens = 10;
	}

}
