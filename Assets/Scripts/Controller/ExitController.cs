using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Thanagames.Energy.Controllers {
	
	public class ExitController : MonoBehaviour {

		public int neededKeys = 0;
		public ParticleSystem particles;

		GameController gc;
		bool usable = false;

		// Use this for initialization
		void Start () {
			gc = GameController.GetInstance();
		}

		public void OnKeyActivated () {
			neededKeys --;

			if (neededKeys <= 0) {
				OnActivate();
			}
		}

		void OnTriggerEnter2D (Collider2D other) {
			if (usable && other.tag == "Player") {
				Destroy(other.gameObject);
				gc.OnPlayerWin();
			}
		}

		void OnActivate () {
			particles.Play();
			usable = true;
		}
	}
}