using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
public class PlacementController : MonoBehaviour
{
    public GameObject question1;

    private ARRaycastManager arRaycastManager;

    void Awake() 
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        // debugText.text = "forward: " + Camera.main.transform.forward.ToString() + " rotation: " + Camera.main.transform.rotation.ToString();

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                if (arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
                {
                    var hitPose = hits[0].pose;
                    hitPose.rotation.y = Camera.main.transform.rotation.y;
                    Instantiate(question1, hitPose.position, hitPose.rotation);
                }
            }
        }
    }

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
}