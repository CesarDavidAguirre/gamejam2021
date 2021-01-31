using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float Speed = 0.5f;
    void Start()
    {
        Destroy(this.gameObject, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        VidaUtil -= Time.deltaTime;
        if (VidaUtil <= 0)
        {
            Destroy(this.gameObject);
        }
        transform.Translate(1 * Time.deltaTime * Speed, 0, 0);
    }

}
