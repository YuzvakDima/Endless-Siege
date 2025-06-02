using UnityEngine;

[CreateAssetMenu(fileName = "NewTower", menuName = "Game/Tower")]
public class TowerData : ScriptableObject
{
    public string towerName;
    public float damage;
    public float cooldown;
    public float range;
    public GameObject towerPrefab;
    public int cost;
}
