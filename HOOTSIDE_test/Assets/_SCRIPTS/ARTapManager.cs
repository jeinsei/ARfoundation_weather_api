using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

// script permettant de gérer les éléments 3D en AR
[RequireComponent(typeof(ARRaycastManager))]
public class ARTapManager  : MonoBehaviour
{
    #region VARIABLES

    [Header("PARAMETRES PLACEMENT OBJETS")]

    public GameObject placementIndicator; 

    public GameObject lastInstantiate; 
   
    private Pose placementPose;

    public GameObject indicatorAwake;

    private ARRaycastManager _arRaycastManager;

    private bool placementPoseIsValide; 

    private Vector3 _ScreenCenter; 

    private List<ARRaycastHit> _Hits = new List<ARRaycastHit>(); 

    private List<GameObject> itemList = new List<GameObject>(); 

    #endregion VARIABLES


    #region CLASSIC METHOD

    private void Awake()
    {
        indicatorAwake = GameObject.FindGameObjectWithTag("indicator"); 
        lastInstantiate = indicatorAwake;

    }


    void Start()
    {

        _arRaycastManager = GetComponent<ARRaycastManager>(); 


    }

    void Update()
    {
      
        UpdatePlacementPose(); // mise a jour des possibilités de placement dans la scene

        UpdatePlacementIndicator(); // mise a jour du GameObject indicator dans la scene


        Debug.Log("Update");

    }

    #endregion CLASSIC METHOD

    #region SPECIFIC METHOD

    // methode pour upadte le placement de l'indicateur de pose des éléments 3D en réalité augmentée
    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValide)
        {
         
            placementIndicator.SetActive(true);

            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);

        }
        else
        {
            Debug.Log("2 UpdatePlacementIndicator");

             placementIndicator.SetActive(false);
           


        }
    }

    // methode pour update le placement de l'indicateur par rapport au placement de la camera
    private void UpdatePlacementPose()
    {

        Debug.Log("1 UpdatePlacementPose");
      
        _ScreenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
     
  
        _arRaycastManager.Raycast(_ScreenCenter, _Hits, TrackableType.Planes);
       

        placementPoseIsValide = _Hits.Count > 0;

        if (placementPoseIsValide)
        {

            placementPose = _Hits[0].pose;

            var _cameraForward = Camera.current.transform.forward;
           
            var _cameraBearing = new Vector3(_cameraForward.x, 0, _cameraForward.z).normalized;

            placementPose.rotation = Quaternion.LookRotation(_cameraBearing);

        }

       
    }

    // methode d'instantiation pour placer l'objet par rapport au "POSE" fournit par ARKIT (methode appelée via BUTTON)
    public void PlaceObject()
    {

        var _cameraForward = Camera.current.transform.forward;

        var _cameraBearing = new Vector3(_cameraForward.x, 0, _cameraForward.z).normalized;

        GameObject _instantiateIndicator = Instantiate(placementIndicator, placementPose.position, placementPose.rotation) as GameObject;

        itemList.Add(_instantiateIndicator);

        lastInstantiate = itemList[itemList.LastIndexOf(_instantiateIndicator)];

    }

    #endregion SPECIFIC METHOD
}
