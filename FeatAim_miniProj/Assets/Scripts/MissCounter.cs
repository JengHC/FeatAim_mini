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

    private Accuarcy accuarcyScript;

    private void OnEnable()
    {
		Gun.OnTargetMiss += OnTargetMiss;
        accuarcyScript = FindObjectOfType<Accuarcy>(); // Accuarcy 스크립트 찾기

        Miss = 0; // 미스 카운트 초기화
        text.text = $"Miss: {Miss}회"; // 초기 텍스트 설정
    }
    private void OnDisable()
    {
        Gun.OnTargetMiss -= OnTargetMiss;        
    }

    void OnTargetMiss()
    {
        Miss++;
        accuarcyScript.CalculateAccuracy(); // 정확도 메서드 호출
        text.text = $"Miss: {Miss}회";
    }
}
