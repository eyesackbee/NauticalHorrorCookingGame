using UnityEngine;

public class Bowl : MonoBehaviour
{
    public Transform Ladle;
    private Transform Soup;
    private int SoupAmount = 0;
    private bool BowlFull = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //transform.GetChild(0).gameObject.SetActive(false);
        Soup = transform.GetChild(0).gameObject.transform;
        Soup.localScale = new Vector3(0, 0, 0);
    }

    public void AddSoup()
    {
        if (BowlFull ==true) { return; }

        Soup.localScale += new Vector3(0.3f, 0.3f, 0.3f);
        SoupAmount += 1;
        if (SoupAmount == 3)
        {
            BowlFull = true;
        }
    }

}
