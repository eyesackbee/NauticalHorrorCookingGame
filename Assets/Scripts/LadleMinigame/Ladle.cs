using UnityEngine;
using UnityEngine.InputSystem;

public class Ladle : MonoBehaviour
{
    public LayerMask layer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPos.z = 0;
        transform.position = cursorPos;

        if (Input.GetMouseButtonDown(0))
        {
            if (transform.GetChild(0).gameObject.activeSelf)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1f, layer);
                if (hit == true)
                {
                    print("mouseDown " + hit.collider.name);
                    hit.collider.transform.GetChild(0).gameObject.SetActive(true);
                }
            }

           
        }
       

    }
}
