using TMPro;
using UnityEngine;

public class Accuarcy : MonoBehaviour
{
    [SerializeField] TMP_Text accuracyText;

    void OnEnable()
    {
        Timer.OnGameEnded += CalculateAccuracy;
    }

    void OnDisable()
    {
        Timer.OnGameEnded -= CalculateAccuracy;
    }

    void CalculateAccuracy()
    {
        float accuracy = (float)ScoreCounter.Score / (float)(ScoreCounter.Score + MissCounter.Misses);
        accuracy *= 100f;
        accuracyText.text = $"��Ȯ��: {accuracy.ToString("0")}%";
    }
}
