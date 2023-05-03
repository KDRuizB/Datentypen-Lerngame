using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

//public enum DataType { Integer, String, Float, Bool };
public class BoxManager : MonoBehaviour
{
    private AntwortManager random; // Reference to the AntwortManager script
    private int selectedRandomIndex; // Private variable to store selected random index

    void Start()
    {
        random = FindObjectOfType<AntwortManager>(); // Find the AntwortManager script in the scene
        selectedRandomIndex = AntwortManager.selectedRandomIndex; // Get the selected random index from the AntwortManager script
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
    Debug.Log("on trigger");
        if (other.gameObject.GetComponent<AntwortDragDrop>() != null)
        {
            Debug.Log("not null");
            }
            /*
            switch (boxType)
            {
                case DataType.Integer:
                    if (random.examples[DataType.Integer][selectedRandomIndex] is int)
                    {
                        Debug.Log("Correct data type for box: " + boxType.ToString());
                    }
                    else
                    {
                        Debug.Log("Incorrect data type for box: " + boxType.ToString());
                    }
                    break;
                case DataType.String:
                    if (random.examples[DataType.String][selectedRandomIndex] is string)
                    {
                        Debug.Log("Correct data type for box: " + boxType.ToString());
                    }
                    else
                    {
                        Debug.Log("Incorrect data type for box: " + boxType.ToString());
                    }
                    break;
                case DataType.Float:
                    if (random.examples[DataType.Float][selectedRandomIndex] is float)
                    {
                        Debug.Log("Correct data type for box: " + boxType.ToString());
                    }
                    else
                    {
                        Debug.Log("Incorrect data type for box: " + boxType.ToString());
                    }
                    break;
                case DataType.Bool:
                    if (random.examples[DataType.Bool][selectedRandomIndex] is bool)
                    {
                        Debug.Log("Correct data type for box: " + boxType.ToString());
                    }
                    else
                    {
                        Debug.Log("Incorrect data type for box: " + boxType.ToString());
                    }
                    break;
            }
            */
        }
    }
