using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    private int CurrentTargets = 0;
    public int MaxTargets = 5;
    public float TimeBetweenSpawns = 5.0f;
    public int TargetsPerSpawn = 1;
    public GameObject TargetToSpawn;

    public event Action<int> TargetDestroyed;

    IEnumerator SpawnTarget()
    {
        yield return new WaitForSeconds(TimeBetweenSpawns);

        for (int i = 0; i < TargetsPerSpawn; i++)
        {
            if (CurrentTargets < MaxTargets)
            {
                GameObject temp = Instantiate(TargetToSpawn);
                CurrentTargets++;
                temp.GetComponent<Target>().OnDeath += HandleTargetDestroyed;
            }
        }
        
    }
    private void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    private void HandleTargetDestroyed(int points)
    {
        CurrentTargets--;
        TargetDestroyed.Invoke(points);
    }
}
