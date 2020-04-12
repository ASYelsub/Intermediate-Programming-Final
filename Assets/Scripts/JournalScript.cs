using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalScript : MonoBehaviour
{
    public int pageIndex;

    Entry[] Entries = new Entry[8];

    private void Awake()
    {

    }

    private void Start()
    {
        //sorting index is always accessible to player
        string DisplayedTitle = Entries[pageIndex].title;
        string DisplayedDescription = Entries[pageIndex].description;
        string DisplayedTexture = Entries[pageIndex].description;

    }

}//Need: A way to input strings, the index, a way to input images

public struct Entry
{
    public string title;
    public string description;
    public Texture symbol;
}