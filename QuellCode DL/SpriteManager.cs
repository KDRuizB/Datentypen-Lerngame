using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpriteManager : MonoBehaviour
{

    // sprite render variables
    public Sprite rightSprite, wrongSprite, normalSprite;
    public float startPosBotX;
    public float startPosBotY;

    private SpriteRenderer spriteRenderer;
    private string testIt;

    public GameObject ContainingA;

    // Start is called before the first frame update
    void Start()
    {
        // get the right sprite
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshPro ContainingAA = ContainingA.GetComponentInChildren<TextMeshPro>();
        testIt = ContainingAA.text;
        // test the current status of the game and change sprite if nessesary
        ChangeToNewSprite();
    }

    public void ChangeToNewSprite()
        {   
            if (testIt == "Richtig!" || testIt == "Prima! Du hast es Geschafft!")
            {
                spriteRenderer.sprite = rightSprite;
            }
            else if (testIt == "Falsch!" || testIt == "Zeit ist abgelaufen!")
            {
                spriteRenderer.sprite = wrongSprite;
            }
            else 
            {
                spriteRenderer.sprite = normalSprite;
            }
        }
}
