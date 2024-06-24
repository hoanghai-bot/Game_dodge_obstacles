using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private Rigidbody rb;
    private Animator anim;

    public float jumpForce;
    public float GravityModifier;

    public bool isOnGround = true;
    public bool gameOver = false;

    public ParticleSystem dirty;
    public ParticleSystem explosion;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource audio;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();  
        audio = GetComponent<AudioSource>();
        Physics.gravity *= GravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            anim.SetTrigger("Jump_trig");
            audio.PlayOneShot(jumpSound, 1f);
            dirty.Stop();
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true ;
            dirty.Play();
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true ;
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
            dirty.Stop();
            audio.PlayOneShot(crashSound, 1f);
            explosion.Play();
        }
    }
}
