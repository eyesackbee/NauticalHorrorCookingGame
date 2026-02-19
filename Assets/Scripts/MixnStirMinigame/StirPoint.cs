using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StirPoint : MonoBehaviour
{
    private bool stirred = false;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Stir()
    {
        stirred = true;
        spriteRenderer.color = Color.red;
    }

    public void UnStir()
    {
        stirred = false;
        spriteRenderer.color = Color.white;
    }


    public bool IsStirred()
    {
        return stirred;
    }
}
