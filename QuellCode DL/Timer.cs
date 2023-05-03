using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject containingT; // This should be a TextMeshPro object

    public int countdownSeconds = 60; // The countdown time in seconds

    public float startTime; // The time the timer started
    private bool timerActive; // Whether the timer is currently running
    private int remainingSeconds; // The remaining time in seconds
    private int remainingMinutes; // The remaining time in minutes
    private bool countdownFinished; // Whether the countdown has finished
    private float resetTime; // The time at which the scene should be reset

    // Make sure that only one Timer object exists
    private static Timer instance = null;
    public static Timer Instance {
        get { return instance; }
    }

    private void Awake()
    {
        // Check if there is already an instance of Timer
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        remainingSeconds = countdownSeconds % 60;
        remainingMinutes = countdownSeconds / 60;
        startTime = Time.time;
        timerActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (containingT == null)
        {
            containingT = GameObject.FindWithTag("TimerText");
            return;
        }

        // update the text and get the TextMeshPro variable
        TextMeshProUGUI text = containingT.GetComponentInChildren<TextMeshProUGUI>();
        text.text = string.Format("{0:00}:{1:00}", remainingMinutes, remainingSeconds);

        if (timerActive)
        {
            float timeElapsed = Time.time - startTime;

            if (timeElapsed >= countdownSeconds)
            {
                // Countdown is finished
                timeElapsed = countdownSeconds;
                timerActive = false;
                countdownFinished = true;
                resetTime = Time.time + 5f; // Set the reset time to 5 seconds from now
                Debug.Log("Time is up!");
                TextMeshPro timesUp = GameObject.Find("Sprechblase").GetComponentInChildren<TextMeshPro>();
                timesUp.text = "Zeit ist abgelaufen!";
                int counter = 0;
                PlayerPrefs.SetInt("Counter", counter);
            }

            remainingSeconds = (int)(countdownSeconds - timeElapsed) % 60;
            remainingMinutes = (int)((countdownSeconds - timeElapsed) / 60);

            // Check if we need to update the minutes
            if (remainingSeconds == 60 && remainingMinutes == 0)
            {
                remainingMinutes = 1;
            }
        }

        // Check if we need to reset the scene
        if (countdownFinished && Time.time >= resetTime)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    
        // Check if we need to reset the scene
        if (countdownFinished && Time.time >= resetTime)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }

        if (countdownFinished && Time.time >= resetTime)
        {
            ResetTimer();
        }

    }
    
    public void StartTimer(){
        startTime = Time.time;
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
        Debug.Log("Timer has been stoped");
    }

    public void ResetTimer()
    {
        remainingSeconds = countdownSeconds % 60;
        remainingMinutes = countdownSeconds / 60;
        startTime = Time.time + 1f;
        countdownFinished = false;  
        timerActive = true;
    }
}
