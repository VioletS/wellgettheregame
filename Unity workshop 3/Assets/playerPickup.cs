using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPickup : MonoBehaviour {

	[Tooltip("What layer is being used for items.")]
	public LayerMask layerToDetect;
	[Tooltip("What transform will the ray be fired from?")]
	public Transform rayTransformPivot;
	[Tooltip("The editor input button that will be used for picking up items.")]
	public string buttonPickup;

	private Transform itemAvailableForPickup;
	private GameObject goPickedUp;
	private Rigidbody rBody;

	private RaycastHit hit;
	private float detectRange = 3;
	private float detectRadius = 0.7f;
	private bool itemInRange;
	private bool itemPickedUp = false;

	private float labelWidth = 200;
	private float labelHeight = 50;

	// Update is called once per frame
	void Update () {
		CastRayForDetectingItems();
		CheckForItemPickupAttempt();
	}

	void CastRayForDetectingItems () {
		if (Physics.SphereCast(rayTransformPivot.position, detectRadius, rayTransformPivot.forward, out hit, detectRange, layerToDetect)) {
			itemAvailableForPickup = hit.transform;
			goPickedUp = itemAvailableForPickup.gameObject;
			itemInRange = true;
		} else {
			itemInRange = false;
		}
	}

	void CheckForItemPickupAttempt () {
		if (Input.GetButtonDown(buttonPickup) && Time.timeScale > 0 && itemInRange && !itemPickedUp) {
			itemAvailableForPickup.parent = rayTransformPivot;

			rBody = itemAvailableForPickup.GetComponent<Rigidbody>();
			rBody.useGravity = false;

			itemPickedUp = true;
		} else if (Input.GetButtonDown(buttonPickup) && itemPickedUp) {
			Debug.Log("Drop attempted");
			rayTransformPivot.DetachChildren();
			rBody.useGravity = true;
			itemPickedUp = false;
		}
	}

	void OnGUI () {
		if (itemInRange && itemAvailableForPickup != null && itemAvailableForPickup.name != "Player") {
			GUI.Label(new Rect(Screen.width/2 - labelWidth/2, Screen.height/2, labelWidth, labelHeight), itemAvailableForPickup.name);
		}
	}
}
