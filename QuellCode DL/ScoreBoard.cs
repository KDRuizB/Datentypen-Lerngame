using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public GameObject containingT;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI text = containingT.GetComponentInChildren<TextMeshProUGUI>();
        int counterForText = AntwortDragDrop.counter;
        text.text = counterForText.ToString();
    }
}