using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private int score;
    public TMP_Text scoreText;
    public TMP_Text gameOverScoreText;

    private void Start()
    {
        if (scoreText == null)
        {
            Debug.Log("Error: Score System has no score text set");
        }
        scoreText.gameObject.SetActive(true);
    }
    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        UpdateUI();
    }

    public void RemoveScore(int pointsToRemove)
    {
        score -= pointsToRemove;
        UpdateUI();
    }

    public void SetScore(int newScore)
    {
        score = newScore;
        UpdateUI();
    }

    public void ResetScore()
    {
        score = 0;
        UpdateUI();
    }

    public int GetScore()
    {
        return score;
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void StartGame()
    {
        scoreText.gameObject.SetActive(true);
    }
    public void EndGame()
    {
        scoreText.gameObject.SetActive(false);
        gameOverScoreText.text = "Score: " + score.ToString();
    }
}

