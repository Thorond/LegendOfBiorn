using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {

	// Variables
	private People people;
	private Resource resources;

	[SerializeField] private Text displayOfNbrOfPeople;
	[SerializeField] private Text displayOfResources;

	// Getters and Setters

	public People People{
		get {
			return people;
		}
	}

	public Resource Resources{
		get{
			return resources;
		}
	}
	

	// Use this for initialization
	void Start () {
		people = new People();
		resources = new Resource();

		textDisplay();
		Debug.Log("Jeu lancé.");
	}
	
	// Update is called once per frame
	void Update () {
		textDisplay();
	}


	// Functions 
	
	void textDisplay(){
		displayOfNbrOfPeople.text = people.textDisplay();
		displayOfResources.text = resources.textDisplay();
	}

	
}
