using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    [SerializeField]
    GameObject _projectilePrefab;

    [SerializeField]
    float shotDelay = 0.1f;

    private bool canFire = true;

    IEnumerator FireDelay()
    {
        yield return new WaitForSeconds(shotDelay);

        canFire = true;
    }

    public void Fire(InputAction.CallbackContext touch)
    {
        if (canFire)
        {
            Ray dir = Camera.main.ScreenPointToRay(touch.ReadValue<Vector2>());

            GameObject temp = Instantiate(_projectilePrefab, Camera.main.transform.position, Quaternion.identity);
            temp.GetComponent<Rigidbody>().AddForce(dir.direction * 10.0f, ForceMode.Impulse);

            canFire = false;
            StartCoroutine(FireDelay());
        }
    }
}
