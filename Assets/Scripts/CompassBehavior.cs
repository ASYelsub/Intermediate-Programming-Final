using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This script goes on the Compass object, which is found through Canvas>Active Element Image>Compass
//It controls how the "needle," aka CompassNeedleImage which is a child object, it is dependent
//on the direction the player is facing.
public class CompassBehavior : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 playerRotation;
    [SerializeField]
    private Transform needleTransform;
    private Vector3 needleRotation;
    void Start()
    {
        playerRotation = playerTransform.eulerAngles;
        needleRotation = needleTransform.eulerAngles;
    }

    void Update()
    {
        playerRotation = playerTransform.eulerAngles;
        needleRotation.z = playerRotation.y; 
        needleTransform.eulerAngles = needleRotation;
    }
}
