using System.Collections;
using UnityEngine;
using UnityEngine.Events;

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
    public int correctOperations = 0;
    public UnityEvent onComplete;
    private bool over = false;
    private GameObject LastAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(index == conveyerItems.Length && over == false) 
        { 
            if(correctOperations > 6)
            {
                Debug.Log("Excellent");
            }
            else if(correctOperations > 3)
            {
                Debug.Log("Good");
            }
            else
            {
                Debug.Log("bAD!!!!");
            }
            over = true;
       
                return; 
        }
        count += Time.deltaTime;
        if (count > spawnRateInSeconds)
        {
            GameObject clone = null;
            if(conveyerItems[index].actionType == ActionType.Mix)
            {
                clone = Instantiate(mixPrefab, transform.position, Quaternion.identity);
                clone.GetComponent<AddAction>().SetIngredient(conveyerItems[index]);
            }
            else
            {
                clone = Instantiate(addPrefab, transform.position, Quaternion.identity);
                clone.GetComponent<AddAction>().SetIngredient(conveyerItems[index]);
            }
            
            count = 0;
            index += 1;
            if (index == conveyerItems.Length)
            {
                LastAction = clone; 
            }
        }
    }

    public void ShowAdd(Ingredient ingredient, AddAction action)
    {
        if (action.GetIngredientType() == ActionType.Mix) { return; }
        if (ingredient.ingredientPrefab != null)
        {
            GameObject clone = Instantiate(ingredient.ingredientPrefab, appearancePosition.position, Quaternion.identity);
            clone.GetComponent<Rigidbody2D>().gravityScale = 0;
            action.SetIngredientPrefab(clone);
            if(clone.GetComponent<ClickedIngredient>() != null)
            {
                clone.GetComponent<ClickedIngredient>().SetAction(action);
            }
            
        }
        
    }

    public void MarkerTriggered(GameObject action)
    {
        if (over == true && action == LastAction)
        {
            StartCoroutine(OnComplete());
        }
    }

    IEnumerator OnComplete()
    {
        yield return new WaitForSeconds(2f);
        onComplete.Invoke();
    }

}
