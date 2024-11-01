using TMPro;
using UnityEngine;

public class Accuarcy : MonoBehaviour
{

    [SerializeField] 
    TMP_Text accuracyText;

    private void Start()
    {
        accuracyText.text = "100%";
    }

    void OnEnable()
    {
        Timer.OnGameEnded += CalculateAccuracy;
    }

    void OnDisable()
    {
        Timer.OnGameEnded -= CalculateAccuracy;
    }

    public void CalculateAccuracy()
    {
        // �� ������ �̽��� ������ �˱� ���� ���� 
        //float totalScore = (float)ScoreCounter.Score;
        //float totalMiss = (float)MissCounter.Miss;

        //// ��Ȯ�� = (�� ���� / (�� ���� + �̽�)) * 100
        //// �̽��� ���� ���� 100���� ����
        //float accuracy;
        //if(totalScore + totalMiss > 0)
        //{
        //    accuracy = (totalScore / (totalScore + totalMiss)) * 100f;
        //}
        //else
        //{
        //    accuracy = 100f;
        //}

        float accuracy = (float)ScoreCounter.Score / (float)(ScoreCounter.Score + MissCounter.Miss);
        accuracy *= 100f;
        accuracyText.text = $"{accuracy.ToString("0")}%";
    }
}
