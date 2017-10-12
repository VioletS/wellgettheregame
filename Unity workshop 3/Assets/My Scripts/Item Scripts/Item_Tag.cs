using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace s3 {

	public class Item_Tag : MonoBehaviour {

		public string itemTag;

		// Use this for initialization
		void OnEnable () {
			SetTag();	
		}
		
		// Update is called once per frame
		void SetTag () {
			if (itemTag == "") {
				itemTag = "Untagged";
			}

			transform.tag = itemTag;
		}
	}
}