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
    public GameObject countdownText;
    public GameObject timerText;
    public GameObject CountdownPanel;
    public GameObject GameOverPanel;

    IEnumerator GameCountdown()
    {
        for (int i = 0; i < GameStartCountdown; i++)
        {
            yield return new WaitForSeconds(1.0f);
            countdownText.GetComponent<TextMeshPro>().text = (GameStartCountdown - i).ToString();
        }
        CountdownPanel.SetActive(false);

        spawner.StartGame();
        scoreSystem.StartGame();
        StartCoroutine(GameTimer());
        
    }

    IEnumerator GameTimer()
    {
        for (int i = 0; i < GameDuration; i++)
        {
            yield return new WaitForSeconds(1.0f);
            timerText.GetComponent<TextMeshPro>().text = (GameDuration - i).ToString();
        }

        EndGame();
    }

    // Start is called before the first frame update
    void Start()
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
        timerText.SetActive(false);
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
