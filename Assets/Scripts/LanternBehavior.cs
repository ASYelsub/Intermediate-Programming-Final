using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternBehavior : MonoBehaviour
{
    [SerializeField] 
    private Transform lanternTransform;
    [SerializeField] 
    private GameObject lightSource;
    private bool isPutAway = false; //if false, the lantern is out
    private bool beingPutAway = false; //if false, the lantern's position is stagnant

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchLightState()
    {


    }
}
