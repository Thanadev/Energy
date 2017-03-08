using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour {

	public float speedFactor = 100;

	protected Transform playerPos;
	protected Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		playerPos = GameObject.FindGameObjectWithTag("Player").transform;
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = (playerPos.position - transform.position).normalized * Time.deltaTime * speedFactor;
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			GameController.GetInstance().OnPlayerLose();
		}
	}
}
