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
        needleRotation.z = EaseOutBack(playerRotation.y - 10f, playerRotation.y, 100f); 
        needleTransform.eulerAngles = needleRotation;
    }
    public static float EaseOutBack(float start, float end, float value)
    {
        float s = 1.70158f;
        end -= start;
        value = (value) - 1;
        return end * ((value) * value * ((s + 1) * value + s) + 1) + start;
    }
    
    //from https://gist.github.com/cjddmut/d789b9eb78216998e95c
}
