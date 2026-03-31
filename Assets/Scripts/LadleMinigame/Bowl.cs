using UnityEngine;

public class Bowl : MonoBehaviour
{
    public Transform Ladle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (Ladle.GetChild(0).gameObject.activeSelf)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Ladle.GetChild(0).gameObject.SetActive(false);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Ladle"))
    //    {
    //        transform.GetChild(0).gameObject.SetActive(true);
    //    }
    //}
}
