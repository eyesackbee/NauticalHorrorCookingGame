using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class ClickedIngredient : MonoBehaviour
{
    public GameObject Bits;
    private Transform FallPosition;
    private bool Clicked = false;
    private AddAction addAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FallPosition = GameObject.FindGameObjectWithTag("FallPosition").transform;
    }

    public void SetAction(AddAction action)
    {
        addAction = action; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (Clicked == false)
        {
            StartCoroutine(ChoppedBits());
            Clicked = true;
            addAction.OperationCompleted();
        }
        
    }

    IEnumerator ChoppedBits()
    {
        for (int i = 0; i < 3; i++)
        {
            float offsetX = Random.Range(-1f, 1f);
            float offsetY = Random.Range(-1f, 1f);
            Vector3 offsetposition = new Vector3(offsetX, offsetY, 0);
            GameObject clone = Instantiate(Bits, FallPosition.position+offsetposition, Quaternion.identity);
            var body = clone.GetComponent<Rigidbody2D>();
            var angle = Random.Range(10, 180);
            var direction = Random.Range(-1, 1);
            var impulse = (angle * direction * Mathf.Deg2Rad) * body.inertia;
            body.AddTorque(impulse, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
