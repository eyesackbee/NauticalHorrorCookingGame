
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class StirManager : MonoBehaviour
{
    public StirPoint[] stirPoints;
    public Transform[] ingredientPoints;
    public float maxStirs;
    public Slider stirProgressBar;
   // public UnityEvent onComplete;
   //public UnityEvent onTimeOut;
    private List<StirPoint> stirPointsList;
    private int stirCount = 0;
    public float stirRate;
    public float stirRadius;
    public LayerMask layerMask;
    private List<RaycastHit2D> results = new List<RaycastHit2D>();
    private bool mouseDown = false;
    private float speedOfStir = 0;
    private bool beginStir = true;
    private bool timedOut = false;
    //private OnGameOver onGameOver;
    private AudioSource audio;
    public Transform LadleEnd;

    // Start is called before the first frame update
    void Start()
    {
        stirPointsList = new List<StirPoint>();
        //onGameOver = GetComponent<OnGameOver>();
        audio = GetComponent<AudioSource>();
    }

    void StirIngredients ()
    {
        for (int i = 0; i < ingredientPoints.Length; i++) 
        {
            ingredientPoints[i].Rotate(0, 0, Random.Range(5, 15));
        }
        if (audio != null)
        {
            if (audio.isPlaying == false && mouseDown == true)
            {
                audio.Play();
            }

        }


    }

    // Update is called once per frame
    void Update()
    {
        if (stirPointsList.Count >= 14)
        {
            print("stir speed " + speedOfStir);
            speedOfStir = 0;
            ClearStirMarkers();
        }

        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
            speedOfStir += Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseDown = false;
            if(audio != null)
            {
                audio.Stop();

            }
        }


            if (mouseDown == true)
        {
            //RaycastHit2D hit = Physics2D.CircleCast(Camera.main.ScreenToWorldPoint(Input.mousePosition), stirRadius, Vector2.zero, 1f, layerMask);
            RaycastHit2D hit = Physics2D.CircleCast(LadleEnd.position, stirRadius, Vector2.zero, 1f, layerMask);
            {
                if (hit != null)
                {
                    
                        
                        StirPoint stirPoint = hit.transform.GetComponent<StirPoint>();
                        if (stirPoint == null)
                        {
                            return;
                        } 
                        if (beginStir == true)
                        {
                            if (stirPoint.gameObject.name == "StirPoint1")
                            {
                                beginStir = false;
                                stirPoint.Stir();
                                stirPointsList.Add(stirPoint);
                            }
                            else
                            {
                                ClearStirMarkers();
                            }
                        }
                        else
                        {
                            if (stirPoint.IsStirred() == false)
                            {
                                StirIngredients();
                                stirPoint.Stir();
                                stirPointsList.Add(stirPoint);
                            }
                        }
                        
                        
                        
                    
                }
            }
        }
    }

    void ClearStirMarkers()
    {

        for (int i = 0; i < stirPointsList.Count; i++)
        {
            stirPointsList[i].UnStir();

        }
        stirPointsList = new List<StirPoint>();
        if (beginStir == true)
        {
            return;
        }
        beginStir = true;
        stirCount += 1;
        stirProgressBar.value = (float)stirCount/maxStirs;
        print((float)stirCount / maxStirs); 
        if (IsStirsComplete())
        {
            timedOut = true;
            //onGameOver.OnComplete();
        }
    }

    public bool IsStirsComplete()
    {
        if (stirCount > 0.75f * maxStirs)
        {
            return true;
        }
        else
        { return false; }
    }

    public void Message(string message)
    {
        Debug.Log(message);
    }

}
