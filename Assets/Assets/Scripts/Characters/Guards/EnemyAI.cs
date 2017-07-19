using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
		public Transform[] patrolRoute;

		private int nextPatrolCounter;

		private enum State
		{
				Patrol,
				Chase,
				Check,
		}

		private Guard guard;
		private Player player;
		private State state;
		private Vector3 targetPosition;
		private float timer;
		private bool hasDetected = false;
		private float checkingTime = 1.0f; //milliseconds

		protected void Start ()
		{
				player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
				guard = GetComponent<Guard> ();

				state = State.Patrol;
				guard.moveSpeed = guard.normalSpeed;
				nextPatrolCounter = 0;
		}

		protected void Update ()
		{
				MovementUpdate ();

				PatrolUpdate ();
				ChaseUpdate ();
				CheckUpdate ();
		}

		private void MovementUpdate ()
		{
				Vector3 moveDirection = targetPosition - transform.position;
				guard.SetMoveVector (moveDirection);
		}

		private void PatrolUpdate ()
		{
				if (state == State.Patrol) {
						if (IsAtTargetPosition ()) {
								nextPatrolCounter ++;
								if (nextPatrolCounter >= patrolRoute.Length) {
										nextPatrolCounter = 0;
								}
						}

						targetPosition = patrolRoute [nextPatrolCounter].position;
				}
		}

		private void ChaseUpdate ()
		{
				if (state != State.Chase && guard.IsTargetOnSight (player)) {
						guard.NoticeEffect ();
						state = State.Chase;
						guard.moveSpeed = guard.chasingSpeed;
				}

				if (state == State.Chase) {
						targetPosition = player.transform.position;
						Debug.Log ("Chasing state");

						if (!guard.IsTargetOnSight (player)) {
								guard.SupriseEffect ();
								state = State.Check;
								timer = checkingTime;
//								startCheckStateTime = System.DateTime.Now;
								guard.moveSpeed = guard.checkingSpeed;
						}
				}
		}

		private void CheckUpdate ()
		{
				if (state == State.Check) {
						if (timer <= 0) {
								nextPatrolCounter = FindClosestRoute ();
								state = State.Patrol;
								guard.moveSpeed = guard.normalSpeed;
						} else {
								timer -= Time.deltaTime;
						}
				}
				
		}

		private bool IsAtTargetPosition ()
		{
				return (guard.transform.position - targetPosition).magnitude < ((BoxCollider2D)collider2D).size.magnitude;
		}

		private int FindClosestRoute ()
		{
				int closestRoute = 0;
				for (int i=0; i<patrolRoute.Length; i++) {
						float minDistance = (transform.position - patrolRoute [closestRoute].position).magnitude;
						float currentDistance = (transform.position - patrolRoute [i].position).magnitude;
						if (currentDistance < minDistance) {
								closestRoute = i;
						}
				}

				return closestRoute;
		}
}
