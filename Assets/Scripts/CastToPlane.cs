using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;

public class CastToPlane : MonoBehaviour
{
    [SerializeField]
    GameObject prefabToCreate;
    ARRaycastManager xRRayCastManager;
    // Start is called before the first frame update
    void Start()
    {
        xRRayCastManager = GetComponent<ARRaycastManager>();
    }

    public void OnTap(InputAction.CallbackContext e)
    {
        Vector2 screenPos = e.ReadValue<Vector2>();

        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        xRRayCastManager.Raycast(Camera.main.ScreenPointToRay(screenPos), hits, UnityEngine.XR.ARSubsystems.TrackableType.AllTypes);

        if (hits.Count > 0 )
        {
            Instantiate(prefabToCreate, hits.First().pose.position, Quaternion.identity);
        }
    }
}
