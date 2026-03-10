using UnityEngine;

[CreateAssetMenu]
public class Ingredient : ScriptableObject
{
    public string ingredientName;
    public GameObject ingredientPrefab;
    public ActionType actionType;
    public bool CompletedOperation = false;
}

public enum ActionType
{
    Mix,
    Add
}
