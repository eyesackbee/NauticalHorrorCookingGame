using UnityEngine;

[CreateAssetMenu]
public class Ingredient : ScriptableObject
{
    public string ingredientName;
    public GameObject ingredientPrefab;
    public ActionType actionType;
}

public enum ActionType
{
    Mix,
    Add
}
