using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {

	// Variables
	private People people;

	[SerializeField] private Text displayOfNbrOfPeople;

	// Getters and Setters

	public People People{
		get {
			return people;
		}
	}
	

	// Use this for initialization
	void Start () {
		people = new People();
		textDisplay();
		Debug.Log("Jeu lancé.");
	}
	
	// Update is called once per frame
	void Update () {
		textDisplay();
	}

	void textDisplay(){
		displayOfNbrOfPeople.text = "Slaves : " + people.NbrOfSlave.ToString()
			+ "\nVikings : " + people.NbrOfVikings.ToString()
			+ "\nShield-maidens : " + people.NbrOfShielMaidens.ToString() ;
	}

	
}
