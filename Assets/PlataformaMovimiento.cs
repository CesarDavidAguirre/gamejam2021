using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovimiento : MonoBehaviour
{
    public GameObject objectoAmover;

    public Transform startPoint;
    public Transform endPoint;

    public float velocidad;

    private Vector3 moverHacia;
    // Start is called before the first frame update
    void Start()
    {
        moverHacia = endPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        objectoAmover.transform.position = Vector3.MoveTowards(objectoAmover.transform.position,moverHacia,velocidad*Time.deltaTime);

        if (objectoAmover.transform.position == endPoint.position)
        {
            moverHacia = startPoint.position;
        }

        if (objectoAmover.transform.position == startPoint.position)
        {
            moverHacia = endPoint.position;
        }
    }


}
