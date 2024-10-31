using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissCounter : MonoBehaviour
{
	[SerializeField] TMP_Text text;
	public static int Miss
	{
		get;
		private set;
	}

    private void OnEnable()
    {
		Gun.OnTargetMiss += OnTargetMiss;
    }
    private void OnDisable()
    {
        Gun.OnTargetMiss -= OnTargetMiss;
    }

    void OnTargetMiss()
    {
        Miss++;
        text.text = $"Miss:{Miss}";
    }
}
