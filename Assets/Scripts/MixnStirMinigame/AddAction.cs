using UnityEngine;

public class AddAction : MonoBehaviour
{
    private ConveyerManager manager;
    private StirManager stirManager;
    private Ingredient ingredient;
    private GameObject prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        manager = FindFirstObjectByType<ConveyerManager>();
        stirManager = FindFirstObjectByType<StirManager>();
    }

    public void SetIngredient(Ingredient theIngredient)
    {
        ingredient = theIngredient;
    }

    public ActionType GetIngredientType()
    {
        return ingredient.actionType;
    }

    public void SetIngredientPrefab(GameObject veg)
    {
        prefab = veg;
    }

    public void OperationCompleted()
    {
        ingredient.CompletedOperation = true;
        if(ingredient.actionType == ActionType.Mix)
        {
            Debug.Log("Stirred");
            manager.correctOperations += 1;
        }
        if(ingredient.actionType != ActionType.Mix)
        {
            Debug.Log("Added");
            manager.correctOperations += 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Marker"))
        {
            stirManager.ClearStirMarkers();
            manager.ShowAdd(ingredient, this);
            ConveyerManager.actionInProgress = this;
            stirManager.canStir = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Marker"))
        {
            stirManager.canStir = false;
            stirManager.ClearStirMarkers();
            if (ingredient.CompletedOperation == true)
            {
                Debug.Log("Operation Complete");
            }

            if (prefab != null)
            {
                
                Destroy(prefab);
            }
            manager.MarkerTriggered(this.gameObject);
            Destroy(gameObject,1.25f);
        }
    }
}
