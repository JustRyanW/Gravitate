using UnityEngine;
using System.Collections;

public static class CoinController {

	public static CoinIdentifier[,] coins = new CoinIdentifier[0, 0];

	public static void SetCoin(int coinGroup, int coinNumber, CoinIdentifier coin){
		coins [coinGroup, coinNumber] = coin;
	}

	public static void CollectCoin(int coinGroup, int coinNumber)
    {

    }
}
