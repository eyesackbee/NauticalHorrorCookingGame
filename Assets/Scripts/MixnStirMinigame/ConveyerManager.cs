using UnityEngine;

public class ConveyerManager : MonoBehaviour

{
    public GameObject[] conveyerItems;
    private int index = 0;
    public float spawnRateInSeconds;
    private float count = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count > spawnRateInSeconds)
        {
            Instantiate(conveyerItems[index], transform.position, Quaternion.identity);
            count = 0;
            index += 1;
        }
    }
}
