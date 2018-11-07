using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunting : MonoBehaviour {

	// Variables
	private int nbrOfHunter;
	

	// Functions

	public void addAHunter(){
		nbrOfHunter += 1;
	}
	public void removeAHunter(){
		nbrOfHunter -= 1;
	}
	public void addOrRemoveSeveralHunters(int nbr){
		nbrOfHunter = nbr;
	}
	
	// Getters and Setters

	public int NbrOfHunter{
		get{
			return nbrOfHunter;
		}
		set{
			nbrOfHunter = value;
		}
	}


}
