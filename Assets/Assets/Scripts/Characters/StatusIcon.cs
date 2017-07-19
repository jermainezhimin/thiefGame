using UnityEngine;
using System.Collections;

public class StatusIcon : MonoBehaviour {
	public float offset = 0.1f;

	public Sprite visibleSprite;
	public Sprite invisibleSprite;
	public Sprite alertSprite;
	public Sprite supriseSprite;

	public float iconShowDuration = 1.0f;
	private float iconShowTimer;

	protected void Start () {
		renderer.enabled = false;
	}

	protected void Update () {
		transform.up = Vector3.up;
		transform.position = transform.parent.position + Vector3.up * offset;

		if (iconShowTimer > 0.0f) {
			iconShowTimer -= Time.deltaTime;
			if (iconShowTimer < 0.0f) {
				renderer.enabled = false;
			}
		}
	}

	public void ShowVisibleState () {
		((SpriteRenderer)renderer).sprite = visibleSprite;
		renderer.enabled = true;
		iconShowTimer = iconShowDuration;
	}

	public void ShowInvisibleState () {
		((SpriteRenderer)renderer).sprite = invisibleSprite;
		renderer.enabled = true;
		iconShowTimer = iconShowDuration;
	}

	public void ShowAlertIcon () {
		((SpriteRenderer)renderer).sprite = alertSprite;
		renderer.enabled = true;
		iconShowTimer = iconShowDuration;
	}

	public void ShowSupriseIcon () {
		((SpriteRenderer)renderer).sprite = supriseSprite;
		renderer.enabled = true;
		iconShowTimer = iconShowDuration;
	}
}
