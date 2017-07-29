using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Thanagames.Energy.Controllers {
	
	public class KeyController : MonoBehaviour {

		public ExitController exit;

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		public void OnTriggerEnter2D (Collider2D other) {
			if (other.tag == "Player") {
				exit.OnKeyActivated();
				Destroy(gameObject);
			}
		}
	}
}