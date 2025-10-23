using System.Collections.Generic;
using UnityEngine;

public class scInput : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private mcInput mainCharacter;
    [SerializeField] private float followDistance = 1f;
    [SerializeField] private float speedMultiplier = 1f;

    private void FixedUpdate()
    {
        List<Vector3> path = mainCharacter.positionHistory;
        if (path.Count < 2) return;

        float distanceAccum = 0f;
        Vector3 targetPos = path[0];

        for (int i = path.Count - 1; i > 0; i--)
        {
            float segment = Vector3.Distance(path[i], path[i - 1]);
            distanceAccum += segment;

            if (distanceAccum >= followDistance)
            {
                targetPos = path[i - 1];
                break;
            }
        }

        float mainSpeed = mainCharacter.GetComponent<Rigidbody2D>().linearVelocity.magnitude;
        float relativeSpeed = Mathf.Max(mainSpeed, 0.1f) * speedMultiplier;

        Vector2 newPos = Vector2.MoveTowards(rb.position, targetPos, relativeSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }
}

