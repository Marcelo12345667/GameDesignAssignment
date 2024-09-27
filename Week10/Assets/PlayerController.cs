using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private int moveSpeed;

    public bool useTransformMovement;

    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundRayTransform;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private int numJumps;
    [SerializeField] private int jumpForce;
    private int jumpsLeft;
    private float jumpTimer;
    public SpriteRenderer sprite;

    public Animator animator;

    public AudioSource jump;
    public AudioSource land;
    public AudioSource boom;

    public bool altspawn;
    public GameObject spawnpoint1;
    public GameObject spawnpoint2;
    public Vector3 currentpoint;
    public int collectables;
    // Start is called before the first frame update
    void Start()
    {
        collectables = 0;
        altspawn = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        if(altspawn == true )
        {
            transform.position = spawnpoint2.transform.position;
        }
        currentpoint = spawnpoint1.transform.position;

    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.Linecast(transform.position, groundRayTransform.position, groundLayer);

        if (isGrounded == true && jumpTimer >= 0.5f)
        {
            animator.SetBool("isjumping", false);
            jumpsLeft = numJumps;
        }

        jumpTimer += Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        if (x < 0)
        {
            sprite.flipX = true;
        }
        if (x > 0)
        {
            sprite.flipX = false;
        }

        if (useTransformMovement == false)
        {
            rb.velocity = new Vector3(x * moveSpeed, rb.velocity.y, 0);
        }
        else
        {
            
            transform.position = new Vector3(transform.position.x + x * Time.deltaTime * moveSpeed, 
            transform.position.y, transform.position.z);
            animator.SetFloat("speed", Mathf.Abs(x));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            
            if (jumpsLeft > 0 && isGrounded == true)
            {
                jump.Play();
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector3.up * jumpForce);
                jumpsLeft--;
                jumpTimer = 0;
            }
        }
        if (isGrounded == false)
        {
            animator.SetBool("isjumping", true);

        }
        //animator.SetTrigger("isdead");
        //if(Input.GetKeyDown(KeyCode.P))
        {
            //transform.position = spawnpoint2.transform.position;
            //collectables = 2;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(_Reloadscene());
        }
    }
    public IEnumerator _Reloadscene() {
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(0.2f);
        //string currentSceneName = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(currentSceneName);
        transform.position = currentpoint;
    }
        
    
    public void SetMoveSpeed(int _moveSpeed)
    {
        moveSpeed = _moveSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            animator.SetTrigger("isdead");
            boom.Play();
            StartCoroutine(_Reloadscene());

            //Destroy(gameObject,0.18f);
            
            
        }
        if (collision.gameObject.CompareTag("newspawn"))
        {
            currentpoint = spawnpoint2.transform.position;
        }
        if (collision.gameObject.CompareTag("teleporter"))
        {
            StartCoroutine(_Reloadscene());
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("collectable"))
        {
            collectables = collectables + 1;
            Destroy(other.gameObject);
            //Debug.Log(collectables);
        }
        if (other.gameObject.CompareTag("finish"))
        {
            SceneManager.LoadScene("Endscene");
        }
    }
}
