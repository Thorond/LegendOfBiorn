using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

	// Variables
	private People people;

	// Getters and Setters

	public People People{
		get {
			return people;
		}
	}
	

	// Use this for initialization
	void Start () {
		Debug.Log("yooo");
		people = new People();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
