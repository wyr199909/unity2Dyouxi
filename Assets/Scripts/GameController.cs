using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int totalScore;
    public Text scoreText;

    public GameObject gameOverPanel;


    public static GameController Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void UPdateTotalScore()
    {
        this.scoreText.text = totalScore.ToString();
    }
    
    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void RestartLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
