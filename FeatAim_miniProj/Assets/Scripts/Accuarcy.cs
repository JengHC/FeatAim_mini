using TMPro;
using UnityEngine;

public class Accuarcy : MonoBehaviour
{

    [SerializeField] 
    TMP_Text accuracyText;
    [SerializeField]
    TMP_Text accuracyPanelText;
    [SerializeField]
    GameObject accuracyPanel; // 정확도를 표시할 패널

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

    public void ShowAccuracyPanelText()
    {
        CalculateAccuracy(); // 정확도 계산
        accuracyPanel.SetActive(true); // 패널 활성화
    }

    public void CalculateAccuracy()
    {
        float accuracy = (float)ScoreCounter.Score / (float)(ScoreCounter.Score + MissCounter.Miss);
        accuracy *= 100f;
        accuracyText.text = $"{accuracy.ToString("0")}%";
        accuracyPanelText.text = $"정확도: {accuracy.ToString("0")}%";
    }
}
