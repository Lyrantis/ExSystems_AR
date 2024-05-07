using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    int score;

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
}

