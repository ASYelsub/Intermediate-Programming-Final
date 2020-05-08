using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedRunePrefab : MonoBehaviour
{
    public GameObject RuneHolder;
    public Sprite Rune;
    public float yRot;

    void Start()
    {
        RuneHolder.GetComponent<SpriteRenderer>().sprite = Rune;
        transform.Rotate(0, yRot, 0);
        Debug.Log(yRot);
    }
}
