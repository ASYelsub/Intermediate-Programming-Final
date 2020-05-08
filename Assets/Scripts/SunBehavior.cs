using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SunBehavior : MonoBehaviour
{
    [Header("Tuning Variables")]
    public float timeAdd;
    public bool devMode;
    public float timeSetMultiplier; //this is how quickly it moves when either set to morning or evening
    //devMode pretty much means: is the sun paused?

    [SerializeField]
    private GameObject lightSource;

    public Vector3 lightRotation;
    private float targetTime;
    private bool switchTime;

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

        if (lightRotation.x >= 360) {
            lightRotation.x = 0;
        }

        timeAdd = (switchTime) ? 50 : 1;
        
        if (switchTime) {
            if (lightRotation.x < targetTime + 10 && lightRotation.x > targetTime - 10) {
                switchTime = false;
            }
        }

    }

    public void SetMorning()
    {
        //sets to sun moving, sets it to the setmorning functionality, disables the setevening functionality.
        switchTime = true;
        targetTime = 5;
    }

    public void SetEvening()
    {
        //this is similar to above except it flips setmorning & setevening
        switchTime = true;
        targetTime = 190;
    }
}
