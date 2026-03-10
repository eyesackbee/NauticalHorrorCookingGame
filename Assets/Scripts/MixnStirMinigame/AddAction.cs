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

    public void OperationCompleted()
    {
        ingredient.CompletedOperation = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Marker"))
        {
            manager.ShowAdd(ingredient, this);
            ConveyerManager.actionInProgress = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Marker"))
        {
            if (ingredient.CompletedOperation == true)
            {
                Debug.Log("Operation Complete");
            }

            if (prefab != null)
            {
                
                Destroy(prefab);
            }
            Destroy(gameObject,1f);
        }
    }
}
