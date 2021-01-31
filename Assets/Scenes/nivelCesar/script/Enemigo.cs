using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float RadioVision;
    public float velocidad;

    GameObject player;

    Vector2 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = initialPosition;
        float dist = Vector2.Distance(player.transform.position, transform.position);
        if (dist < RadioVision) target = player.transform.position;

        float fixedspeed = velocidad * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, fixedspeed);
        Debug.DrawLine(transform.position, target, Color.green);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("disparoPJ"))
        {
            Destroy(collision.gameObject);
        }
    }
}
