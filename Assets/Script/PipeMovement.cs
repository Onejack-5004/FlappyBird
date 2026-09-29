using UnityEngine;
using System.Collections.Generic;

public class PipeMovement : MonoBehaviour
{
    public static List<PipeMovement> allPipes = new List<PipeMovement>();

    private float moveSpeed;

    public float destroyX = -15f;

    void OnEnable()
    {
        allPipes.Add(this);
    }

    void OnDisable()
    {
        allPipes.Remove(this);
    }

    public void SetSpeed(float speed)
    {
        moveSpeed = speed;
    }

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x <= destroyX)
        {
            Destroy(gameObject);
        }
    }
}