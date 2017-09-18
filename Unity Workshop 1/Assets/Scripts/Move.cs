using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public float speed;

	private float posY;
	private float posX;
	private float posZ;

	private float rotX;
	private float rotZ;

	private float verti;
	private float hori;

	private float offsetHeight;
	private RaycastHit planeCheck;
	private Vector3 tankLocal;


	// Use this for initialization
	void Start () {

		posY = transform.position.y;
		posX = transform.position.x;
		posZ = transform.position.z;

		if (Physics.Raycast(transform.position, -transform.up, out planeCheck)) {

			offsetHeight = planeCheck.distance;

		}
	}
	
	// Update is called once per frame
	void Update () {

		hori = Input.GetAxis("Horizontal");
		verti = Input.GetAxis("Vertical");

		if (Physics.Raycast(transform.position, -transform.up, out planeCheck, 300)) {

			rotZ = planeCheck.transform.eulerAngles.z;
			rotX = planeCheck.transform.eulerAngles.x;

			if (offsetHeight != planeCheck.distance) {
				posY += offsetHeight - planeCheck.distance;
			}

		}

	}

	void FixedUpdate () {

		if (verti > 0 && hori == 0) {
			posX = posX + speed;
		} else if (verti < 0 && hori == 0) {
			posX = posX - speed;
		}

		if (hori > 0 && verti == 0) {
			posZ = posZ - speed;
		} else if (hori < 0 && verti == 0) {
			posZ = posZ + speed;
		}

		if (hori > 0 && verti > 0) {
			posZ = posZ - (speed/2);
			posX = posX + (speed/2);
		} else if (hori > 0 && verti < 0) {
			posZ = posZ - (speed/2);
			posX = posX - (speed/2);
		}

		if (hori < 0 && verti > 0) {
			posZ = posZ + (speed/2);
			posX = posX + (speed/2);
		} else if ( hori < 0 && verti < 0) {
			posZ = posZ + (speed/2);
			posX = posX - (speed/2);
		}

		transform.eulerAngles = new Vector3(rotX, 0, rotZ);
		transform.localPosition = new Vector3(posX, posY, posZ);

	}
}
