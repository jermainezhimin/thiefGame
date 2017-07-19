using UnityEngine;
using System.Collections;

public class TitleGUI : MonoBehaviour
{
		public Texture2D titleBackground;
		public Texture2D playButton;
		public Texture2D exitButton;

		protected void OnGUI ()
		{
				DrawTitleBackground ();
				DrawButtons ();
		}

		private void DrawTitleBackground ()
		{
				GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), titleBackground);
		}

		private void DrawButtons ()
		{
				Rect playButtonCanvas = new Rect (Screen.width * 0.6f,
		                                  		  Screen.height * 0.6f,
		                                  		  playButton.width,
		                                  		  playButton.height);
				if (GUI.Button (playButtonCanvas, playButton)) {
						Application.LoadLevel (Application.loadedLevel + 1);
				}

				Rect exitButtonCanvas = new Rect (Screen.width * 0.6f,
				                                  Screen.height * 0.6f + playButton.height + 20.0f,
				                                  exitButton.width,
				                                  exitButton.height);
				if (GUI.Button (exitButtonCanvas, exitButton)) {
						Application.Quit ();
				}
		}
	
}
