using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float floorOverlapSphereRadius = 0.2f;

    [HideInInspector]
    public int jumpHeight;
    [HideInInspector]
    public float speed;
    public float rotateSpeed;

    private bool isMoving;
    private Animator anim;
    private bool isGrounded;
    private bool jump;
    private Rigidbody playerRigidbody;
    private int groundMask;//para el salto
    private Vector3 movement;
    private float previousRotationY;
    private AudioSource audioPlayer;


    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        groundMask = LayerMask.GetMask("Ground");
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;
        jumpHeight = 300;
        isGrounded = true;
        isMoving = false;
        previousRotationY = 185f;
        audioPlayer = GetComponent<AudioSource>();
        audioPlayer.panStereo = 0.2f;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");   //Si lo cambiamos por GetAxis, parece que derrapa (se desliza)
        float v = Input.GetAxisRaw("Vertical");

        /*if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jump = true;
        }*/

        //isMoving = Mathf.Abs(h) > 0 || Mathf.Abs(v) > 0;
        //anim.SetBool("moving", isMoving);

        Move(h, v);
        Turning(h, v);
        //Animating(h, v);

        /*isGrounded = Physics.OverlapSphere(transform.position, floorOverlapSphereRadius, groundMask).Length != 0 ? true : false;

        if (jump && isGrounded)
        {
            //anim.SetTrigger("jump");
            jump = false;
            playerRigidbody.AddForce(Vector3.up * jumpHeight);
        }*/
    }

    void Move(float h, float v)
    {
        movement.Set(h+v, 0f, v-h);

        movement = movement.normalized * speed * Time.deltaTime;

        if (movement.x != 0 || movement.z != 0)
        {
            anim.SetBool("Moving", true);

            if (!audioPlayer.isPlaying)
            {
                audioPlayer.volume = Random.Range(0.1f, 0.3f);
                audioPlayer.pitch = Random.Range(0.9f, 1.8f);
                if (audioPlayer.panStereo > 0)
                {
                    audioPlayer.panStereo = Random.Range(-0.5f, -0.1f);
                }

                else
                {
                    audioPlayer.panStereo = Random.Range(0.1f, 0.5f);
                }

                audioPlayer.Play();
            }
        }
            

        else
            anim.SetBool("Moving", false);
        

        //playerRigidbody.MovePosition(transform.position + movement);
        transform.position += movement;
    }

    void Turning (float h, float v)
    {
        //Rotation of the player
        if (h != 0 || v != 0)
        {
            transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(movement.x, 0f, movement.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
            previousRotationY = transform.rotation.eulerAngles.y;
        }

        else
        {
            transform.rotation = Quaternion.Euler(0f, previousRotationY, 0f);
        }
    }
}
