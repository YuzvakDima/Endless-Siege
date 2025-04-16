using UnityEngine;

[CreateAssetMenu(fileName = "NewTrap", menuName = "Game/Trap")]
public class TrapData : ScriptableObject
{
    public string trapName;
    public float damage;
    public float cooldown;
    public float range;
    public GameObject trapPrefab;
    public int cost;
}
