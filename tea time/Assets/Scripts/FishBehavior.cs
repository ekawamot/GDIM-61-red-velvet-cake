using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehavior : MonoBehaviour
{
    public float speed = 2f;
    public float lifetime = 10f;

    private float timer = 0f;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // destroy fish to not stress computer.
        timer += Time.deltaTime;
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        Destroy(gameObject); // grab fish when click.
    }
}
