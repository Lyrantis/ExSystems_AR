using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    [SerializeField]
    GameObject _projectilePrefab;

    public void Fire(InputAction.CallbackContext touch)
    {
        Ray dir = Camera.main.ScreenPointToRay(touch.ReadValue<Vector2>());

        GameObject temp = Instantiate(_projectilePrefab, Camera.main.transform.position, Quaternion.identity);
        temp.GetComponent<Rigidbody>().AddForce(dir.direction * 10.0f, ForceMode.Impulse);
    }
}
