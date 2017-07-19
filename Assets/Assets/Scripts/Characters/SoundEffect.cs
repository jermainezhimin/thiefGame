using UnityEngine;
using System.Collections;

public class SoundEffect : MonoBehaviour {
	public AudioClip treasureClip;
	public AudioClip noticeClip;
	public AudioClip supriseClip;

	public void PlayTreasureClip () {
		audio.clip = treasureClip;
		audio.Play ();
	}

	public void PlayNoticeClip () {
		audio.clip = noticeClip;
		audio.Play ();
	}

	public void PlaySupriseClip () {
		audio.clip = supriseClip;
		audio.Play ();
	}
}
