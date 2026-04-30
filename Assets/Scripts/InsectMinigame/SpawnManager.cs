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
                SetDirectionBottomRight(index, spawnIndex);
                //swap to bottom Left
                break;
            case 2:
                SetDirectionTopLeft(index, spawnIndex);
                //swap to top left
                break;
            case 3:
                SetDirectionBottomLeft(index, spawnIndex);
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
        GameObject clone = Instantiate(Bug[index], SpawnPoints[spawnIndex].position, Quaternion.identity);
        Bug bug = clone.GetComponent<Bug>();
        bug.direction = -1;
        float Rotz = UnityEngine.Random.Range(-25f, 20f);
        clone.transform.Rotate(0, 0, Rotz);
    }

    public void SetDirectionBottomRight(int index, int spawnIndex)
    {
        //create lines to set rotational values
        GameObject clone = Instantiate(Bug[index], SpawnPoints[spawnIndex].position, Quaternion.identity);
        Bug bug = clone.GetComponent<Bug>();
        bug.direction = -1;
        float Rotz = UnityEngine.Random.Range(-30f, 0f);
        clone.transform.Rotate(0, 0, Rotz);
    }

    public void SetDirectionBottomLeft(int index, int spawnIndex)
    {
        //create lines to set rotational values
        GameObject clone = Instantiate(Bug[index], SpawnPoints[spawnIndex].position, Quaternion.identity);
        Bug bug = clone.GetComponent<Bug>();
        bug.direction = 1;
        float Rotz = UnityEngine.Random.Range(0f, 20f);
        clone.transform.Rotate(0, 0, Rotz);
        bug.Flip();
    }

    public void SetDirectionTopLeft(int index, int spawnIndex)
    {
        //create lines to set rotational values
        GameObject clone = Instantiate(Bug[index], SpawnPoints[spawnIndex].position, Quaternion.identity);
        Bug bug = clone.GetComponent<Bug>();
        bug.direction = 1;
        float Rotz = UnityEngine.Random.Range(-13f, 9f);
        clone.transform.Rotate(0, 0, Rotz);
        bug.Flip();
    }
}
