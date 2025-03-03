using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using System;
using Unity.Mathematics;
using UnityEngine.Audio;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float minLimit;
    [SerializeField] private float maxLimit;
    [SerializeField] private float gravity;
    [SerializeField] private float impulse; //afeta vel em y
    private float x;
    private bool isPressed; //controle de bug: não andar com ambas as teclas pressionadas, nao ultrapassar o limite para x
    private bool isGrounded; //not jumping //componente que pega box collider do ground
    private float ground;
    private float yVel;

    private bool facingRight = true;
    // private Rigidbody2D rb;
    private Animator animator;

    private AudioManagerController audioManager;

    //private void Awake()
    //  {
    //    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerController>();
    //}

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerController>();
        isPressed = false;
        isGrounded = true;
        ground = transform.position.y;
        yVel = 0;

        animator = GetComponent<Animator>();
    }

    void Update() //rb.velocity = dx 
    {
        x = transform.position.x;
        float dx = Input.GetAxis("Horizontal") * speed;//pego informações para deslocamento em x

        if (facingRight && dx < 0f || !facingRight && dx > 0f)
        {

            facingRight = !facingRight;
            FlipSprite();
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))//checo a cada frame se está sendo pressionado ao mesmo tempo
            isPressed = true;

        else
            isPressed = false;

        float newX = transform.position.x + dx * Time.deltaTime;

        if (newX <= minLimit || newX >= maxLimit)
            dx = 0;

        if (!isPressed)
        {
            if (x > minLimit && x < maxLimit)
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) && isGrounded)
                {
                    audioManager.Walk();
                }

                if (Input.GetKey(KeyCode.A))
                {
                    transform.Translate(dx * Time.deltaTime, 0, 0);
                } // retorna -1
                if (Input.GetKey(KeyCode.D))
                {
                    transform.Translate(dx * Time.deltaTime, 0, 0);
                } //retorna 1
            }
        }

        if (!isGrounded) //is jumping //isgrounded = false : meio do pulo
        {
            audioManager.StopWalk();
            if (transform.position.y <= ground) //acabou o pulo
            {
                transform.position = new Vector3(transform.position.x, ground, 0);
                isGrounded = true;
                yVel = 0; //dy=0 //idle
                animator.SetFloat("yVelocity", yVel);
            }
            else
            {
                yVel -= gravity * Time.deltaTime; //cair mais rápido  //fall
                animator.SetBool("isJumping", isGrounded); //isgrounded = false : 
            }
        }

        else //isgrounded = true
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVel = impulse;
                isGrounded = false;
                audioManager.PlaySFX(audioManager.jump);
                animator.SetBool("isJumping", !isGrounded); // !isGrounded = true
            }
        }

        float dy = yVel * Time.deltaTime;

        transform.Translate(dx * Time.deltaTime, dy, 0);

        animator.SetFloat("xVelocity", Math.Abs(dx)); //animator com a mesma vel do player
        Debug.Log("x vel: " + animator.GetFloat("xVelocity"));
        animator.SetFloat("yVelocity", yVel); //passo vel de y ao animator (checagem se foi para pos ou negativo dentro do animator unity)
        //walk : positivo
        //idle: zero
        //vel de x é negativa ao ir à esq : math.abs

        //enemys spawners ok
        //mov camera ok
        //colisao ok
        //hud : score e highestScore , teclas de movimento
        //cenas
        //audio
        // parallax com chão, e background ok
        //sistema de score aparecendo em tela
        //telas de inicio e de score ao final da partida, comparando com outras jogadas prévias.
        //animação personagem ok 
    }

    void FlipSprite()
    {
        Vector3 ls = transform.localScale; //escala local
        ls.x *= -1f;
        transform.localScale = ls;
    }

    void OnTriggerEnter2D(Collider2D collider) //trigger de ground é disparado
    {
        if (collider.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", !isGrounded);
        }
    }


}
