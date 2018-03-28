using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public float timer; //This float will store the time


	void Update () {
		
		timer += Time.deltaTime;

		GetComponent<TextMesh> ().text = Mathf.Floor (timer).ToString ();
	
	}
}
