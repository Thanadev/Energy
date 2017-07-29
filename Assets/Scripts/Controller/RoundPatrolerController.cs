using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Thanagames.Energy.Controllers {
	
	public class RoundPatrolerController : EnemyController {

		public Transform beacon;
		public float speed = 1;
		public int angleDegrees = 1;
		public float periodeRadius = 1;

		private float angleRadians;

		void Awake () {
			angleRadians = angleDegrees * Mathf.PI / 180;
		}

		// Update is called once per frame
		void Update () {
			angleRadians += speed * Time.deltaTime;
			Vector3 nextPos = new Vector3((beacon.position.x + Mathf.Cos(angleRadians)), (beacon.position.y + Mathf.Sin(angleRadians)), transform.position.z);

			transform.position = nextPos;
		}

		void OnTriggerEnter2D (Collider2D other) {
			if (other.tag == "Player") {
				Destroy(other.gameObject);
				GameController.GetInstance().OnPlayerLose();
			}
		}
	}
}