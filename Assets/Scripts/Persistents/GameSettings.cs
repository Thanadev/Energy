using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Thanagames.Energy.Persistents {
	
	[CreateAssetMenu(menuName = "Game/Settings")]
	public class GameSettings : ScriptableObject {
		public bool muteGameMusic = false;
	}
}