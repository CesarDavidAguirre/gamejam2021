using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    Vector2 Enemypos;
    public GameObject PlayerM;
    bool followP;
    public int speed;

    void Update()
    {
        if (followP)
        {
            transform.position = Vector2.MoveTowards(transform.position, Enemypos, speed * Time.deltaTime);

        }

        if (Vector2.Distance(transform.position, Enemypos) > 12f)
        {
            followP = false;
        }

        
    }

    private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag.Equals("Player"))
            {
                Enemypos = PlayerM.transform.position;
                followP = true;
            }
        }
}
