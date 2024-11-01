using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	public static Action OnTargetHit;

	void Start()
	{
		RandomizePosition();
	}

	public void Hit()
	{
		RandomizePosition();
		OnTargetHit?.Invoke();	// OnTargetHit = null 이 아닐때, Invoke()호출
	}

	void RandomizePosition()
	{
		transform.position = TargetBoundary.Instance.GetRandomPosition();
	}
}
