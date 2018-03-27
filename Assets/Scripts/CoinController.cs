using UnityEngine;
using System.Collections;

public static class CoinController {

    public static GameObject[] coins;

	static void Start () {
        coins = GameObject.FindGameObjectsWithTag("Coin");
	}

    static void CollectCoin()
    {

    }
}
