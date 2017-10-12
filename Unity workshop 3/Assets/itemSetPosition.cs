using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSetPosition : MonoBehaviour {

	public Vector3 itemLocalPosition;

	void OnEnable () {
		SetPositionOnPlayer();
	}

	void Update () {
		SetPositionOnPlayer();
	}

	void SetPositionOnPlayer () {
		if (transform.root.CompareTag("Player")) {
			transform.localPosition = itemLocalPosition;
		}
	}

}
