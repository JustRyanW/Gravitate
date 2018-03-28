using UnityEngine;
using System.Collections;

public class CoinIdentifier : MonoBehaviour {

	public static int maxCoinGroup;

    public int coinGroup;
    public int coinNumber;
	public bool isCollected;

    TextMesh coinText;

	void Start () {
        coinText = GetComponentInChildren<TextMesh>();
		coinText.text = (coinNumber + 1).ToString() ;
		CoinController.SetCoin (coinGroup ,coinNumber , gameObject.GetComponent<CoinIdentifier>());
		if (coinGroup > maxCoinGroup) {
			maxCoinGroup = coinGroup;
		}
	}

	void OnTriggerEnter2D(){
		bool isCollected = true;
		//CoinController.CollectCoin (coinGroup, coinNumber);
	}
}
