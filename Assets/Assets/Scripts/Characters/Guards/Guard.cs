using UnityEngine;
using System.Collections;

public class Guard : Character
{
	public float normalCircularSightRange = 1.0f;
	public float greyCircularSightRange = 1.0f;
	public float blackCircularSightRange = 1.0f;
	public float normalConeSightRange = 1.0f;
	public float greyConeSightRange = 1.0f;
	public float blackConeSightRange = 1.0f;
	public float sightAngle = 30.0f;
	public float chasingSpeed = 15.0f;
	public float normalSpeed = 12.0f;
	public float checkingSpeed = 0.0f;
	public float rotateSpeed = 20.0f;

	public bool IsTargetOnSight (Player target)
	{
			return IsTargetOnConeSight (target) || IsTargetOnCircularSight (target);
	}

	private bool IsTargetOnConeSight (Player target)
	{
			// Get vision direction
			Vector3 direction = target.transform.position - transform.position;
	
			// Calculate vision range based on Player's state
			float range = 0.0f;
			switch (target.state) {
			case Player.HiddenState.Exposed:
					range = normalConeSightRange;
					break;
			case Player.HiddenState.Grey:
					range = greyConeSightRange;
					break;
			case Player.HiddenState.Black:
					range = blackConeSightRange;
					break;
			default:
					break;
			}
	
			if (Vector3.Angle (transform.up, direction) <= sightAngle) {
					int obstacleLayer = LayerMask.NameToLayer ("Obstacles");
					int obstacleLayerMask = 1 << obstacleLayer;
		
					RaycastHit2D hit = Physics2D.Raycast (transform.position, direction, range, obstacleLayerMask);
		
					if (hit.collider != null) {
							if (hit.collider.gameObject.GetComponent< Player > () != null) {
									return true;
							}
					}
			}
	
			return false;
	}

	private bool IsTargetOnCircularSight (Player target)
	{
			// Get vision direction
			Vector3 direction = target.transform.position - transform.position;
	
			// Calculate vision range
			float range = 0.0f;
			switch (target.state) {
			case Player.HiddenState.Exposed:
					range = normalCircularSightRange;
					break;
			case Player.HiddenState.Grey:
					range = greyCircularSightRange;
					break;
			case Player.HiddenState.Black:
					range = blackCircularSightRange;
					break;
			default:
					break;
			}

			int obstacleLayer = LayerMask.NameToLayer ("Obstacles");
			int obstacleLayerMask = 1 << obstacleLayer;
	
			RaycastHit2D hit = Physics2D.Raycast (transform.position, direction, range, obstacleLayerMask);
	
			if (hit.collider != null) {
					if (hit.collider.gameObject.GetComponent< Player > () != null) {
							return true;
					}
			}
	
			return false;
	}

	public void NoticeEffect () {
		icon.ShowAlertIcon ();
		effect.PlayNoticeClip ();
	}

	public void SupriseEffect () {
		icon.ShowSupriseIcon ();
		effect.PlaySupriseClip ();
	}
}
