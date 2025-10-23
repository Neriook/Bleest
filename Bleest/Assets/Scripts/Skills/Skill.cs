using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill", menuName = "Skills/Skill")]
public class Skill : ScriptableObject
{
    public float cooldown;
    public float speed;
    public GameObject prefab;
}
