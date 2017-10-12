using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3 {

	public class Item_Name : MonoBehaviour {

		public string itemName;

		// Use this for initialization
		void Start () {
			SetItemName();
		}
		
		void SetItemName () {
			transform.name = itemName;
		}
	}

}