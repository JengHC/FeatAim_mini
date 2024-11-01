using TMPro;
using UnityEngine;

public class RankingPopup : MonoBehaviour
{
    public TMP_Text RankLabel;

    private void OnEnable()
    {
        string[] scores = PlayerPrefs.GetString("HighScores", "").Split(",");
        string result = "";

        for (int i = 0; i < scores.Length; i++)
        {
            result += (i + 1) + ". " + scores[i] + "\n";
        }
        RankLabel.text = result;
    }

    public void ClosePressed()
    {
        gameObject.SetActive(false);
    }
}
