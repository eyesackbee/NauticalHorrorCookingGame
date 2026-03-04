using UnityEngine;

public class AddAction : MonoBehaviour
{
    private ConveyerManager manager;
    private Ingredient ingredient;
    private GameObject prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = FindFirstObjectByType<ConveyerManager>();

    }

    public void SetIngredient(Ingredient theIngredient)
    {
        ingredient = theIngredient;
    }

    public void SetIngredientPrefab(GameObject veg)
    {
        prefab = veg;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Marker"))
        {
            manager.ShowAdd(ingredient, this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Marker"))
        {
            Destroy(prefab);
            Destroy(gameObject,1f);
        }
    }
}
