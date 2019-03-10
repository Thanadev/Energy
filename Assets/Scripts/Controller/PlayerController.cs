using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Thanagames.Energy.Controllers {
	
	[RequireComponent(typeof(Rigidbody2D))]
	public class PlayerController : MonoBehaviour {
        public Transform baseJoystick;
        public Transform handleJoystick;
		public float speedFactor = 100;

		protected Vector2 direction;
		protected Rigidbody2D rb;
        protected Vector2 startPosition;
        protected Vector2 endPosition;

        void Start () {
			rb = GetComponent<Rigidbody2D>();
			direction = Vector2.zero;

            baseJoystick = GameObject.FindGameObjectWithTag("Joy_Base").transform;
            handleJoystick = GameObject.FindGameObjectWithTag("Joy_Handle").transform;
            handleJoystick.localPosition = Vector3.zero;
        }
		
		void Update () {
            if (Input.touchCount > 0 || Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                Move();
            }
            
            rb.velocity = direction;
			rb.velocity *= speedFactor * Time.deltaTime;
		}

        protected void Move()
        {
#if UNITY_EDITOR
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            }

#endif
#if UNITY_ANDROID

            if (Input.touchCount > 0)
            {
                Touch touch = Input.touches[0];

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        // Stockage du point de départ
                        startPosition = touch.position;
                        break;
                    case TouchPhase.Moved:
                        // Stockage du point de fin
                        endPosition = touch.position;

                        Vector3 moveDelta = endPosition - startPosition;

                        if (Mathf.Abs(moveDelta.x) > Mathf.Abs(moveDelta.y))
                        {
                            moveDelta.Normalize();
                            direction.x = moveDelta.x;
                            direction.y = 0;
                        }
                        else if (Mathf.Abs(moveDelta.x) < Mathf.Abs(moveDelta.y))
                        {
                            moveDelta.Normalize();
                            direction.x = 0;
                            direction.y = moveDelta.y;
                        }
                        break;
                }
            }
# endif
        }
    }
}