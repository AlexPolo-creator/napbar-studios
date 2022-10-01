using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIStats : MonoBehaviour
{
   // HUD
    public TextMeshProUGUI vidaJugadorTexto;

    public TextMeshProUGUI oroTexto;
    public TextMeshProUGUI favorTexto;
    public TextMeshProUGUI poblacionTexto;
    public TextMeshProUGUI comidaTexto;

    
    

    private void Start()
    {
        InvokeRepeating("refrescarUI", 0, 0.1f);
    }
    // Update is called once per frame
    void refrescarUI()
    {
        vidaJugadorTexto.text = "Vida: " + Stats.vidaJugador.ToString();

        oroTexto.text = "Oro: " + Stats.oro.ToString();
        favorTexto.text = "Favor de dioses: " + Stats.favorDeDioses.ToString();
        poblacionTexto.text = "Poblacion: " + Stats.poblacion.ToString() + " (" + Stats.poblacionLibre.ToString() + ")";
        comidaTexto.text = "Comida: " + Stats.comida.ToString();

        
    }
}
