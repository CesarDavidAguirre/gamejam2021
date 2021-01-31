using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimArcoirisAtak : MonoBehaviour
{
     Material mat;
    public float velocidad;
    private void Start()
    {
        mat = this.GetComponent<SpriteRenderer>().material;
    }
    void Update()
    {
        velocidad += velocidad * 0.1f * Time.deltaTime;
        mat.mainTextureOffset = new Vector2(velocidad, 0);
    }
}
