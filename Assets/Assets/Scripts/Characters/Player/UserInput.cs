using UnityEngine;
using System.Collections;

public class UserInput : MonoBehaviour {
	private Player player;


	protected void Start () {
		player = GetComponent< Player > ();
	}
	

	protected void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			player.moveUp();
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			player.moveDown();
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			player.moveLeft();
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			player.moveRight();
		}
	}
}
