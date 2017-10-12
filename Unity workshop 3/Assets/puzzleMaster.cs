using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puzzleMaster : MonoBehaviour {

	public int numberOfKeys;
	public GameObject canvasWin;
	public GameObject canvasKeys;
	public LayerMask keyLayer;

	private Text keyAmmountText;
	private int numberOfItemsCollected;

	// Update is called once per frame
	void Update () {
		CheckForAmmountOfKeys();
		UpdateKeyCanvas();
	}

	void OnTriggerEnter (Collider col) {
		
		Debug.Log(col.gameObject.layer);

		if (keyLayer != null && col.gameObject.layer == LayerMask.NameToLayer("Item")) {
			numberOfItemsCollected ++;
		}

	}

	void UpdateKeyCanvas () {
		keyAmmountText = canvasKeys.GetComponentInChildren<Text>();
		keyAmmountText.text = "Keys collected: " + numberOfItemsCollected + "/" + numberOfKeys;
	}

	void CheckForAmmountOfKeys () {
		if (numberOfItemsCollected == numberOfKeys) {
			canvasWin.SetActive(true);
		}
	}
	
}
