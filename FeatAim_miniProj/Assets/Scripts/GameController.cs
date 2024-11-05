using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour
{
    public static bool IsGameActive { get; private set; } = false; // 게임 시작 여부
    [SerializeField] TMP_Text startMessageText; // "F 버튼을 누르면 게임이 시작됩니다" 문구 표시용 텍스트

    void Start()
    {
        startMessageText.text = "F 버튼을 누르면 게임이 시작됩니다";
        startMessageText.gameObject.SetActive(true);
    }

    public void ResetGame()
    {
        IsGameActive = false; // 게임 시작 여부 초기화
        startMessageText.gameObject.SetActive(true); // 안내 문구 다시 보이기
    }


    void Update()
    {
        if (!IsGameActive && Input.GetKeyDown(KeyCode.F))
        {
            IsGameActive = true;
            startMessageText.gameObject.SetActive(false); // 안내 문구 숨기기
        }
    }
}