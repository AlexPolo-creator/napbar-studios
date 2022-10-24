using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Inicial : MonoBehaviour
{
    private void Awake()
    {
        Stats.inGameplay = false;
    }
    public void Jugar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void Salir(){
        Debug.Log("Salir...");
        Application.Quit();
    }
}
