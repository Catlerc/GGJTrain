using UnityEngine;

[CreateAssetMenu(fileName = "Store item")]
public class StoreItem : ScriptableObject
{
    public Sprite sprite;
    public int cost;
    public GameObject prefab;
}