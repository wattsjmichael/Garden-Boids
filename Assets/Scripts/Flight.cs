using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flight : MonoBehaviour
{

   public FlightManager myManager;
   float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(myManager.minSpeed,myManager.maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Time.deltaTime * speed, Time.deltaTime * speed, 0f);
       ApplyRules(); 
    }
    void ApplyRules()
    {
        GameObject[] gof;
        gof = myManager.allFly;

        Vector3 vcenter = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float globalSpeed = 0.01f;
        float nDistance;
        int groupSize = 0;

        foreach (GameObject go in gof)
        {
            if( go!= this.gameObject)
            {
                nDistance = Vector3.Distance(go.transform.position, this.transform.position);
                if(nDistance <= myManager.neighborDistance)
                {
                    vcenter += go.transform.position;
                    groupSize ++;
                    if (nDistance <1.0f)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);
                    }
                    Flight anotherFlight = go.GetComponent<Flight>();
                    globalSpeed = globalSpeed + anotherFlight.speed;
                }
            }
        }
        if (groupSize > 0 )
        {
            vcenter = vcenter/groupSize;
            speed= globalSpeed/groupSize;
            Vector3 direction = (vcenter + vavoid) - transform.position;
            if(direction != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), myManager.rotationSpeed * Time.deltaTime);
        }
    }
}
