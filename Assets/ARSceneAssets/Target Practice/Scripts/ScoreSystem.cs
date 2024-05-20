using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private int score;
    public GameObject scoreText;

    private void Start()
    {
        if (scoreText == null)
        {
            Debug.Log("Error: Score System has no score text set");
        }
        scoreText.SetActive(true);
    }
    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
    }

    public void RemoveScore(int pointsToRemove)
    {
        score -= pointsToRemove;
    }

    public void SetScore(int newScore)
    {
        score = newScore;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public int GetScore()
    {
        return score;
    }

    private void UpdateUI()
    {
        scoreText.GetComponent<TextMeshPro>().text = "Score: " + score.ToString();
    }

    public void StartGame()
    {
        scoreText.SetActive(true);
    }
    public void EndGame()
    {
        scoreText.gameObject.SetActive(false);
    }
}

