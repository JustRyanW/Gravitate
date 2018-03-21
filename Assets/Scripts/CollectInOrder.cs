using UnityEngine;
using System.Collections;

public class CollectInOrder : MonoBehaviour {

	public float collectNumber; // This is the number the player has to hit next.	
	public int collectLimit; // The amount of coins the player needs to collect in order.

	void OnTriggerEnter2D(Collider2D coll){ // If the player hits a 2D Trigger
		if (coll.gameObject.name == "Collect" + collectNumber) { //If that game object has a name which is collect + the number we are currently on. This will start at 1 and go up.
			Destroy (coll.gameObject);
			collectNumber++;
			if (collectNumber > collectLimit) { //If the player has collected the amount of coins we need. Use this statement to now do something in your game when this happens.
				Debug.Log ("Woo, you collected them all!");
				ResetCollectNumber ();
			}
		}
	}

	//This function is to reset the number of coins collected in order.
	// Potentially use this if the player hits coins in the wrong order.
	//At this moment, this isnt used. Find a way to use this.
	public void ResetCollectNumber(){
		collectNumber = 1;
	}
}
