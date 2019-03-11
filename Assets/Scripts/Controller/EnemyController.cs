using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Thanagames.Energy.Controllers {
	
	[RequireComponent(typeof(Rigidbody2D))]
	public class EnemyController : MonoBehaviour {

		public float speedFactor = 100;
        public float secBeforeActivation = 2f;

		protected Transform playerPos;
		protected Rigidbody2D rb;
        protected bool isActivated = false;

		void Start () {
			playerPos = GameObject.FindGameObjectWithTag("Player").transform;
			rb = GetComponent<Rigidbody2D>();

            StartCoroutine(StartActivationSequence());
		}
		
		void Update () {
			if (isActivated && playerPos != null) {
				rb.velocity = (playerPos.position - transform.position).normalized * Time.deltaTime * speedFactor;
			}
		}

        IEnumerator StartActivationSequence()
        {
            yield return new WaitForSeconds(secBeforeActivation);

            isActivated = true;
        }

		void OnTriggerEnter2D (Collider2D other) {
			if (other.CompareTag("Player")) {
				Destroy(other.gameObject);
				GameController.GetInstance().OnPlayerLose();
			}
		}
	}
}