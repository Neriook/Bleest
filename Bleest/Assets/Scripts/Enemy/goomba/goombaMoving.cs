using UnityEngine;

public class GoombaMoving : Enemy
{
    public float speed = 10.0f;  
    public float moveDistance = 10.0f; 
    private Vector3 startPosition;
    public Vector2 direction = new Vector2(1, 0);

    private void Start()
    {
        startPosition = transform.position; 
    }

    protected override void Move()
    {
        transform.Translate(Vector2.right * speed * direction * Time.deltaTime);

        if (Vector2.Distance(startPosition, transform.position) >= moveDistance)
        {
            direction *= -1;               
            startPosition = transform.position; 
        }
    }
}
