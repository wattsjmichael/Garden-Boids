using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LarvaeMovement : MonoBehaviour
{
   public Transform question; 

     public AnimationCurve DistanceVersusSpeed;
 
     private float _initialDistanceToTarget;
     private float _speed;
     private float _distanceToTarget;
     public Vector3 axis;
     public float angle; 
 
     public void Start()
     {
         _initialDistanceToTarget = (question.position - transform.position).magnitude;
         _speed = 0;
     }
 
     public void Update()
     {
         // Calculate our distance from target
         Vector3 deltaPosition = question.position - transform.position;
         _distanceToTarget = deltaPosition.magnitude;
 
         // Update our speed based on our distance from the target
         _speed = DistanceVersusSpeed.Evaluate((_initialDistanceToTarget - _distanceToTarget) / _initialDistanceToTarget);
 
         // If we need to move father than we can in this update, then limit how much we move
         if (_distanceToTarget > _speed && _distanceToTarget <= 1.0f)
             deltaPosition = deltaPosition.normalized * _speed;
 
         // Set our position
         transform.position += deltaPosition * _speed * Time.deltaTime;

         if (_distanceToTarget <= 1.0f &&  _distanceToTarget >= .2f)
         {
             transform.RotateAround(question.transform.position, axis, angle);
         }
         
     }
 }