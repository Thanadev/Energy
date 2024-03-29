﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Thanagames.Energy.Persistents;

namespace Thanagames.Energy.Controllers {
	
	[RequireComponent(typeof(AudioSource))]
	public class MenuController : MonoBehaviour {
		[Header("Resources")]
		public GameSettings settings;
		public Sprite musicOn;
		public Sprite musicOff;

		[Header("Optional")]
		public GameObject creditsPanel;
		public Button musicButton;

		private AudioSource musicSource;

		// Use this for initialization
		void Start () {
			musicSource = GetComponent<AudioSource>();

			if (musicButton != null) {
				UpdateMusicComponents();
			}
		}

		public void MuteMusic () {
			settings.muteGameMusic = !settings.muteGameMusic;
			UpdateMusicComponents();
		}

		public void ToggleCreditsPanel () {
			creditsPanel.SetActive(!creditsPanel.activeSelf);
		}

		public void LoadMenu () {
			SceneManager.LoadScene(0);
		}

		public void LoadLevel1 () {
			SceneManager.LoadScene(1);
		}

		public void Quit () {
			Application.Quit();
		}

		private void UpdateMusicComponents () {
			musicSource.enabled = !settings.muteGameMusic;

			if (settings.muteGameMusic) {
				musicButton.image.sprite = musicOff;
			} else {
				musicButton.image.sprite = musicOn;
			}
		}
	}
}