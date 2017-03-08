using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public GameSettings settings;

	private static GameController instance;

	public int maxLevel;
	public HighscoreList highscores;

	private int level = 1;
	private float duration = 0;

	public static GameController GetInstance () {
		return instance;
	}

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(gameObject);
			GetComponent<AudioSource>().enabled = !settings.muteGameMusic;
		} else {
			this.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		duration += Time.deltaTime;
	}

	public void OnPlayerWin () {
		level++;

		if (level < maxLevel) {
			SceneManager.LoadScene(level);
		} else {
			SceneManager.activeSceneChanged += delegate {
				InitWinScene();
			};
				
			SceneManager.LoadScene("win");
		}
	}

	public void InitWinScene () {
		GameObject.FindGameObjectWithTag("Finish").GetComponent<Text>().text = duration + " seconds";
		Text highscoretext = GameObject.FindGameObjectWithTag("Highscores").GetComponent<Text>();
		highscoretext.text = "";

		for (int i = 0; i < 5; i++) {
			if (highscores.highscores[i] > duration || highscores.highscores[i] == 0) {
				highscores.highscores[i] = duration;
				break;
			}
		}

		for (int i = 0; i < 5; i++) {
			highscoretext.text += highscores.highscores[i] + " seconds\n";
		}
	}

	public void OnPlayerLose () {
		level = 1;
		SceneManager.LoadScene("gameOver");
		Destroy(gameObject);
		Destroy(GameObject.Find("GUI"));
	}

	public float Duration {
		get {
			return this.duration;
		}
	}
}
