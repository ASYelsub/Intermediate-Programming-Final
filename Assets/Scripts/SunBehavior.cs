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

    private Vector3 lightRotation;
    private bool setMorning = false;
    private bool setEvening = false;
    private bool sunMovingFast = false;

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
        
        
        
        //these are the shortcuts to morning or evening
        if (setMorning && !setEvening && sunMovingFast)
        {
            //the sun is moving
            sunMovingFast = true;
            //we are not in the setEvening functionality
            setEvening = false;
            //the range that the sun should end at
            if (Mathf.Abs(lightSource.transform.eulerAngles.x) >= .5f)
            {
                //makes it go backwards... this works because it doesn't mess w/ quaternions
                lightRotation.x -= timeAdd * Time.deltaTime * timeSetMultiplier;
                lightSource.transform.eulerAngles = lightRotation;
            }
            else if (Mathf.Abs(lightSource.transform.eulerAngles.x) <= .5f)
            {
                setMorning = false;
                sunMovingFast = false;
            }
        }

        if (setEvening && !setMorning && sunMovingFast)
        {
            setMorning = false;
            sunMovingFast = true;
            if (Mathf.Abs(lightSource.transform.eulerAngles.x) <= 180.5f)
            {
                lightRotation.x += timeAdd * Time.deltaTime * timeSetMultiplier;
                lightSource.transform.eulerAngles = lightRotation;
            }
            else if (Mathf.Abs(lightSource.transform.eulerAngles.x) >= 180.5f)
            {
                setEvening = false;
                sunMovingFast = false;
            }
        }

        
    }

    public void SetMorning()
    {
        //sets to sun moving, sets it to the setmorning functionality, disables the setevening functionality.
        sunMovingFast = true;
        setMorning = true;
        setEvening = false;
    }

    public void SetEvening()
    {
        //this is similar to above except it flips setmorning & setevening
        sunMovingFast = true;
        setEvening = true;
        setMorning = false;
    }
}
