using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxPlayerController : MonoBehaviour
{
    private float mouseX;
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
        mouseX = Input.mousePosition.x;
        playerRotation = new Vector3(0f, mouseX, 0f);
        playerTransform.eulerAngles = playerRotation;
        //Debug.Log(mouseX);
    }
}
