using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight;

    public Transform groundCheck;
    public float sphereRadius = 0.4f;
    public LayerMask groundMask;
    public int nrOfAlowedDJumps = 1;
    public int dJumpCounter = 0;

    Vector3 velocity;
    bool isGrounded;
    Vector3 moveDirection = Vector3.zero;
     

    public Text ScoreText;
    public int theScore;

    public float jumpPadStrength;

    public AudioSource collectSound;


    private void Start()
    {
        ScoreText = ScoreText.GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
     

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);


        //jumping
        // if (Input.GetKey(KeyCode.Space) && isGrounded)
        // {
        //     velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        //  }
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                dJumpCounter = 0;
            }
            if (!isGrounded && dJumpCounter < nrOfAlowedDJumps)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                dJumpCounter++;
            }
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }


    //food collector
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "food")
        {
            collectSound.Play();
            theScore += 50;
            ScoreText.text = "SCORE: " + theScore;
            Destroy(other.gameObject);
            Debug.Log(theScore);
        }

        //jumppad
        if (other.tag == "JumpPad")
        {
            velocity.y = Mathf.Sqrt(jumpPadStrength * -2f * gravity);
            Debug.Log("YEET");
        }
    }

}
