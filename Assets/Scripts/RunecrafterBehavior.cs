using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//This script goes on the Runecraft object, which is found through Canvas>Active Element Image>Runecrafter
//It inputs the player using their mouse to draw a rune and then puts it on the ground below them.
public class RunecrafterBehavior : MonoBehaviour
{

    public Image chosenRune;
    public Button castButton;
    public GameObject runePrefab;

    private Sprite[] symbols;
    private Sprite blank;
    private bool ableToCast = false;
    private GameObject player;
    
    void Start()
    {
        symbols = this.GetComponent<BookBehavior>().symbols;
        blank = this.GetComponent<BookBehavior>().blankTexture;
        player = GameObject.Find("Player");
    }

    void Update()
    {
        castButton.interactable = ableToCast;
    }

    public void makeSelection(int runeIndex) {
        chosenRune.sprite = symbols[runeIndex];
        ableToCast = true;
    }

    public void Cast() {
        runePrefab.GetComponent<PlacedRunePrefab>().Rune = chosenRune.sprite;
        runePrefab.GetComponent<PlacedRunePrefab>().yRot = player.transform.rotation.eulerAngles.y;
        Instantiate(runePrefab, player.transform.position, Quaternion.identity);
        ableToCast = false;
        chosenRune.sprite = blank;
    }
}
