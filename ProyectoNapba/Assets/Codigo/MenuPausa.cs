using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPausa : MonoBehaviour
{
   [SerializeField] private GameObject botonPausa;
   [SerializeField] private GameObject menuPausa;
    public void Pausa(){
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Reanudar(){
        Time.timeScale = AcelerarMenu.velocidad;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void Salir(){
        //Debug.Log("Saliendo..."); 
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    
    }
  
}
