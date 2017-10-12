using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace s3 {

	public class Player_Health : MonoBehaviour {

		public int playerHealth;
		public Text healthText;

		private int maxHealth;
		private GameManager_Master gameManagerMaster;
		private Player_Master playerMaster;

		void OnEnable () {
			SetInitialReferences();
			SetUI();

			maxHealth = playerHealth;

			playerMaster.EventPlayerHealthDeduction += DeductHealth;
			playerMaster.EventPlayerHealthIncrease += IncreaseHealth;
		}

		void OnDisable () {
			playerMaster.EventPlayerHealthDeduction -= DeductHealth;
			playerMaster.EventPlayerHealthIncrease -= IncreaseHealth;
		}

		// Use this for initialization
		void Start () {
			StartCoroutine(TestHealthDeduction());
		}
		
		void SetInitialReferences () {
			gameManagerMaster = GameObject.Find("GameManager").GetComponent<GameManager_Master>();
			playerMaster = GetComponent<Player_Master>();
		}

		IEnumerator TestHealthDeduction () {
			yield return new WaitForSeconds(2);
			//DeductHealth(100);
			playerMaster.CallEventPlayerHealthDeduction(50);
		}

		void DeductHealth (int healthChanged) {
			playerHealth -= healthChanged;

			if (playerHealth <= 0) {
				playerHealth = 0;
				gameManagerMaster.CallEventGameOver();
			}

			SetUI();
		}

		void IncreaseHealth (int healthChanged) {
			playerHealth += healthChanged;

			if (playerHealth > maxHealth ) {
				playerHealth = maxHealth;
			}

			SetUI();

		}

		void SetUI () {
			if (healthText != null) {
				healthText.text = playerHealth.ToString();
			}
		}

	}

}