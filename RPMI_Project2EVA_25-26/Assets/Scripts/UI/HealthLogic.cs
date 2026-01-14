
using UnityEngine;
using UnityEngine.UI;

public class HealthLogic : MonoBehaviour
{
    [SerializeField] Image HealthUI;
    

    // Update is called once per frame
    void Update()
    {
        HealthUpdater();
    }

    void HealthUpdater()
    {

        HealthUI.fillAmount = GameManager.Instance.playerHealth / GameManager.Instance.maxhealth;
    
    }
}
