using System;
using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Bug;
    public float SpawnRate;
    public Transform[] SpawnPoints;
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
        int index= UnityEngine.Random.Range(0,  Bug.Length);

        int spawnIndex = UnityEngine.Random.Range(0, SpawnPoints.Length);
        switch (spawnIndex)
        {
            case 0:
                SetDirectionTopRight(index, spawnIndex);
                //correct
                break;
            case 1:
                SetDirectionTopRight(index, spawnIndex);
                //swap to bottom Left
                break;
            case 2:
                SetDirectionTopRight(index, spawnIndex);
                //swap to top left
                break;
            case 3:
                SetDirectionTopRight(index, spawnIndex);
                //swap to bottom right
                break;
            default:
                break;
        }        
        StartCoroutine(SpawnBug());
    }

    public void SetDirectionTopRight(int index, int spawnIndex)
    {
        //create lines to set rotational values
        Instantiate(Bug[index], SpawnPoints[spawnIndex].position, Quaternion.identity);

    }
}
