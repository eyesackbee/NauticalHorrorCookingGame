using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float time;
    private float remainingTime;
    public Transform dial;
    public UnityEvent timeOver;
    public UnityEvent onEverySecond;
    private bool timeOut = false;
    public bool playOnAwake = true;
    private bool isPlaying = false;
    int previousSecond;
    // Start is called before the first frame update
    void Start()
    {
        remainingTime = time;
        previousSecond = Mathf.FloorToInt(remainingTime % 60);
        if (playOnAwake == true)
        {
            isPlaying = true;
        }
    }


    public void Play()
    {
        isPlaying = true;
    }

    public void Stop()
    {
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying == false) { return; }
        if (timeOut == false)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                int seconds = Mathf.FloorToInt(remainingTime % 60);
                if (previousSecond != seconds)
                {
                    previousSecond = seconds;
                    onEverySecond.Invoke();
                    print("a new second");
                }
                print(seconds);
                //float angle = (time - remainingTime) * 360f * Time.deltaTime;
                float angle = (remainingTime / time) * 360f;
                if (dial != null)
                {
                    dial.eulerAngles = new Vector3(0, 0, angle);

                }
            }
            else
            {
                if (dial != null)
                {
                    dial.eulerAngles = new Vector3(0, 0, 0);

                }

                timeOut = true;
                timeOver.Invoke();
            }

        }

    }
}
