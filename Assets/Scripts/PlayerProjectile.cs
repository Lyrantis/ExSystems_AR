using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            //AddPoints
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            Destroy(this);
        }
    }
}
