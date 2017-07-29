using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Thanagames.Energy.Controllers {
	
	[RequireComponent(typeof(Rigidbody2D))]
	public class PatrolerController : EnemyController {

		public Transform beacon1;
		public Transform beacon2;

		Transform target;

		void Awake() {
			target = beacon2;
		}
		
		// Update is called once per frame
		void Update () {
			Vector2 direction = (Vector2) (target.position - transform.position);
			rb.velocity = direction.normalized * Time.deltaTime * speedFactor;
		}

		void UpdateDirection () {
			Vector2 distBeacon1 = beacon1.position - transform.position;
			Vector2 distBeacon2 = beacon2.position - transform.position;

			if (distBeacon1.sqrMagnitude > distBeacon2.sqrMagnitude) {
				target = beacon1;
			} else {
				target = beacon2;
			}
		}

		void OnTriggerEnter2D (Collider2D other) {
			if (other.tag == "Player") {
				GameController.GetInstance().OnPlayerLose();
			} else if (other.tag == "Beacon") {
				UpdateDirection();
			}
		}
	}
}