using UnityEngine;

[CreateAssetMenu(fileName = "NewTower", menuName = "Game/Tower")]
public class TowerData : ScriptableObject
{
    public string trapName;
    public float damage;
    public float cooldown;
    public float range;
    public GameObject trapPrefab;
}
