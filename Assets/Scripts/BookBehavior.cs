using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//This script goes on the Book object, which is found through Canvas>Active Element Image>Book
//It has the functions for changing pages via buttons and displaying the information in the book
public class BookBehavior : MonoBehaviour {
    private string  DisplayedDescription;
    private Sprite DisplayedTexture;

    public Image SketchImage;
    public InputField EntryText;

    private int entryIndex = 0;

    public Sprite[] symbols;
    public Sprite blankTexure;

    private entry[] entries = new entry[8];

    void Start() {

        //Config Each Book Entry
        for (int i = 0; i < entries.Length; i++) {
            entries[i].sketch = symbols[i];
        }
        entryIndex = 0;

        AlterIndex(0);
    }

    public void AlterIndex(int dir) {

        //Save Current Info
        entries[entryIndex].description = EntryText.text;

        //Move Entry Index
        entryIndex += dir;
        if (entryIndex == 8) entryIndex = 0;
        else if (entryIndex == -1) entryIndex = 7;

        //Load Next Info
        DisplayedDescription = entries[entryIndex].description;
        DisplayedTexture = entries[entryIndex].sketch;
        EntryText.text = DisplayedDescription;
        SketchImage.sprite = DisplayedTexture;
    }
}

public struct entry {
    public string description;
    public Sprite sketch;
    public bool revealed;
}