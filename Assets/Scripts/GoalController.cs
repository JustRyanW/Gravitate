using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoalController : MonoBehaviour {
	void start(){

	}
	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
		}
	}
}