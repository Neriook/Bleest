using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Skill skill;

    public void Setup(Skill skill)
    {
        this.skill = skill;
    }

    private void Update()
    {
        if (skill == null)
        {
            return;
        }

        transform.position += Vector3.left * skill.speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
