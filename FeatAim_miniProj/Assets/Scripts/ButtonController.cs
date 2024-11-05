using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField]
    GameObject rankingPopup;

    [SerializeField]
    GameStarter gameStarter;

    public void startGame()
    {
        SceneManager.LoadScene("basic");
    }

    public void Restart()
	{
        ScoreTotal.ResetScore();
        gameStarter.ResetGame(); // GameStarter 초기화
        SceneManager.LoadScene("basic");
	}

    public void OnApplicationQuit()
    {
        gameStarter.ResetGame();
        SceneManager.LoadScene("Main");
    }

    public void RankingButton()
    {
        rankingPopup.SetActive(true);
    }
}
