using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Thanagames.Energy.Controllers {
	
	public class TimerController : MonoBehaviour {

		public Text timer;

		GameController gc;

		// Use this for initialization
		void Start () {
			gc = GameController.GetInstance();
		}
		
		// Update is called once per frame
		void LateUpdate () {
			timer.text = gc.Duration.ToString("F2");
		}
	}
}