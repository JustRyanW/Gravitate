using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public static class ResetLevel {
	

	static void RestartLevel(){
		Scene scene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (scene.name);

		


	}









}

 