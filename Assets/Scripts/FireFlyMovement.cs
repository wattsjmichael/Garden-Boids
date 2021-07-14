using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyMovement : MonoBehaviour
{

   
   
    public float speed = 1.0f;
  
    public Transform question; 


    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
   
        float step = speed * Time.deltaTime;
        transform.position = Vector3.Slerp(transform.position, question.position, step);
        // transform.position = new Vector3(Mathf.PingPong(Time.time * speed, 2)-1, question.position.y, question.position.z);

    }
}
