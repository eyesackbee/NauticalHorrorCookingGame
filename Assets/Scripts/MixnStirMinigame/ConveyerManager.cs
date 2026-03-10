using UnityEngine;

public class ConveyerManager : MonoBehaviour

{
    public Ingredient[] conveyerItems;
    public GameObject mixPrefab;
    public GameObject addPrefab;
    public Transform appearancePosition;
    private int index = 0;
    public float spawnRateInSeconds;
    private float count = 0;
    public static AddAction actionInProgress;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(index == conveyerItems.Length) { return; }
        count += Time.deltaTime;
        if (count > spawnRateInSeconds)
        {
            if(conveyerItems[index].actionType == ActionType.Mix)
            {
                GameObject clone = Instantiate(mixPrefab, transform.position, Quaternion.identity);
                clone.GetComponent<AddAction>().SetIngredient(conveyerItems[index]);
            }
            else
            {
                GameObject clone = Instantiate(addPrefab, transform.position, Quaternion.identity);
                clone.GetComponent<AddAction>().SetIngredient(conveyerItems[index]);
            }
            
            count = 0;
            index += 1;
        }
    }

    public void ShowAdd(Ingredient ingredient, AddAction action)
    {
        if (ingredient.ingredientPrefab != null)
        {
            GameObject clone = Instantiate(ingredient.ingredientPrefab, appearancePosition.position, Quaternion.identity);
            clone.GetComponent<Rigidbody2D>().gravityScale = 0;
            action.SetIngredientPrefab(clone);
            clone.GetComponent<ClickedIngredient>().SetAction(action);
        }
        
    }
}
