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
        // 총 점수와 미스의 정보를 알기 위해 설정 
        //float totalScore = (float)ScoreCounter.Score;
        //float totalMiss = (float)MissCounter.Miss;

        //// 정확도 = (총 점수 / (총 점수 + 미스)) * 100
        //// 미스가 없을 때는 100으로 설정
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
