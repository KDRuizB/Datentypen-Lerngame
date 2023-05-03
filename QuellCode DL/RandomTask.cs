using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomTask : MonoBehaviour
{

    private Vector3 startPos;
    public GameObject Sprechblase;

    public string getDrag;
    private string stringGet;

    public float posX = 0;
    public float posY = 0;

    public TextMeshPro textMeshPro;

    void Awake(){

        // get the random datatype
        getDrag = GenerateDataTypeString();
        // move the random datatype to the AntwortDragDrop function
        stringGet = getDrag;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get the TextMeshPro component on this game object
        textMeshPro = GetComponentInChildren<TextMeshPro>();

        // convert the datatype in simple datatpes
        textMeshPro.text = simpleDatatypes(stringGet);

        // 
        Sprechblase = GameObject.Find("Sprechblase");

        // position sprechblase
        transform.position = new Vector3(posX, posY, 0f);
        startPos = transform.position;

        // counter
        int counter = AntwortDragDrop.counter;
        Debug.Log("Counter: " + counter);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public string GenerateDataTypeString()
    {
        // Generate a random number from 1 to 4
        int dataTypeNum = Random.Range(1, 5);

        // Set the data type string based on the random number
        string dataTypeString = "";

        switch (dataTypeNum)
        {
            case 1:
                dataTypeString = "System.Int32";
                break;
            case 2:
                dataTypeString = "System.Single";
                break;
            case 3:
                dataTypeString = "System.String";
                break;
            case 4:
                dataTypeString = "System.Boolean";
                break;
        }

        return dataTypeString;
    }

    private string simpleDatatypes(string i)
    {
        if (i == "System.Int32"){
            i = "Integer";
            return i;
        }
        else if (i == "System.Single"){
            i = "Float";
            return i;

        }
        else if (i == "System.Boolean"){
            i = "Bool";
            return i;
        }
        else{
            i = "String";
            return i;
        }
    }
}
