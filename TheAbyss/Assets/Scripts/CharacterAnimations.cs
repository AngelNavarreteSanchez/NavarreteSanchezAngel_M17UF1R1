using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterAnimations : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    private Transform _tr;
    public SoundManagerScript soundManager;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    // Start is called before the first frame update
    void Awake()
    {

        _animator = gameObject.GetComponent<Animator>();
        _rb= GetComponent<Rigidbody2D>();
        _sr= GetComponent<SpriteRenderer>();
        _tr = GetComponent<Transform>();
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManagerScript>();

    }

    // Update is called once per frame
    void Update()
    {
        //Personaje Ataca
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _animator.SetBool("isAttacking", true);
            soundManager.PlaySFX(soundManager.attack);
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            _animator.SetBool("isAttacking", false);
        }
        //Personaje se mueve a la derecha
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            _rb.velocity = new Vector2(4, 0);
            _animator.SetBool("isRunning", true);
            _sr.flipX = false;

        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            _rb.velocity = Vector2.zero;
            _animator.SetBool("isRunning", false);

        }
        //Personaje se mueve a la izquierda
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            _rb.velocity = new Vector2(-4, 0);
            _sr.flipX = true;
            _animator.SetBool("isRunning", true);

        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            _rb.velocity = Vector2.zero;
            _animator.SetBool("isRunning", false);

        }
        //Esquive
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_sr.flipX == true)
            {
                _rb.velocity = new Vector2(-4, 0);
            }
            else if (_sr.flipX == false)
            {
                _rb.velocity = new Vector2(4, 0);
            }
            _animator.SetBool("isRolling", true);

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _rb.velocity = Vector2.zero;
            _animator.SetBool("isRolling", false);
        }
        //Mecanica cambio gravedad
        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            //_sr.flipY = true;
            if (_tr.rotation.x == 0 || _tr.rotation.x !=1)
            {
                _tr.Rotate(0, 180, 180);
                _rb.gravityScale = -4; 
                //Debug.Log(_tr.rotation.x);

            }


        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && IsGrounded())
        {

            if (_tr.rotation.x == 1)
           {
                //_sr.flipY = false;
                _tr.Rotate(0, 180, 180);
                _rb.gravityScale = 4;
                //Debug.Log(_tr.rotation.x);
            }
            
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }
}
/* if (DoNotDestroyObjects.instance != null)
 {
     transform.position = DoNotDestroyObjects.instance.SpawnLocation;
 }*/