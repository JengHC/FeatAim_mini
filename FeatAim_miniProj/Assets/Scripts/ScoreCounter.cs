using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
	[SerializeField] TMP_Text text;
	public static int Score 
	{ 
		get;
		private set; 
	}

	public float lastHitTime;

	void OnEnable()
	{		
		Target.OnTargetHit += OnTargetHit;
		//Timer.OnGameEnded += OnGameEnded;
		lastHitTime = Time.time;
	}

	void OnDisable()
	{
		Target.OnTargetHit -= OnTargetHit;
        //Timer.OnGameEnded -= OnGameEnded;
    }

	void OnTargetHit()
	{
		// 다음 공을 맞췄을때 걸린 시간을 새로 계산 하도록, 현재 시간으로 다시 설정
		lastHitTime = Time.time;

		Score++;
		text.text = $"{Score}";
	}

	//void OnGameEnded()
	//{
	//	Score = 0;
	//	text.text = $"{Score}";
	//}
}
