using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance; //Definición de la fortaleza de datos 

    public static GameManager Instance
    {
        //Declaración del Singleton
        get
        {
            if (instance == null) Debug.Log("no hay game Manager");
            return instance;
        }

    }
    //Fin del Singleton 

    //TODAS LAS VARIABLES DE LA FORTALEZA DEBEN SER PÚBLICAS
    public float playerHealth;
    public float maxhealth= 100;
    public int playerPoints;


    private void Awake()
    {
       if(instance == null)
       {
            instance = this;
            DontDestroyOnLoad(gameObject);
       }
       else
       {
            Destroy(gameObject);
       }
    }
}
