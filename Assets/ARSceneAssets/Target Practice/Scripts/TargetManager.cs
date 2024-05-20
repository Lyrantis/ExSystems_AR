using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public int MaxTargets = 5;
    public float TimeBetweenSpawns = 5.0f;
    public int TargetsPerSpawn = 1;
    public GameObject TargetToSpawn;
    private List<GameObject> activeTargets;

    public event Action<int> TargetDestroyed;

    private void SpawnTargetWave()
    {
        for (int i = 0; i < TargetsPerSpawn; i++)
        {
            if (activeTargets.Count < MaxTargets)
            {
                GameObject temp = Instantiate(TargetToSpawn);
                Vector3 randomDirectionToSpawn = new Vector3(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-0.5f, 1.0f));
                float randomDistance = UnityEngine.Random.Range(0.0f, 1.0f);
                Vector3 facingDIrection = -randomDirectionToSpawn.normalized;
                randomDirectionToSpawn = randomDirectionToSpawn.normalized * randomDistance;
                temp.transform.position = randomDirectionToSpawn;
                temp.transform.LookAt(new Vector3(0, 0, 0));
                temp.GetComponent<Target>().OnDeath += HandleTargetDestroyed;
                activeTargets.Add(temp);
            }
        }
    }
    public void StartGame()
    {
        SpawnTargetWave();
    }

    public void EndGame()
    {
        StopAllCoroutines();

        foreach (GameObject target in activeTargets)
        {
            target.GetComponent<Target>().OnDeath -= HandleTargetDestroyed;
            Destroy(target);
        }
    }

    private void HandleTargetDestroyed(GameObject targetDestroyed, int points)
    {
        activeTargets.Remove(targetDestroyed);

        if (activeTargets.Count == 0)
        {
            SpawnTargetWave();
        }
        TargetDestroyed.Invoke(points);
    }
}
