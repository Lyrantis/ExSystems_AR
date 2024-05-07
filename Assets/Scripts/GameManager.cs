using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    TargetSpawner targetSpawner;
    ScoreSystem scoreSystem;

    void Start()
    {
        scoreSystem = gameObject.GetComponent<ScoreSystem>();
        
        if (scoreSystem == null)
        {
            Debug.Log("Error: Game Manager has no Score System");
        }

        targetSpawner = gameObject.GetComponent<TargetSpawner>();

        if (targetSpawner == null)
        {
            Debug.Log("Error: Game Manager has no target spawner");
        }
        else
        {
            targetSpawner.TargetDestroyed += OnTargetDestroyed;
        }
    }

    void OnTargetDestroyed(int points)
    {
        scoreSystem.AddScore(points);
    }
}
