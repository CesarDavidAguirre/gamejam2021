using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaIzquierda : MonoBehaviour
{
    public float Speed = 1;
    
    void Start()
    {
        Destroy(this.gameObject, 1.2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-1 * Time.deltaTime * Speed, 0, 0);
    }

}
