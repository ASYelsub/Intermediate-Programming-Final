using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script goes on the Compass object, which is found through Canvas>Active Element Image>Compass
//It controls how the "needle," aka CompassNeedleImage which is a child object, it is dependent
//on the direction the player is facing.
public class CompassBehavior : MonoBehaviour
{
    public Transform playerTransform;
    [SerializeField]
    private float playerRotation;
    [SerializeField]
    private Transform needleTransform;
    [SerializeField]
    private float needleRotation;
    [SerializeField]
    private float angularVelocity;
    [SerializeField] 
    private float torque;
    [Header("Tuning Variables")]
    [SerializeField]
    private float torqueScalar;
    [SerializeField]
    private float dampingCoefficient;
   
    

    void Update()
    {
        /*playerRotation = playerTransform.eulerAngles.y;
        //needle is rotating relative to compass instead of worldspace
        needleRotation = needleTransform.eulerAngles.z;
        needleRotation = playerRotation;*/
        /*  //problems that these if statements fix: 360 is greater than 0, so when moving to the left, if the rotation of the needle is decreasing, it cannot decrease from 0 to 360.
          
          if (needleRotation >= 0 && needleRotation <= 180 && 
              playerRotation <= 180 && playerRotation >= 340) //right of 0 to left of 0
          {
              playerRotation = playerRotation - 360;
          }
          else if (needleRotation <= 360 && needleRotation >= 180 &&
                   playerRotation >= 0 && playerRotation <= 180) //left of 0 to right of 0
          {
              playerRotation = playerRotation + 360;
          }
          torque = (playerRotation - needleRotation) * torqueScalar; //The bigger the delta between playerRotation and needleRotation angles, the faster the change should be happening.
          //torque is increasing the angularVelocity continuously in either direction depending on the difference between playerRotation & needleRotation.
          angularVelocity += torque * Time.deltaTime;
          //makes it so it doesnt change like crazy
          angularVelocity *= dampingCoefficient;
          //grabbing current EulerAngles
          Vector3 needleEulerAngles = needleTransform.rotation.eulerAngles;
          //modifying EulerAngles
          needleEulerAngles.z += angularVelocity * Time.deltaTime;
          //applying EulerAngles
          needleTransform.rotation = Quaternion.Euler(needleEulerAngles);*/

    }
   
}
