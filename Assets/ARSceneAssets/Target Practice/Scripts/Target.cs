using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    int points = 10;

    public event Action<GameObject, int> OnDeath;
    private void OnDestroy()
    {
        OnDeath.Invoke(this.gameObject, points);
    }
}
