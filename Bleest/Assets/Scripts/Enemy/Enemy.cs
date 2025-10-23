using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour
{
    public GameObject shieldObject;

    protected bool isDead = false;
    public bool hasShield = true;
    protected bool isPaused = false;

    protected abstract void Move();

    protected virtual void Update()
    {
        if (!isDead && !isPaused)
            Move();
    }

    public virtual void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }

    public IEnumerator PauseMovement(float seconds)
    {
        isPaused = true;
        yield return new WaitForSeconds(seconds);
        isPaused = false;
    }

    public virtual void BreakShield()
    {
        if (hasShield)
        {
            hasShield = false;

            StartCoroutine(PauseMovement(1.55f));
        }
    }
}
