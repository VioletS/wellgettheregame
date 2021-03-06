﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3 {

	public class Item_Pickup : MonoBehaviour {

		private Item_Master itemMaster;

		// Use this for initialization
		void OnEnable () {
			SetInitialReferences();
			itemMaster.EventPickupAction += CarryOutPickupActions;
		}
		
		// Update is called once per frame
		void OnDisable () {
			itemMaster.EventPickupAction -= CarryOutPickupActions;			
		}

		void SetInitialReferences () {
			itemMaster = GetComponent<Item_Master>();
		}

		void CarryOutPickupActions (Transform tParent) {
			transform.SetParent(tParent);
			itemMaster.CallEventObjectPickup();
			transform.gameObject.SetActive(false);
		}

	}

}