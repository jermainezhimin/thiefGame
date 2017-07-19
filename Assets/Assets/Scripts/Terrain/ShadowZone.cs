	using UnityEngine;
using System.Collections;

public class ShadowZone : MonoBehaviour
{
		public Player.HiddenState ZoneState = Player.HiddenState.Black;

//		protected void Start ()
//		{
//				player = GetComponent< Player > ();
//		}

		private Player player = null;
		CircleCollider2D playerCollider = null;
		BoxCollider2D collider = null;
		Vector3 playerTransform;
		Vector2[] boundingPoints = new Vector2[4];
		bool alreadyIn = false;


		protected void OnTriggerEnter2D (Collider2D other)
		{
				player = other.gameObject.GetComponent< Player > ();
				playerCollider = other.gameObject.GetComponent<CircleCollider2D> ();
				

				for (int i = 0; i<4; i++) {
						boundingPoints [i] = new Vector2 ();
				}

		}
		protected void OnTriggerStay2D (Collider2D other)
		{
				if (player != null && !alreadyIn) {
						playerTransform = other.transform.position;
						boundingPoints [0].x = playerTransform.x;
						boundingPoints [0].y = playerTransform.y - playerCollider.radius;
						boundingPoints [1].x = playerTransform.x;
						boundingPoints [1].y = playerTransform.y + playerCollider.radius;
						boundingPoints [2].x = playerTransform.x - playerCollider.radius;
						boundingPoints [2].y = playerTransform.y;
						boundingPoints [3].x = playerTransform.x + playerCollider.radius;
						boundingPoints [3].y = playerTransform.y;
//						Debug.DrawLine (boundingPoints [0], boundingPoints [1], Color.red, 2, false);
//						Debug.DrawLine (boundingPoints [2], boundingPoints [3], Color.red, 2, false);
						bool containsBox = true;
						collider = GetComponent< BoxCollider2D > ();
						for (int i = 0; i<4; i++) {
//								Debug.Log (boundingPoints [i]);
								if (!collider.OverlapPoint (boundingPoints [i])) {
										containsBox = false;
										return;
								}
						}

						if (containsBox) {
								player.SetHiddenState (ZoneState);
								Debug.Log (player.state);
								alreadyIn = true;
						}
				}

		}

		protected void OnTriggerExit2D (Collider2D other)
		{
				Player player = other.gameObject.GetComponent< Player > ();
		
				if (player != null) {
						player.SetHiddenState (Player.HiddenState.Exposed);
						alreadyIn = false;
				}
		}

//		protected void Update ()
//		{
//				if (inZone (player.transform.position)) {
//						player.isHidden = true;
//				}
//		}
//
//		public bool inZone (Vector3 position)
//		{
//				if (position.x >= left && position.x <= right 
//						&& position.y >= up && position.y <= down) {
//						return true;
//				}
//				return false;
//		}
}