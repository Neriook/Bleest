using UnityEngine;
using System.Collections.Generic;

public class scSkill : MonoBehaviour
{
    private List<Skill> skills = new List<Skill>();

    public void AddSkill(Skill skill)
    {
        if (!skills.Contains(skill))
        {
            skills.Add(skill);
        }
    }

    public void UseSkill(Skill skill)
    {
        if (!skills.Contains(skill) || skill.prefab == null) return;

        GameObject obj = Instantiate(skill.prefab, transform.position, Quaternion.identity);
        var proj = obj.GetComponent<Arrow>();
        if (proj != null)
        {
            proj.Setup(skill);
        }
    }
}

