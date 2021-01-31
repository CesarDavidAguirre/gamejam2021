using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraScript : MonoBehaviour
{
    public GameObject personaje;
    private Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position - personaje.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = personaje.transform.position + position;

    }
}
