using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum DataType { Integer, Float, Bool, String }

public class AntwortManager : MonoBehaviour {

    [SerializeField] public DataType dataType;

    public TextMeshPro[] answerTexts;
    public static int selectedRandomIndex;

    private readonly Dictionary<DataType, object[]> examples = new Dictionary<DataType, object[]>{
        { DataType.Integer, new object[] { 10, 20, 30, 40, 50, 60, 70, 80 } },
        { DataType.Float, new object[] { 1.23f, 4.56f, 7.89f, 0.12f } },
        { DataType.Bool, new object[] { true, false, true, false } },
        { DataType.String, new object[] { "hello", "world", "foo", "bar" } }
    };
    
    private int intValue;
    private float floatValue;
    private bool boolValue;
    private string stringValue;

    private void Start() {
        answerTexts = GetComponentsInChildren<TextMeshPro>();
        if (answerTexts == null) {
            Debug.LogError("No TextMeshPro components found in scene.");
            return;
        }

        object[] values = examples[dataType];
        int randomIndex = Random.Range(0, values.Length);

        selectedRandomIndex = randomIndex;

        for (int i = 0; i < answerTexts.Length; i++) {
            switch (dataType) {
                case DataType.Integer:
                    intValue = (int)values[selectedRandomIndex];
                    answerTexts[i].text = intValue.ToString();
                    break;
                case DataType.Float:
                    floatValue = (float)values[selectedRandomIndex];
                    answerTexts[i].text = floatValue.ToString();
                    break;
                case DataType.Bool:
                    boolValue = (bool)values[selectedRandomIndex];
                    answerTexts[i].text = boolValue.ToString();
                    break;
                case DataType.String:
                    stringValue = (string)values[selectedRandomIndex];
                    answerTexts[i].text = stringValue;
                    break;
            }
        }
    }

    // Add this getter method to access the examples dictionary from other scripts
    public Dictionary<DataType, object[]> GetExamples()
    {
        return examples;
    }
}
