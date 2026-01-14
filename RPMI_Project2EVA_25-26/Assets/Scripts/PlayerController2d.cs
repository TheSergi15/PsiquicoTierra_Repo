using System.Collections;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2d : MonoBehaviour
{
    #region General Variables
    [Header("Movement & Jump Configuration")]
    [SerializeField]  float speed = 5f;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] bool isGrounded;
    [SerializeField] Transform groundCheck;//Posici
    [SerializeField] float groundCheckRadius = 0.1f;
    [SerializeField] LayerMask groundLayer;

    [Header("Shoot Configuration")]
    [SerializeField] Transform shootPosition;
    [SerializeField] GameObject proyectile; //Ref al prefab del proyectile 

    Rigidbody2D playerRB; //Referencia el rigidbody del player 
    Animator anim;//Referencia al controlador de animaciones del player 
    PlayerInput input; //Referencia al cerebro de inputs del player 
    Vector2 moveInput;
    bool canAttack; //Comprobador para determinar si se puede atacar



    #endregion
    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
        canAttack = true;
    }
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Lógica de la detección del suelo 
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        //Lógica de ejecución de animaciones
        AnimationManagement();
        //Ejecución de la lógica del flip
        if (moveInput.x > 0 && !isFacingRight) Flip();
        if (moveInput.x < 0 && isFacingRight) Flip();
    }

    private void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
        playerRB.linearVelocity = new Vector2(moveInput.x * speed, playerRB.linearVelocity.y);
    }

    void Flip()
    {
        Vector3 currentScale = transform.localScale; //Almacenamos el valor scale actual
        currentScale.x *= -1;
        transform.localScale = currentScale; //A la scale ACTUAL 
        isFacingRight = !isFacingRight; //CAmbiar el bool al valor cntrario

    }
    void Jump()
    {
        playerRB.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        AudioManager.Instance.PlaySFX(3);
    }
    IEnumerator Attack()
    {
        anim.SetTrigger("Attacking");
        canAttack = false;
        float actualSpeed = speed;
        speed = 0;
        yield return new WaitForSeconds(0.8f);
        speed = actualSpeed;
        canAttack = true;
        yield return null;
    }

    void AnimationManagement()
    {
        //Gestión del cambio de animaciones: idle-jump-walk
        anim.SetBool("Jumping", !isGrounded);
        if(moveInput.x != 0) anim.SetBool("Running", true);
        else anim.SetBool("Running",false);

    }


    void ShootMagic()
    {
        //Llamar a un Instandiate de prefab de proyectil
      GameObject actualProyectile = Instantiate(proyectile, shootPosition.position, Quaternion.identity);
        Bullet bulletScript = actualProyectile.GetComponent<Bullet>();
      bulletScript.isFacingRight = isFacingRight;
      
    }
    #region Input 
    public void OnMovement(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded) Jump();
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded && canAttack) StartCoroutine(Attack());
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed) ShootMagic();

    }    
    #endregion
}
