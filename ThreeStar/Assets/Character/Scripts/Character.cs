using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThreeStar.Character {
    [RequireComponent (typeof (Rigidbody))]
    public class Character : MonoBehaviour {
        private InputManagement.InputManager inputManager = null;
        public float leftRightMovementSpeed = 5f;

        public float jumpVelocity = 5f;
        public float fallMultiplier = 2.5f;
        public float lowJumpMultiplier = 2f;
        private Rigidbody rb;

        private void Awake () {
            inputManager = FindObjectOfType<InputManagement.InputManager> ();
            rb = GetComponent<Rigidbody> ();
        }

        private void Update () {
            MoveCharacter ();
        }

        private void JumpOrCrouch () {
            float hAxis = inputManager.GetAxis ("Vertical");
            if (hAxis == 1) {
                rb.velocity = Vector3.up * jumpVelocity;
            } else if (hAxis == -1) {
                Debug.Log ("Crouch");
            }
        }

        private void MoveLeftOrRight () {
            float vAxis = inputManager.GetAxis ("Horizontal");
            if (vAxis == 1) {
                transform.Translate (leftRightMovementSpeed * Time.deltaTime, 0, 0);
            } else if (vAxis == -1) {
                transform.Translate (-leftRightMovementSpeed * Time.deltaTime, 0, 0);
            }
        }

        private void MoveCharacter () {
            if (inputManager != null && rb != null) {
                JumpOrCrouch ();
                MoveLeftOrRight ();
                Fall ();
            }
        }

        private void Fall () {
            if (rb.velocity.y < 0) {
                rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            } else if (rb.velocity.y > 0 && !inputManager.GetButton ("Horizontal")) {
                rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
    }
}
