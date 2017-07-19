using UnityEngine;
using System.Collections;

public class Player : Character
{
		public enum HiddenState
		{
				Black,
				Grey,
				Exposed,
		}

		public int treasuresGotten = 0;

		public HiddenState state { get; private set; }

		public void SetHiddenState (HiddenState state) {
			this.state = state;
			if (state == HiddenState.Exposed) {
				icon.ShowVisibleState ();
			} else {
				icon.ShowInvisibleState ();
			}
		}

		protected override void Start ()
		{
				base.Start ();
				state = HiddenState.Exposed;
		}


	protected void OnCollisionEnter2D (Collision2D collision) {
		Guard guard = collision.gameObject.GetComponent< Guard >();
		if (guard != null) {
			gameController.setGameState (GameController.GameStates.Lost);
		}
	}

	public void PickupTreasureEffect () {
		effect.PlayTreasureClip ();
	}
}
