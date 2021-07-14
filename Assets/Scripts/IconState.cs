using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class IconState : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial;

    // bool coroutineAllowed;

    // void Start()
    // {
    //     coroutineAllowed = true;
    // }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F));
        
        if (Physics.Raycast(ray, out hit)) {
            Transform objectHit = hit.transform;

            var selectionRender = objectHit.GetComponent<Renderer>();
            if (selectionRender != null)
            {
                selectionRender.material = highlightMaterial;
            }
            // if (coroutineAllowed)
            // {
            //     StartCoroutine(nameof(Hover));
            // }
        }
    }

    // private IEnumerator Hover()
    // {
        
    // }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision enter");
        Debug.Log(collision);
    }

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("collision stay");
        Debug.Log(collision);
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("collision exit");
        Debug.Log(collision);
    }
}
