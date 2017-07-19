using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
		public float moveSpeed = 1.0f;
		public float rotationSpeed = 30.0f;
		public GameController gameController;
		protected SoundEffect effect;
		protected StatusIcon icon;

		Vector3 moveVector = Vector3.zero;
		protected virtual void Start ()
		{
			gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent< GameController >();
			effect = GetComponentInChildren< SoundEffect >();
			icon = GetComponentInChildren< StatusIcon >();
		}

		protected virtual void Update ()
		{
				UpdateMovement ();
		}

		public void SetMoveVector (Vector3 moveVector)
		{
				this.moveVector = moveVector;
		}

		public void moveUp ()
		{
				moveVector.y = 1;
		}

		public void moveDown ()
		{
				moveVector.y = -1;
		}

		public void moveLeft ()
		{
				moveVector.x = -1;
		}

		public void moveRight ()
		{
				moveVector.x = 1;
		}

		protected void OnGUI ()
		{

		}

		private void UpdateMovement ()
		{
				// Set movement velocity
				rigidbody2D.velocity = moveVector.normalized * moveSpeed;

				// Set rotation
				Vector3 newLookAngle = Vector3.RotateTowards (transform.up, moveVector, moveSpeed * Time.deltaTime, 0.0f);
				transform.up = newLookAngle;

				moveVector = Vector3.zero;


		}
}
