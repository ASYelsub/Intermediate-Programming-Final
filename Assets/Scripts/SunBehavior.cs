using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SunBehavior : MonoBehaviour
{
    [Header("Tuning Variables")]
    public float timeAdd;
    public bool devMode;
    //devMode pretty much means: is the sun paused?

    [SerializeField]
    private GameObject lightSource;

    private Vector3 lightRotation;
    
    void Start()
    {//sets the light so i can see if it's in devmode, sets to sunrise starting point if it's in not devmode
        lightRotation = devMode ? new Vector3(90, -90, 0) : new Vector3(0,-90,0);
        lightSource.transform.eulerAngles = lightRotation;
    }

    // Update is called once per frame
    void Update()
    {    //if in devmode, it doesn't change position. if not, it does.
        if (!devMode)
        {
            lightRotation.x += timeAdd * Time.deltaTime;
            lightSource.transform.eulerAngles = lightRotation;
        }
    }
}
