using UnityEngine;

[CreateAssetMenu(fileName = "NewBarricade", menuName = "Game/Barricade")]
public class BarricadeData : ScriptableObject
{
    public string barricadeName;
    public GameObject trapPrefab;
    public int cost;
    public float health;
}
