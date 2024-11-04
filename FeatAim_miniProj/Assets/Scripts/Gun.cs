using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	public static Action OnTargetMiss;
    private bool isGameActive = false;

    [SerializeField] Camera cam;

	void Update()
	{
        if (Input.GetKeyDown(KeyCode.F))
        {
            isGameActive = true;
        }

        if (Timer.GameEnded)
			return;

		if(Input.GetMouseButtonDown(0))
		{
			if(!isGameActive)
			{
				return;
			}
			Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
			if(Physics.Raycast(ray, out RaycastHit hit))
			{
				Target target = hit.collider.gameObject.GetComponent<Target>();

				if(target != null)
				{
					target.Hit();
				}
				else
				{
					// OnTargetMiss = null이 아닐때 Invoke()호출 
                    OnTargetMiss?.Invoke();
				}
			}
			else
			{
                OnTargetMiss?.Invoke();
			}
		}
	}
}
