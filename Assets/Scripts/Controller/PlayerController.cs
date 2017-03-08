using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {
	public float speedFactor = 100;

	Vector2 direction;
	Rigidbody2D rb;
	AudioSource moveEffect;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		direction = Vector2.zero;
		moveEffect = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw("Horizontal") != 0) {
			direction.x = Input.GetAxisRaw("Horizontal");
			direction.y = 0;
			PlayMovementEffects();
		} else if (Input.GetAxisRaw("Vertical") != 0) {
			direction.x = 0;
			direction.y = Input.GetAxisRaw("Vertical");
			PlayMovementEffects();
		}

		rb.velocity = direction;
		rb.velocity *= speedFactor * Time.deltaTime;
	}

	private void PlayMovementEffects () {
		if (GameController.GetInstance().settings.muteGameMusic == false) {
			moveEffect.Play();
		}
	}
}
