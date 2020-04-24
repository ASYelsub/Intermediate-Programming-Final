using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxPlayerController : MonoBehaviour
{
    private float mouseX;
    private float mouseY;
    private Transform playerTransform;

    private Vector3 playerRotation;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        playerRotation = playerTransform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        mouseY = Input.mousePosition.y;
        mouseX = Input.mousePosition.x;
        playerRotation = new Vector3(-.05f * mouseY, .05f * mouseX, 0f);
        playerTransform.eulerAngles = playerRotation;
        //Debug.Log(mouseX);
    }
    
    
    
   
}
