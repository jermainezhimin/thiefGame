using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour
{
		GameController controller;
		protected void Start ()
		{
				controller = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
		}
		protected void OnTriggerEnter2D (Collider2D other)
		{
				Player player = other.gameObject.GetComponent< Player > ();

				if (player != null) {
						if (player.treasuresGotten == controller.numberOfTreasures) {
								controller.setGameState (GameController.GameStates.Won);
						}
				}
		}
}
