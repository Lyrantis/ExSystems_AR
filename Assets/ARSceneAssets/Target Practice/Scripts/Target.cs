using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class Target : MonoBehaviour
{
    int points = 10;

    //ARAnchor tmp;

    private void Awake()
    {
        transform.parent = null;
    }

    //private void Start()
    //{
    //    //tmp = gameObject.AddComponent<ARAnchor>();
    //}

    private void Update()
    {
        //if (tmp && !tmp.pending)
        //{
        //    Debug.Log("ARAnchor tracking for target");
        //}

        transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 1, 0), 1.0f);
    }

    public event Action<GameObject, int> OnDeath;
    public void OnHit()
    {
        OnDeath?.Invoke(gameObject, points);
        Destroy(gameObject);
    }
}
