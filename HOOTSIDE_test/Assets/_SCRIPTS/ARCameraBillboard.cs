using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// script permettant d'avoir un effet Billboard sur les éléments en AR
public class ARCameraBillboard : MonoBehaviour
{
   
    public GameObject m_Camera;



    private void Start()
    {
        m_Camera = Camera.main.gameObject;
    }

    private void Update()
    {
        if (m_Camera == null)
            m_Camera = GameObject.FindGameObjectWithTag("camera");
    }
    //Orient the camera after all movement is completed this frame to avoid jittering
    void LateUpdate()
    {

        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
    }

}