using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Configuration")]
    [SerializeField] float speed;
    public bool isFacingRight;

    SpriteRenderer bulletScripts;

    private void Start()
    {
        bulletScripts = GetComponent<SpriteRenderer>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        BulletMove();
    }
    void BulletMove()
    {
        if (isFacingRight) 
        {
            
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            
        }
        else
        {
            bulletScripts.flipX = true;
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        }
    }
}
