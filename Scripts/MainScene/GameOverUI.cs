using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject CountDownUI;
    public BGMManager BGMManager;
    public Text socreText;


    void Start()
    {
        GameOverPanel.SetActive(false);
        CountDownUI.SetActive(true);
    }

    public void ShowGameOverUI()
    {
        BGMManager.BGMStop();
        GameOverPanel.SetActive(true);
        var score = ScoreManager.score;
        socreText.text = "YOUR SCORE : " + score.ToString();

    }

    public void OnRestartButtonClicked()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickTitleButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("TitleScene");
    }
}
