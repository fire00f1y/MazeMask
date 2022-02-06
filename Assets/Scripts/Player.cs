using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float scalingFactor = 0.01f;
    public LayerMask mazeLayerMask;
    public LayerMask winMask;
    private Vector3 newPos;
    private float radius;
    public GameOver gameOver;

    public void Awake()
    {
        newPos = transform.position;
        radius = transform.localScale.x / 2;
    }

    public void FixedUpdate()
    {
        if (GameManager.Instance().state > 0) return;

        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

        var direction = Vector3.Normalize(new Vector3(x, y, 0)) * scalingFactor;
        newPos = transform.position + direction;

        var collision = Physics2D.OverlapCircle(newPos, radius, mazeLayerMask);

        if (collision == null)
        {
            transform.Translate(direction);
        }

        collision = Physics2D.OverlapCircle(newPos, radius, winMask);
        if (collision != null)
        {
            Win();
        }
    }

    private void Win()
    {
        gameOver.Over();
        GameManager.Instance().GameOver();
    }
}