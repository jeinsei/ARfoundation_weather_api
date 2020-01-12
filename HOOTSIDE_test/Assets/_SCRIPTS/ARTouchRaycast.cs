using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script permettant de détruire les objets AR présent dans la scène
public class ARTouchRaycast : MonoBehaviour
{
    Ray _ray;
    RaycastHit _raycasthit;

    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            _ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            Debug.DrawRay(_ray.origin, _ray.direction * 200, Color.red);

            if(Physics.Raycast(_ray, out _raycasthit, Mathf.Infinity))
            {
                Destroy(_raycasthit.transform.gameObject);
            }


        }
    }
}
