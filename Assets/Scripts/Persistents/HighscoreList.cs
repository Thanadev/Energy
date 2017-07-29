using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Thanagames.Energy.Persistents {
	
	[CreateAssetMenu(menuName = "Game/Highscores")]
	public class HighscoreList : ScriptableObject {
		public float[] highscores;
	}
}
