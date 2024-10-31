﻿using System.Collections;
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
		Timer.OnGameEnded += OnGameEnded;
		lastHitTime = Time.time;
	}

	void OnDisable()
	{
		Target.OnTargetHit -= OnTargetHit;
        Timer.OnGameEnded -= OnGameEnded;
    }

	void OnTargetHit()
	{
		// 공을 맞춘 현재 시간과 마지막 공을 맞춘 시간의 차이 계산
		float timeSinceLastHit = Time.time - lastHitTime;

		// 기본 점수 및 추가 점수 계산
		int baseScore = 1000;
		float multiple = 1.0f;	//그냥 곱하고 하면 보기 싫으니까, 가독성 좋게 Mathf사용하기 위함

		// timeSinceLasthit이 1초 이하이면 multiple이 2배가 됨
		if(timeSinceLastHit <=1.0f)
		{
			multiple = 2.0f;
		}
		else if(timeSinceLastHit<=3.0f)
		{
			multiple = 1.5f;
		}
		else if(timeSinceLastHit<=5.0f)
		{
			multiple = 1.2f;
		}

		//점수 추가
		Score += Mathf.RoundToInt(baseScore * multiple);
		text.text = $"{Score}";

		// 다음 공을 맞췄을때 걸린 시간을 새로 계산 하도록, 현재 시간으로 다시 설정
		lastHitTime = Time.time;

		//Score++;
		//text.text = $"{Score}";
	}

	void OnGameEnded()
	{
		Score = 0;
        text.text = $"{Score}";
    }
}
