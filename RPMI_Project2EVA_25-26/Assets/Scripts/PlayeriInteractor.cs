using UnityEngine;

public class PlayeriInteractor : MonoBehaviour
{
    [SerializeField] int loseHealth = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BadPick"))
        {
            //Acceso al singleton Manager
            GameManager.Instance.playerHealth -= loseHealth;
            collision.gameObject.SetActive(false);

        }




    }



}

