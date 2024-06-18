using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovmentV2_0 : MonoBehaviour
{
    [SerializeField] private float Speed = 0.3f;
    [SerializeField] private float MaxSpeed = 5f;
    [SerializeField] private float JumpForce = 1f;

    private Vector3 moveVector;

    public UnityAction playerWalk;
    public UnityAction playerJump;
    public UnityAction playerDown;

    //даем возможность выбрать тэг пола.
    //так же убедитесь что ваш Player сам не относитс€ к даному слою. 

    //!!!!Ќацепите на него нестандартный Layer, например Player!!!!
    public LayerMask GroundLayer = 1; // 1 == "Default"

    private Rigidbody rb_object;
    private CapsuleCollider collider_object; // теперь прийдетс€ использовать CapsuleCollider
    //и удалите бокс коллайдер если он есть

    private bool jumpOn;

    private float timer = 0;
    private bool startTimer = false;

    [SerializeField] private Animator playerAnimator;

    private bool jump = false;

    void Start()
    {
        rb_object = GetComponent<Rigidbody>();
        collider_object = GetComponent<CapsuleCollider>();

        //т.к. нам не нужно что бы персонаж мог падать сам по-себе без нашего на то указани€.
        //то нужно заблочить поворот по ос€х X и Z
        rb_object.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;

        //  «ащита от дурака
        if (GroundLayer == gameObject.layer)
            Debug.LogError("Player SortingLayer must be different from Ground SourtingLayer!");

        playerAnimator.SetBool("Grounded", true);
    }


    private bool _isGrounded
    {
        get
        {
            var bottomCenterPoint = new Vector3(collider_object.bounds.center.x, collider_object.bounds.min.y, collider_object.bounds.center.z);

            //создаем невидимую физическую капсулу и провер€ем не пересекает ли она обьект который относитс€ к полу

            //_collider.bounds.size.x / 2 * 0.9f -- эта странна€ конструкци€ берет радиус обьекта.
            // был бы об€зательно сферой -- бралс€ бы радиус напр€мую, а так пишем по-универсальнее

            return Physics.CheckCapsule(collider_object.bounds.center, bottomCenterPoint, collider_object.bounds.size.x / 2 * 0.9f, GroundLayer);
            // если можно будет прыгать в воздухе, то нужно будет изменить коэфициент 0.9 на меньший.
        }
    }

    void FixedUpdate()
    {
        JumpLogic();
        MoveLogic();
        gravityJump();

        if(jumpOn == false || rb_object.velocity.y == 0)
        {
            defaultGravity();
        }        

        if (startTimer == true)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
        }

        if(_isGrounded == true)
        {
            startTimer = false;
            playerAnimator.SetBool("Grounded", true);
        }
        else
        {
            startTimer = true;
            jump = true;
            playerAnimator.SetBool("Grounded", false);
        }
    }

    private void MoveLogic()
    {

        if (rb_object.velocity.magnitude >= MaxSpeed) return;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            rb_object.velocity = transform.forward * Input.GetAxis("Vertical");
            rb_object.velocity = rb_object.velocity * 4;

            if(_isGrounded == true)
            {
                playerWalk?.Invoke();
            }
        }
        else
        {
            if(Input.GetKey(KeyCode.S))
            {
                rb_object.velocity = transform.forward * Input.GetAxis("Vertical") * 0f;
            }   
        }
        
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -2, 0);

            if(Input.GetKey(KeyCode.W) == false)
            {
                playerAnimator.SetFloat("MoveSpeed", 0.2f);
                return;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, +2, 0);
            if (Input.GetKey(KeyCode.W) == false)
            {
                playerAnimator.SetFloat("MoveSpeed", 0.2f);
                return;
            }
        }

        if((Input.GetKey("a") == false && Input.GetKey("d") == false))
        {
            transform.Rotate(0, 0, 0);
        }

        rb_object.AddForce(moveVector * Speed, ForceMode.Impulse);

        playerAnimator.SetFloat("MoveSpeed", (rb_object.velocity.magnitude / MaxSpeed));
    }

    private void JumpLogic()
    {
        if (_isGrounded && (Input.GetAxis("Jump") > 0))
        {
            if (jumpOn == false)
            {
                playerJump?.Invoke();
                jumpOn = true;
                rb_object.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        
        if (jump == true)
        {
            if (collision.gameObject.tag != "Roof" && collision.gameObject.tag != "Cut")
            {
                playerDown?.Invoke();
            }
            
            jump = false;
        }
        jumpOn = false;
        startTimer = false;
        
    }

    private void gravityJump()
    {
        if (timer >= 0.3f && Input.GetKey(KeyCode.W) || timer >= 0.3f && Input.GetKey(KeyCode.S))
        {
            rb_object.AddForce(0f, -100f, 0f);
        }
        else
        {
            if(timer >= 0.3f)
            {
                rb_object.AddForce(0f, -20f, 0f);
            }
        }
    }

    private void defaultGravity()
    {
        rb_object.AddForce(0f, -50f, 0f);
    }
}
