﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using Thanagames.Energy.Persistents;

namespace Thanagames.Energy.Controllers {

	public class GameController : MonoBehaviour {
		public GameSettings settings;

		private static GameController instance;

		public int maxLevel;
		public HighscoreList highscores;

		private int level = 1;
		private float duration = 0;

		private UnityAction<Scene, Scene> initWinDelegate;

		public static GameController GetInstance () {
			return instance;
		}

		// Use this for initialization
		void Awake () {
			if (instance == null) {
				instance = this;
				DontDestroyOnLoad(gameObject);
				GetComponent<AudioSource>().enabled = !settings.muteGameMusic;

				initWinDelegate = InitWinScene;
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
				SceneManager.activeSceneChanged += initWinDelegate;
				SceneManager.LoadScene("win");
			}
		}

		public void InitWinScene (Scene scene1, Scene scene2) {
			Destroy(gameObject);
			Destroy(GameObject.Find("GUI"));
			GameObject.FindGameObjectWithTag("Finish").GetComponent<Text>().text = duration + " secondes";
			Text highscoretext = GameObject.FindGameObjectWithTag("Highscores").GetComponent<Text>();
			highscoretext.text = "";

			for (int i = 0; i < 5; i++) {
				if (highscores.highscores[i] > duration || highscores.highscores[i] == 0) {
					highscores.highscores[i] = duration;
					break;
				}
			}

			for (int i = 0; i < 5; i++) {
				highscoretext.text += highscores.highscores[i] + " secondes\n";
			}

			SceneManager.activeSceneChanged -= initWinDelegate;


		}

		public void OnPlayerLose () {
			level = 0;

			Destroy(gameObject);
			Destroy(GameObject.Find("GUI"));
			SceneManager.LoadScene("gameOver");
		}

		public float Duration {
			get {
				return this.duration;
			}
		}
	}
}