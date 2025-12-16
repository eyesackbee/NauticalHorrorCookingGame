using UnityEngine;

public class ConveyerBelt : MonoBehaviour
{
    public float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-moveSpeed*Time.deltaTime, 0, 0);
    }
}
