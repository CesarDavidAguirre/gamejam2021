using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playScript : MonoBehaviour
{
   
    public void play()
    {
        SceneManager.LoadScene("nivelCesar");
    }

    public void menuPrincipal()
    {
        SceneManager.LoadScene("menu");
    }
}
