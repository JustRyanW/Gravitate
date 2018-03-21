using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public static class ResetLevel : MonoBehaviour {
	

	static void RestartLevel(){
		Scene scene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (scene.name);

		


	}









}

 