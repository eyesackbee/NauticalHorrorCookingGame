using UnityEngine;

public class Hole : MonoBehaviour
{
    public HoleManager manager;
    private Collider2D Collider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Collider = GetComponent<Collider2D>();
    }

    private void OnMouseDown()
    {
        Collider.enabled = false;
        manager.RemoveHole();
    }
}
