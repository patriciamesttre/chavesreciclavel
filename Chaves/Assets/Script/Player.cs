using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float forcejump;
    public static float playerY, playerX;
    int ponto;
    public Text placar;
    AudioSource audio;
    

    bool groundCheck;

    SpriteRenderer player;
    Animator animacao;

    public Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        player = GetComponent<SpriteRenderer>();
        animacao = GetComponent<Animator>();
        body = gameObject.GetComponent<Rigidbody2D>();
        groundCheck = true;
        ponto = 0;
    }

    // Update is called once per frame
    void Update()
    {
        placar.text = ponto.ToString();
        playerX = transform.position.x;
        playerY = transform.position.y;

        if ((Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.RightArrow)))
        {
            animacao.SetBool("move", true);
        }

        else
        {
            animacao.SetBool("move", false);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(Vector3.right * 0.05f);
            player.flipX = false;
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(Vector3.left * 0.05f);
            player.flipX = true;
        }

        if(Input.GetButtonDown("Jump") && groundCheck == true)
        {
            groundCheck = false;
            body.AddForce(new Vector2(0, forcejump));
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "recicle")
        {
            audio.Play();
            Destroy(collision.gameObject);
            ponto = ponto + 1;
            if(ponto >= 13)
            {
                SceneManager.LoadScene("venceu");
             
            }
        }

        if (collision.gameObject.tag == "barril")
        {
            Destroy(this.gameObject);
            print("Game Over!");
            SceneManager.LoadScene("gameover");
        }

        if (collision.gameObject.tag == "bee")
        {
            Destroy(this.gameObject);
            print("Game Over!");
            SceneManager.LoadScene("gameover");

        }

        if (collision.gameObject.tag == "chao")
        {
            groundCheck = true;
        }

    }
}
