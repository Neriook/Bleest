using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class mcInput : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;

    [HideInInspector] public List<Vector3> positionHistory = new List<Vector3>();

    private float lastHorizontalTime;
    private float lastVerticalTime;
    private bool isPaused = false;

    private void FixedUpdate()
    {
        if (isPaused)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        Vector2 input = Vector2.zero;
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        if (keyboard.aKey.isPressed) { input.x = -1; lastHorizontalTime = Time.time; }
        else if (keyboard.dKey.isPressed) { input.x = 1; lastHorizontalTime = Time.time; }

        if (keyboard.wKey.isPressed) { input.y = 1; lastVerticalTime = Time.time; }
        else if (keyboard.sKey.isPressed) { input.y = -1; lastVerticalTime = Time.time; }

        if (input.x != 0 && input.y != 0)
        {
            if (lastHorizontalTime > lastVerticalTime) input.y = 0;
            else input.x = 0;
        }

        rb.linearVelocity = input * speed;

        if (positionHistory.Count == 0 || Vector3.Distance(rb.position, positionHistory[positionHistory.Count - 1]) > 0.01f)
            positionHistory.Add(rb.position);
    }

    public IEnumerator mainPauseMovement(float seconds)
    {
        isPaused = true;
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(seconds);
        isPaused = false;
    }
}



