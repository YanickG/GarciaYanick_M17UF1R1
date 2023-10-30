using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharAnimations : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    private GameObject _entrance;
    private GameObject _exit;

    public bool LvlChange = false;


    //Detecta si avanzas o retrocedes entre niveles.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enter"))
        {
            LvlChange = true;
        }
        else if (collision.gameObject.CompareTag("Return"))
        {
            LvlChange = false;
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        //Cogemos los elementos declarados previamente para poder usarlos ahora.
        _animator = GetComponent<Animator>();

        //Estas dos líneas se encargan de hacer aparecer el personaje en un punto concreto que tengamos colocado en el nuevo nivel
        // en caso de que haya un elemento de este tipo.
        _entrance = GameObject.Find("Advance");
        _exit = GameObject.Find("BackTo");

        //Transporta el objeto al punto indicado
        if (LvlChange)
        {
            gameObject.transform.position = _entrance.transform.position;
        }
        else
        {
            gameObject.transform.position = _exit.transform.position;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        //Ataque básico
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _rb.velocity = new Vector2(0, 0);
            _animator.SetBool("isAttacking1", true);
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            _rb.velocity = Vector2.zero;
            _animator.SetBool("isAttacking1", false);
        }

        //Ataque secundario
        if (Input.GetKeyDown(KeyCode.X))
        {
            _rb.velocity = new Vector2(0, 0);
            _animator.SetBool("isAttacking2", true);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            _rb.velocity = Vector2.zero;
            _animator.SetBool("isAttacking2", false);
        }

        //Mover derecha
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _rb.velocity = new Vector2(20, 0);
            _sr.flipX = false;
            _animator.SetBool("isRunning", true);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _rb.velocity = Vector2.zero;
            _animator.SetBool("isRunning", false);
        }

        //Mover izquierda
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _rb.velocity = new Vector2(-20, 0);
            _sr.flipX = true;
            _animator.SetBool("isRunning", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _rb.velocity = Vector2.zero;
            _animator.SetBool("isRunning", false);
        }

        //Saltar
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _rb.gravityScale = -10;
            _sr.flipY = true;
            _animator.SetBool("isJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _rb.gravityScale = 10;
            _sr.flipY = false;
            _animator.SetBool("isJumping", true);
        }
    }
}
