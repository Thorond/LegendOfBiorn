using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource {

	// Variables

	private int gold;
	private int wood;
	private int iron;
	private int food;

	// Getters and Setters

	public int Gold{
		get{
			return gold;
		}
		set{
			gold = value;
		}
	}

	public int Wood{
		get{
			return wood;
		}
		set{
			wood = value;
		}
	}

	public int Iron{
		get{
			return iron;
		}
		set{
			iron = value;
		}
	}

	public int Food{
		get{return food;}
		set{food = value;}
	}
	
	// Constructor

	public Resource(){
		gold = 50;
		wood = 50;
		iron = 10;
		food = 40;
	}
}
