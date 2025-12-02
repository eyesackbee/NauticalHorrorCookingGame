using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutting : MonoBehaviour
{
    public bool down=false;
    public static bool dragStarted = false;
    public GameObject wholeFruit;
    public GameObject fruitSplit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && down == true && dragStarted == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,1f);
            if (hit == true && hit.collider.tag == "Cut")
            {
                hit.collider.gameObject.tag = "Layer";
                print("mouseDown " + name);
                dragStarted = true;
            }
        }
        
        if (Input.GetMouseButtonUp(0) && down == false && dragStarted == true)
        {
            print("here");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,1f);
            if (hit == true && hit.collider.tag == "Cut")
            {
                print("mouseUp " + name);
                dragStarted = false;
                fruitSplit.SetActive(true);
                wholeFruit.SetActive(false);
            }
            else
            {
                print("start again");
                dragStarted=false;
            }
        }
        
        
    }
}
