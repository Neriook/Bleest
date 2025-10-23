using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    private Enemy parentEnemy;

    private void Awake()
    {
        parentEnemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) 
        {
            return;
        }
        parentEnemy.BreakShield();

        mcInput player = other.GetComponent<mcInput>();
        player.StartCoroutine(player.mainPauseMovement(0.8f));
        Destroy(gameObject);
    }
}
