﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
	public static Action OnGameEnded;	// 게임 종료시 발생하는 이벤트를 델리게이트로 정의
	public static bool GameEnded 
	{ 
		get; 
		private set; 
	}   // 게임이 종료 되었는지 확인하는 프로퍼티, 내부에서만 값 설정

    private bool isGameActive = false;

    [SerializeField] TMP_Text timerText;

	float endTime;

	const float gameTime = 30.0f;

	void Start()
	{
		GameEnded = false;
		endTime = Time.time + gameTime;
	}

	void Update()
	{
        if (!isGameActive)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                isGameActive = true;
                endTime = Time.time + gameTime; // Reset endTime when starting the game
            }
            return;
        }

        if (GameEnded)
			return;

		float timeLeft = endTime - Time.time;

		if(timeLeft <= 0)
        {
            // OnGameEnded = null이 아닐때 Invoke()호출 
            GameEnded = true;
			OnGameEnded?.Invoke();

			timeLeft = 0;
		}

		timerText.text = $"{timeLeft.ToString("0.00")}";
	}
	
}
