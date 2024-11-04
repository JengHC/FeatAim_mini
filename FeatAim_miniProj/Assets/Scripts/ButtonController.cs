using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    GameObject rankingPopup;

    public void startGame()
    {
        SceneManager.LoadScene("basic");
    }

    public void Restart()
	{
        ScoreTotal.ResetScore();
        SceneManager.LoadScene("basic");
	}

    public void OnApplicationQuit()
    {
        SceneManager.LoadScene("Main");
    }

    public void RankingButton()
    {
        rankingPopup.SetActive(true);
    }
}
