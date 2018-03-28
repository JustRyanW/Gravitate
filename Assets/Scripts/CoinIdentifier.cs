using UnityEngine;
using System.Collections;

public class CoinIdentifier : MonoBehaviour {

    public int coinGroup;
    public int coinNumber;

    TextMesh coinText;

	void Start () {
        coinText = GetComponentInChildren<TextMesh>();
        coinText.text = coinNumber.ToString();
	}
}
