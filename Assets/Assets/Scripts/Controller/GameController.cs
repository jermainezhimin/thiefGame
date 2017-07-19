using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
		public Texture2D winningTexture;
		public Texture2D losingTexture;

		public Rect GUILabel; 
		public enum GameStates
		{
				Won,
				Lost,
				Playing,
		}
		public GameStates gameState = GameStates.Playing;
		public int numberOfTreasures = 1;

		private float loseDuration = 0.3f;
		private float loseTimer;

		// Use this for initialization
		void Start ()
		{
				loseDuration = 0.3f;
				loseTimer = -1.0f;
		}

		void Update ()
		{
				if (loseTimer > 0.0f) {
						loseTimer -= Time.deltaTime;
						if (loseTimer < 0.0f) {
								Application.LoadLevel (0);
						}
				}
		}
	
		public void setGameState (GameStates state)
		{
				if (state != GameStates.Playing) {
						loseTimer = loseDuration;
				}
				gameState = state;

		}
				

		void OnGUI ()
		{
				if (gameState == GameStates.Won) {
						GUI.DrawTexture (GUILabel, winningTexture);
				} else if (gameState == GameStates.Lost) {
						GUI.DrawTexture (GUILabel, losingTexture);
				}
		}
}