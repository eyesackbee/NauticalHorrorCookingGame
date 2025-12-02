using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCutting : MonoBehaviour
{
    public bool down = false;
    public bool dragStarted = false;
    public CutManager cutManager;
    private Collider2D startCollider;
    public GameObject cutLine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && dragStarted == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1f);
            if (hit == true && hit.collider.transform.parent == transform && hit.collider.tag == "Cut")
            {
                print("mouseDown " + name);
                dragStarted = true;
                hit.collider.tag = "CutStart";
                startCollider = hit.collider;
            }
        }
        if (Input.GetMouseButtonUp(0) && dragStarted == true)
        {
            print("here");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1f);
            if (hit == true && hit.collider.transform.parent == transform && hit.collider.tag == "Cut")       
            {
                print("mouseUp " + name);
                dragStarted = false;
                cutManager.RemoveCutLine(gameObject);
                cutLine.SetActive(false);
            }
            else
            {
                print("start again");
                dragStarted = false;
                startCollider.tag = "Cut";
            }
        }
    }
}
