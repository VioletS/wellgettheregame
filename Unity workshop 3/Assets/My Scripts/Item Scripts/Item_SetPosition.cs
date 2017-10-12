using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3 {
	public class Item_SetPosition : MonoBehaviour {

		private Item_Master itemMaster;
		public Vector3 itemLocalPosition;

		// Use this for initialization
		void Start () {
			SetInitialReferences();
			SetPositionOnPlayer();

			itemMaster.EventObjectPickup += SetPositionOnPlayer;
		}
		
		// Update is called once per frame
		void OnDisable () {
			itemMaster.EventObjectPickup -= SetPositionOnPlayer;			
		}

		void SetInitialReferences () {
			itemMaster = GetComponent<Item_Master>();
		}

		void SetPositionOnPlayer () {
			if (transform.root.CompareTag(GameManager_References._playerTag)) {
				transform.localPosition = itemLocalPosition;
			}
		}
	}		
}