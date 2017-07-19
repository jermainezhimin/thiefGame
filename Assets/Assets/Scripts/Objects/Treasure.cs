using UnityEngine;
using System.Collections;

public class Treasure : MonoBehaviour
{

		protected void OnTriggerEnter2D (Collider2D other)
		{
				Player player = other.gameObject.GetComponent< Player > ();
				if (player != null) {
						player.treasuresGotten++;
						player.PickupTreasureEffect ();
						Destroy (gameObject);
				}
		}
}
