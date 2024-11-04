using TMPro;
using UnityEngine;

public class Accuarcy : MonoBehaviour
{

    [SerializeField] 
    TMP_Text accuracyText;
    [SerializeField]
    TMP_Text accuracyPanelText;
    [SerializeField]
    GameObject accuracyPanel; // ��Ȯ���� ǥ���� �г�
    private bool isGameActive = false;

    private void Start()
    {
        accuracyText.text = "100%";
        accuracyPanelText.text = "100%";
        accuracyPanel.SetActive(false);

    }

    void OnEnable()
    {
        Timer.OnGameEnded += CalculateAccuracy;
        Timer.OnGameEnded += ShowAccuracyPanelText;
    }

    void OnDisable()
    {
        Timer.OnGameEnded -= CalculateAccuracy;
        Timer.OnGameEnded -= ShowAccuracyPanelText;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isGameActive = true;
        }
    }
    public void ShowAccuracyPanelText()
    {
        if (!isGameActive)
            return;
        CalculateAccuracy(); // ��Ȯ�� ���
        accuracyPanel.SetActive(true); // �г� Ȱ��ȭ
    }

    public void CalculateAccuracy()
    {
        if (!isGameActive)
            return;
        float accuracy = (float)ScoreCounter.Score / (float)(ScoreCounter.Score + MissCounter.Miss);
        accuracy *= 100f;
        accuracyText.text = $"{accuracy.ToString("0")}%";
        accuracyPanelText.text = $"��Ȯ��: {accuracy.ToString("0")}%";
    }
}
