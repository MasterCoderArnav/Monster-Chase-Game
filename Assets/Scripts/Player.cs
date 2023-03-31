using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10.0f;
    [SerializeField]
    private float jumpForce = 11.0f;

    private float movementX;

    private Rigidbody2D myBody;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    private SpriteRenderer sr;

    private bool isGrounded = true;

    string groundTag = "Ground";

    private string enemyTag = "Enemy";

    // Start is called before the first frame update

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr= GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        animatePlayer();
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump")&&isGrounded){
            myBody.AddForce(new Vector2(0.0f, jumpForce), ForceMode2D.Impulse);
            isGrounded= false;
        }
    }

    void PlayerMoveKeyboard(){
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0.0f, 0.0f) * Time.deltaTime * moveForce;
    }

    void animatePlayer()
    {
        if (movementX > 0) {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX < 0){
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else{
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
        {
            isGrounded = true;
            Debug.Log("We landed on Ground");
        }
        else if (collision.gameObject.CompareTag(enemyTag))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag))
        {
            Destroy(gameObject);
        }
    }
}
