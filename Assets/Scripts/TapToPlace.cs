using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToPlace : MonoBehaviour
{
    public GameObject placementIndicatorPrefab;
    public GameObject objectToPlacePrefab;

    private ARRaycastManager arRaycastManager;
    private GameObject placementIndicator;
    private GameObject placedObject;
    private bool placementPoseValid = false;
    private Pose placementPose;
    private Camera currentCamera;

    void Start()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
        currentCamera = FindObjectOfType<Camera>();
        placementIndicator = Instantiate(placementIndicatorPrefab);
    }

    public void ChangePrefab(GameObject prefab)
    {
        objectToPlacePrefab = prefab;

        // If a tree has already been placed, change to a new tree
        if (placedObject != null)
        {
            Vector3 position = placedObject.transform.position;
            Quaternion rotation = placedObject.transform.rotation;
            Vector3 scale = placedObject.transform.localScale;
            Destroy(placedObject);
            placedObject = Instantiate(objectToPlacePrefab, position, rotation);
            placedObject.transform.localScale = scale;
        }
    }

    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();

        if (placedObject == null && placementPoseValid && Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            print("Placing AR object...");
            ARPlaceObject(objectToPlacePrefab);  // at the moment this just spawns the gameobject
        }
    }

    public void ARPlaceObject(GameObject prefab)
    {   
        if (placedObject != null) {
            GameObject prevObject = placedObject;
            placedObject = Instantiate(prefab, prevObject.transform.position,
                prevObject.transform.rotation);
        }

        else {
            placedObject = Instantiate(prefab, placementPose.position, placementPose.rotation);
        }

        print("Placed new object: " + placedObject.name);

        // Destroy(placementIndicator);
        // enabled = false;
    }

    void UpdatePlacementPose()
    {
        var screenCenter = currentCamera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseValid = hits.Count > 0;
        if (placementPoseValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = currentCamera.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z);
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }

    void UpdatePlacementIndicator()
    {
        if(placedObject == null && placementPoseValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }
}
