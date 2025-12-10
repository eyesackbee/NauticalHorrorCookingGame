using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Bug;
    public float SpawnRate;
    public Transform SpawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnBug());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnBug()
    {
        yield return new WaitForSeconds(SpawnRate);
        Instantiate(Bug, SpawnPoint.position,Quaternion.identity);
        StartCoroutine(SpawnBug());
    }
}
