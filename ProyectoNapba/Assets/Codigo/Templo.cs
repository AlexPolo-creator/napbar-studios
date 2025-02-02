using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Templo : MonoBehaviour
{

    public Color hoverColor; //color cuando poner el cursor por encima   
    private SpriteRenderer sprite; //creamos la variable sprite para poder cambiarle el color al SpriteRenderer de la mina   
    public Color colorInicial; //creamos la variable colorInicial para poder reestablecer inical el color al SpriteRenderer de la mina cuando quitemos el cursor de encima

    public static bool menuActivado = false;
    public static bool menuDesactivado = false;

    public GameObject getMenuTemplo;
    public static GameObject menuTemplo;


    // Start is called before the first frame update
    void Start()
    {
        menuTemplo = getMenuTemplo;

        numBotonesMejoraAxctivos = 0;

        precioBotinDivino1 = precioInicialBotinDivino1;
        precioCastigoPiadoso1 = precioInicialCastigoPiadoso1;
        precioClarividencia = precioInicialClarividencia;
        precioSantaSentencia1 = precioInicialSantaSentencia1;
        precioVivacidad1 = precioInicialVivacidad1;


        botonBotinActivado = false;
        botonCastigoActivado = false;
        botonSentenciaActivado = false;
        botonVivacidadActivado = false;
        botonClarividenciaActivado = false;

        numBotinDivino1 = 0;
        numCastigoPiadoso1 = 0;
        numSantaSentencia1 = 0;
        numVivacidad1 = 0;
        numClarividencia = 0;

        mejoraBotinDivino1 = false;
        mejoraCastigoPiadoso1 = false;
        mejoraSantaSentencia1 = false;
        mejoraVivacidad1 = false;
        mejoraClarividencia = false;

        //obtemos el componente SpriteRenderer de la mina
        sprite = GetComponent<SpriteRenderer>();

        //establecemos el color inicial al color de la mina al comienzo
        sprite.color = colorInicial;
    }

    public void desactivarMenu()
    {
        menuActivado = false;

        Colegio.menuDesactivado = false;
        Barracones.menuDesactivado = false;
        Herreria.menuDesactivado = false;
        Cultivos.menuDesactivado = false;
        Mina.menuDesactivado = false;
        Barrio.menuDesactivado = false;
    }

    //esta funcion se ejecuta al pulsar el nodo
    void OnMouseDown()
    {
        if (!menuActivado && !menuDesactivado)
        {
            Colegio.menuDesactivado = true;
            Barracones.menuDesactivado = true;
            Herreria.menuDesactivado = true;
            Cultivos.menuDesactivado = true;
            Mina.menuDesactivado = true;
            Barrio.menuDesactivado = true;

            Colegio.menuColegio.SetActive(false);
            Barracones.menuBarracones.SetActive(false);
            Herreria.menuHerreria.SetActive(false);
            Colegio.menuActivado = false;
            Barracones.menuActivado = false;
            Herreria.menuActivado = false;

            menuTemplo.SetActive(true);
            menuActivado = true;
            sprite.color = colorInicial;
        }
    }

    //esta funcion se ejecuta al colocar el cursor sobre el nodo
    void OnMouseEnter()
    {
        if (!menuActivado && !menuDesactivado)
        {
            sprite.color = hoverColor;
        }
    }

    //esta funcion se ejecuta al quitar el cursor de encima del nodo
    void OnMouseExit()
    {
        sprite.color = colorInicial;
    }


    //Mejoras globales (Bendiciones):
    public static bool mejoraBotinDivino1;
    public bool botonBotinActivado = false;
    public TextMeshProUGUI textoBotinPrecio;
    public static int numBotinDivino1;
    int precioBotinDivino1;
    public int precioInicialBotinDivino1 = 75;
    public GameObject botonBotinDivino1;

    public void ActivarBotinDivino1()
    {
        if (Stats.favorDeDioses >= precioBotinDivino1)
        {           
            botonBotinDivino1.SetActive(false);
            botonBotinActivado = false;
            numBotonesMejoraAxctivos--;
            numBotinDivino1++;
            mejoraBotinDivino1 = true;
            Stats.favorDeDioses -= precioBotinDivino1;
            precioBotinDivino1 = 2 * precioBotinDivino1;
        }
    }

    public static bool mejoraVivacidad1;
    public bool botonVivacidadActivado = false;
    public static int numVivacidad1;
    public TextMeshProUGUI textoVivacidadPrecio;
    int precioVivacidad1;
    public int precioInicialVivacidad1 = 50;
    public GameObject botonVivacidad1;
    public void ActivarVivacidad1()
    {
        if (Stats.favorDeDioses >= precioVivacidad1)
        {
            botonVivacidad1.SetActive(false);
            botonVivacidadActivado = false;
            numBotonesMejoraAxctivos--;
            numVivacidad1++;
            mejoraVivacidad1 = true;
            TropaStats.hechiceroVelocidadDeDisparo *= 1 + (0.15f * numVivacidad1); // + porque la velocidad de ataque de los magos es ataques/segundo y no al reves
            TropaStats.verdugoVelocidadDeDisparo *= 1 + (0.15f * numVivacidad1);
            TropaStats.druidaVelocidadDeDisparo *= 1 + (0.15f * numVivacidad1);
            TropaStats.inquisidorVelocidadDeDisparo *= 1 + (0.15f * numVivacidad1);
            Stats.favorDeDioses -= precioVivacidad1;
            precioVivacidad1 = 2 * precioVivacidad1;
        }      
    }

    public static bool mejoraCastigoPiadoso1;
    public bool botonCastigoActivado = false;
    public static int numCastigoPiadoso1;
    public TextMeshProUGUI textoCastigoPrecio;
    int precioCastigoPiadoso1;
    public int precioInicialCastigoPiadoso1 = 30;
    public GameObject botonCastigoPiadoso1;
 
    public void ActivarCastigoPiadoso1()
    {
        if (Stats.favorDeDioses >= precioCastigoPiadoso1)
        {
            botonCastigoPiadoso1.SetActive(false);
            botonCastigoActivado = false;
            numBotonesMejoraAxctivos--;
            numCastigoPiadoso1++;
            mejoraCastigoPiadoso1 = true;
            TropaStats.hechiceroAtaque = TropaStats.hechiceroAtaque * 1.1f;
            TropaStats.verdugoAtaque = TropaStats.verdugoAtaque * 1.1f;
            TropaStats.druidaAtaque = TropaStats.druidaAtaque * 1.1f;
            TropaStats.inquisidorAtaque = TropaStats.inquisidorAtaque * 1.1f;
            Stats.favorDeDioses -= precioCastigoPiadoso1;
            precioCastigoPiadoso1 = 2 * precioCastigoPiadoso1;
        }
    }

    public static bool mejoraSantaSentencia1;
    public bool botonSentenciaActivado = false;
    public static int numSantaSentencia1;
    public TextMeshProUGUI textoSentenciaPrecio;
    int precioSantaSentencia1;
    public int precioInicialSantaSentencia1 = 35;
    public GameObject botonSantaSentencia1;

    public void ActivarSantaSentencia1()
    {
        if (Stats.favorDeDioses >= precioSantaSentencia1)
        {
            botonSantaSentencia1.SetActive(false);
            botonSentenciaActivado = false;
            numBotonesMejoraAxctivos--;
            numSantaSentencia1++;
            mejoraSantaSentencia1 = true;
            TropaStats.hechiceroCriticoPorcentaje += 5f;
            TropaStats.verdugoCriticoPorcentaje += 5f;
            TropaStats.druidaCriticoPorcentaje += 5f;
            TropaStats.inquisidorCriticoPorcentaje += 5f;
            Stats.favorDeDioses -= precioSantaSentencia1;
            precioSantaSentencia1 = 2 * precioSantaSentencia1;
        }
    }

    public static bool mejoraClarividencia;
    public bool botonClarividenciaActivado = false;
    public static int numClarividencia;
    public TextMeshProUGUI textoClarividenciaPrecio;
    int precioClarividencia;
    public int precioInicialClarividencia = 60;
    public GameObject botonClarividencia;

    public void ActivarClarividencia()
    {
        if (Stats.favorDeDioses >= precioClarividencia)
        {
            botonClarividencia.SetActive(false);
            botonClarividenciaActivado = false;
            numBotonesMejoraAxctivos--;
            numClarividencia++;
            mejoraClarividencia = true;
            TropaStats.hechiceroRango += TropaStats.hechiceroRango * 0.1f;
            TropaStats.verdugoRango += TropaStats.verdugoRango * 0.1f;
            TropaStats.druidaRango += TropaStats.druidaRango * 0.1f;
            TropaStats.inquisidorRango += TropaStats.inquisidorRango * 0.1f;
            Stats.favorDeDioses -= precioClarividencia;
            precioClarividencia = 2 * precioClarividencia;
        }
    }

    private int numBotonesMejoraAxctivos = 0;
    private void Update()
    {
        if (numBotonesMejoraAxctivos < 3)
        {
            RandomMejoraGlobal();
            return;
        }     
    }

    private int numRandom;
    public void RandomMejoraGlobal()
    {      
        numRandom = Random.Range(0,5); //el 5 no est� incluido (por el culo te la hinco)
        
        if (numRandom == 0)
        {
            if (!botonBotinActivado)
            {               
                textoBotinPrecio.text = precioBotinDivino1.ToString();
                botonBotinDivino1.SetActive(true);
                botonBotinActivado = true;
                numBotonesMejoraAxctivos++;
            }             
        }
        else if (numRandom == 1)
        {
            if (!botonCastigoActivado)
            {
                textoCastigoPrecio.text = precioCastigoPiadoso1.ToString();
                botonCastigoPiadoso1.SetActive(true);
                botonCastigoActivado = true;
                numBotonesMejoraAxctivos++;
            }                      
        }
        else if (numRandom == 2)
        {
            if (numSantaSentencia1 < 10 && !botonSentenciaActivado)
            {
                textoSentenciaPrecio.text = precioSantaSentencia1.ToString();
                botonSantaSentencia1.SetActive(true);
                botonSentenciaActivado = true;
                numBotonesMejoraAxctivos++;
            }          
        }
        else if (numRandom == 3)
        {
            if (numVivacidad1 < 5 && !botonVivacidadActivado)
            {
                textoVivacidadPrecio.text = precioVivacidad1.ToString();
                botonVivacidad1.SetActive(true);
                botonVivacidadActivado = true;
                numBotonesMejoraAxctivos++;
            }           
        }
        else if (numRandom == 4)
        {
            if (numClarividencia < 5 && !botonClarividenciaActivado)
            {
                textoClarividenciaPrecio.text = precioClarividencia.ToString();
                botonClarividencia.SetActive(true);
                botonClarividenciaActivado = true;
                numBotonesMejoraAxctivos++;
            }
        }
        return;
    }
}
