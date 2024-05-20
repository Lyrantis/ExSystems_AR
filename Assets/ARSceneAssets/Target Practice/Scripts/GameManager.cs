using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private ScoreSystem scoreSystem;
    private TargetSpawner spawner;
    public int GameStartCountdown;
    public int GameDuration;
    public TMP_Text countdownText;
    public TMP_Text timerText;
    public GameObject CountdownPanel;
    public GameObject GameOverPanel;

    IEnumerator GameCountdown()
    {
        for (int i = 0; i < GameStartCountdown + 1; i++)
        {
            countdownText.text = (GameStartCountdown - i).ToString();
            yield return new WaitForSeconds(1.0f);
        }

        CountdownPanel.SetActive(false);
        timerText.gameObject.SetActive(true);

        spawner.StartGame();
        scoreSystem.StartGame();
        StartCoroutine(GameTimer());
        
    }

    IEnumerator GameTimer()
    {
        for (int i = 0; i < GameDuration; i++)
        {
            timerText.text = (GameDuration - i).ToString();
            yield return new WaitForSeconds(1.0f);
        }

        EndGame();
    }

    void Awake()
    {
        scoreSystem = gameObject.GetComponent<ScoreSystem>();

        if (scoreSystem == null)
        {
            Debug.Log("Error: No Score System attached");
        }

        spawner = gameObject.GetComponent<TargetSpawner>();

        if (spawner == null) 
        {
            Debug.Log("Error: No Target Spawner Attached");
        }

        GameOverPanel.SetActive(false);
        timerText.gameObject.SetActive(false);
        spawner.TargetDestroyed += AddPoints;

        StartCoroutine(GameCountdown());
    }

    void AddPoints(int points)
    {
        scoreSystem.AddScore(points);
    }

    private void EndGame()
    {
        timerText.gameObject.SetActive(false);
        spawner.EndGame();
        scoreSystem.EndGame();

        GameOverPanel.SetActive(true);
        
    }
}
