using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour
{
    public static bool IsGameActive { get; private set; } = false; // ���� ���� ����
    [SerializeField] TMP_Text startMessageText; // "F ��ư�� ������ ������ ���۵˴ϴ�" ���� ǥ�ÿ� �ؽ�Ʈ

    void Start()
    {
        startMessageText.text = "F ��ư�� ������ ������ ���۵˴ϴ�";
        startMessageText.gameObject.SetActive(true);
    }

    public void ResetGame()
    {
        IsGameActive = false; // ���� ���� ���� �ʱ�ȭ
        startMessageText.gameObject.SetActive(true); // �ȳ� ���� �ٽ� ���̱�
    }


    void Update()
    {
        if (!IsGameActive && Input.GetKeyDown(KeyCode.F))
        {
            IsGameActive = true;
            startMessageText.gameObject.SetActive(false); // �ȳ� ���� �����
        }
    }
}