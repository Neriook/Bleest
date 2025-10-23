using UnityEngine;
using System.Collections.Generic;

public class scSkill : MonoBehaviour
{
    private List<Skill> skills = new List<Skill>();

    public void addSkill(Skill skill)
    {
        if (!skills.Contains(skill))
        {
            skills.Add(skill);
        }
    }

    public void UseSkill(Skill skill)
    {
    }
}

