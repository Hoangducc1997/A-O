    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;
    using UnityEngine.InputSystem;

    public class Player : MonoBehaviour
    {

        PlayerControl controls;
        private float direction = 0;

        [SerializeField] public float speed = 1f;
        private bool isFacingRight = true;

        [SerializeField] public bool isGrounded;
        [SerializeField] public int numberOfJumps = 0;

        [SerializeField] public Transform groundCheck;
        [SerializeField] public LayerMask groundLayer;

        [SerializeField] public float jumpForce = 1f;
        [SerializeField] public Rigidbody2D playerRB;

        [SerializeField] public Animator animator;

    
        private bool isMoving => Mathf.Abs(direction) > 0.1f;

        private void Awake()
        {
            //Hàm di chuyển player
            controls = new PlayerControl();
            controls.Enable();

            controls.Land.Move.performed += ctx =>
            {
                direction = ctx.ReadValue<float>();
            };
            controls.Land.Jump.performed += ctx => Jump();
            controls.Land.Kick.performed += ctx => Kick();

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
            animator.SetBool("isGrounded", isGrounded);
            playerRB.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);
            animator.SetFloat("speed", Mathf.Abs(direction));

            animator.SetInteger("numberOfJumps", numberOfJumps);

 

            if (isFacingRight && direction < 0 || !isFacingRight && direction > 0)
                Flip();

            // Check if the player is moving and is grounded to play the running sound
            //if (isMoving && isGrounded)
            //{
            //    AudioManager.Instance.PlaySFX("Running");
            //}
        }
        private void Flip() //Xoay Player
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        }

        private void Kick()
        {
            AudioManager.Instance.PlaySFX("Kicking");
            if (playerRB != null)   animator.SetTrigger("PlayerKick");
        }

        private void Jump()
        {
            AudioManager.Instance.PlaySFX("Jumping");

            if (isGrounded && playerRB != null)  // Kiểm tra playerRB không null trước khi sử dụng
            {
                numberOfJumps = 0;
            
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                numberOfJumps++;
            }
            else
            {
                if (numberOfJumps == 1 && playerRB != null)  // Kiểm tra playerRB không null trước khi sử dụng
                {
                    playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                    numberOfJumps++;
                }
            }
        }

        //Active Start and Finish Checkpoint 
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("StartCheckpoint"))
            {
                Animator checkpointAnimator = other.GetComponent<Animator>();
                checkpointAnimator.SetBool("Start", true);
            }
            else if (other.CompareTag("FinishCheckpoint"))
            {
                AudioManager.Instance.PlaySFX("Finish");
                Animator checkpointAnimator = other.GetComponent<Animator>();
                checkpointAnimator.SetBool("Finish", true);
            }
            else if (other.CompareTag("Coin"))
            {
                Destroy(other.gameObject);
            }
            else if (other.CompareTag("Diamond"))
            {
                Destroy(other.gameObject);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("StartCheckpoint"))
            {
                AudioManager.Instance.PlaySFX("Start");
                Animator checkpointAnimator = collision.GetComponent<Animator>();
                checkpointAnimator.SetBool("Start", false);
            }
            else if(collision.CompareTag("FinishCheckpoint"))
            {
                Animator checkpointAnimator = collision.GetComponent<Animator>();
                checkpointAnimator.SetBool("Finish", false);
            }
        }
    }

