using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float Speed = 1;
    float VidaUtil = 10;
    void Start()
    {
        
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
