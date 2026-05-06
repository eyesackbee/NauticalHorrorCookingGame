using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public LayerMask layerMask;

    [HideInInspector]public bool dragging = false;

    private Transform selectedObject;
    private Vector3 worldPosition;

    private Vector3 offset;
    public bool snapBack = false;
    private Vector3 origin;
    [HideInInspector] public bool movingBack = false;
    public Animator FishAnimator;
    [HideInInspector] public bool canLadle = false;
    private Vector3 originalPos;
    private void Start()
    {
        origin = transform.position;
        originalPos = transform.position;
    }



    // Update is called once per frame
    void Update()
    {
        if (!canLadle) { return; }
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0;
        if (Input.GetMouseButtonDown(0) && canLadle)
        {
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero, 1f, layerMask);
            if (hit != null && hit.collider.gameObject == gameObject)
            {
                print(hit.collider.name);
                selectedObject = hit.collider.transform;
                offset = worldPosition - selectedObject.position;
                dragging = true;
            }
        }

        if (Input.GetMouseButtonUp(0)) //canLadle is changed by ActionMarker script
        {
            dragging = false;
            movingBack = true;
        }

        if (dragging)
        {
            selectedObject.position = worldPosition - offset;
        }
        //if (snapBack && movingBack)
        //{
        //    float step = snapBackSpeed * Time.deltaTime;
        //    SnapBack(step);
        //}

    }



    void SnapBack(float step)
    {
        transform.position = Vector2.MoveTowards(transform.position, origin, step);
        if (Mathf.Approximately(Vector2.Distance(transform.position, origin), 0))
        {
            movingBack = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        FishAnimator.SetTrigger("Kill");
    }

    public void Reset()
    {
        transform.position = originalPos;
        canLadle = false;
        dragging = false;
    }
}
