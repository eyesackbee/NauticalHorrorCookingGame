using System.Collections;
//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Table : MonoBehaviour
{
    //rotation 22 and -22
    public float maxLeftRotation;
    public float maxRightRotation;
    public float maxRotationSpeed;
    public float minRotationSpeed;
    public float maxWaitTime;
    public float minWaitTime;

    private Quaternion startRotation;
    private Quaternion endRotation;
    private float t = 0;
    private bool canRotate = true;
    private bool goRight = true;
    private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startRotation = Quaternion.identity;
        endRotation = CalculateRotation(transform.eulerAngles);
        speed = Random.Range(minRotationSpeed, maxRotationSpeed);
    }

    Quaternion CalculateRotation(Vector3 currentRotation)
    {
        if (goRight)
        {
            float a = Random.Range(-maxRightRotation, -5f);
            endRotation = Quaternion.Euler(0, 0, a);
            goRight = false;
        }
        else
        {
            float a = Random.Range(5f, maxLeftRotation);
            endRotation = Quaternion.Euler(0, 0, a);
            goRight = true;
        }
        return endRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canRotate) { return; }
        t += Time.deltaTime / speed;
        Quaternion interpolate = Quaternion.Slerp(startRotation, endRotation, t);
        transform.rotation = interpolate;
        if(t >= 1f)
        { 
            Debug.Log("Done");
            StartCoroutine(WaitABit());
            canRotate = false;
        }
    }

    IEnumerator WaitABit()
    {
        float waitTime = Random.Range(minWaitTime, maxWaitTime);
        yield return new WaitForSeconds(waitTime);
        startRotation = transform.rotation;
        Vector3 blah = startRotation.eulerAngles;
        endRotation = CalculateRotation(blah);
        canRotate = true;
        t = 0f;
        speed = Random.Range(minRotationSpeed, maxRotationSpeed);
    }
}
