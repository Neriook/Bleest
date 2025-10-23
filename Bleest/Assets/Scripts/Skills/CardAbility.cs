using System;
using UnityEngine;

public class CardAbility : MonoBehaviour
{
    [SerializeField] private Skill skill;

    public void OnTriggerEnter2D(Collider2D other)
    {
        scSkill side = other.GetComponent<scSkill>();
        if (side != null)
        {
            side.addSkill(skill);
            Destroy(gameObject);
        }
    }
}
