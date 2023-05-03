using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class AntwortDragDrop : MonoBehaviour
{

    public SpriteManager spriteManager;

    public GameObject taskForm;

    public GameObject objectType;
    public GameObject objectType1;
    public GameObject objectType2;
    public GameObject objectType3;
    public static int counter;
    public Timer timerScript;


    public string textGet;
    private object answer;
    private bool isBeingHeld = false;
    private TextMeshPro[] getMesh;
    private TextMeshPro gameO;

    public Vector3 startPosition;

    void Start()
    {
        transform.position = startPosition; // the game object will be in this position at start
        getMesh = GetComponent<AntwortManager>().answerTexts;
        answer = null;

        textGet = GameObject.Find("Sprechblase").GetComponent<RandomTask>().getDrag;
                                                                                                  // assign the RandomTask component to the public variable
        // load the game counter
        counter = PlayerPrefs.GetInt("Counter", 0);
    }   

    void Update()
    {
        if (isBeingHeld)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
        }

        if (counter >= 10)
        {
            Win();
            Invoke("ReloadScene", 10f);
        }

        if (counter < 0){
            CorrectCounter();
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isBeingHeld = true;
        }
    }

    private void OnMouseUp(){
    
        isBeingHeld = false;

         CheckType();

        float distanceObjectType = Vector3.Distance(transform.position, objectType.transform.position);
        float distanceObjectType1 = Vector3.Distance(transform.position, objectType1.transform.position);
        float distanceObjectType2 = Vector3.Distance(transform.position, objectType2.transform.position);
        float distanceObjectType3 = Vector3.Distance(transform.position, objectType3.transform.position);

        float distanceToTaskForm = Vector3.Distance(transform.position, taskForm.transform.position);

        if (distanceObjectType <= 0.5f)
        {
            transform.position = objectType.transform.position;
            Debug.Log(answer);
        }
        else if (distanceToTaskForm <= 0.5f)
        {
            transform.position = taskForm.transform.position;
            Debug.Log("Dragged to Task");
            // ab hier wird die function abgespielt um den wert zu checken
            CheckAnswer();
        }
        else if (distanceObjectType1 <= 0.5f)
        {
            transform.position = objectType1.transform.position;
            Debug.Log(answer);
        }
        else if (distanceObjectType2 <= 0.5f)
        {
            transform.position = objectType2.transform.position;
            Debug.Log(answer);
        }
        else if (distanceObjectType3 <= 0.5f)
        {
            transform.position = objectType3.transform.position;
            Debug.Log(answer);
        }
        else
        {
            transform.position = startPosition;
        }
    }
    
    private void CheckType(){
        TextMeshPro text = GetComponentInChildren<TextMeshPro>();

        if (int.TryParse(text.text, out _))
        {
            answer = 1;
        }
        else if (float.TryParse(text.text, out _))
        {
            answer = 1.1f;
        }
        else if (bool.TryParse(text.text, out _))
        {
            answer = true;
        }
        else
        {
            answer = "hallo";
        }
    }

    public void CheckAnswer(){
        // get the Datatype of the answer block selected
        object type = answer.GetType();
        string convertedAnswer = Convert.ToString(type);

        if (convertedAnswer == textGet)
        {
            Debug.Log("Correct Answer");
            TextMeshPro updateRight = GameObject.Find("Sprechblase").GetComponentInChildren<TextMeshPro>();
            updateRight.text = "Richtig!";

            counter++;
            PlayerPrefs.SetInt("Counter", counter);
            Invoke("w84answer", 2f);
            // Reload the scene after 5 seconds
            Invoke("ReloadScene", 1f);

        }
        else{
            Debug.Log("Incorrect Answer");
            TextMeshPro updateWrong = GameObject.Find("Sprechblase").GetComponentInChildren<TextMeshPro>();
            updateWrong.text = "Falsch!";

            counter--;
            PlayerPrefs.SetInt("Counter", counter);
            Invoke("w84answer", 2f);
            // Reload the scene after 5 seconds
            Invoke("ReloadScene", 1f);
        }
    }

    // Reloads the current scene
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    private void w84answer()
    {
        transform.position = startPosition;
    }

    public void ResetCounter()
    {
        counter = 0;
        PlayerPrefs.SetInt("Counter", counter);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    private void Win(){
        isBeingHeld = false;
        counter = 0;
        PlayerPrefs.SetInt("Counter", counter);
        TextMeshPro winningText = GameObject.Find("Sprechblase").GetComponentInChildren<TextMeshPro>();
        winningText.text = "Prima! Du hast es Geschafft!";
    }

    private void CorrectCounter(){
        counter = 0;
        PlayerPrefs.SetInt("Counter", counter);
    }

}