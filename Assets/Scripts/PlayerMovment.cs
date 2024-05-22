using UnityEngine;

//эти строчки гарантирют что наш скрипт не завалитс€ если на плеере будет отсутствовать нужные компоненты
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float Speed = 0.3f;
    [SerializeField] private float MaxSpeed = 5f;
    [SerializeField] private float JumpForce = 1f;


    private Vector3 moveVector;

    //даем возможность выбрать тэг пола.
    //так же убедитесь что ваш Player сам не относитс€ к даному слою. 

    //!!!!Ќацепите на него нестандартный Layer, например Player!!!!
    public LayerMask GroundLayer = 1; // 1 == "Default"

    private Rigidbody rb_object;
    private CapsuleCollider collider_object; // теперь прийдетс€ использовать CapsuleCollider
    //и удалите бокс коллайдер если он есть

    private bool jumpOn;

    [SerializeField] private Animator playerAnimator;

    void Start()
    {
        rb_object = GetComponent<Rigidbody>();
        collider_object = GetComponent<CapsuleCollider>();

        //т.к. нам не нужно что бы персонаж мог падать сам по-себе без нашего на то указани€.
        //то нужно заблочить поворот по ос€х X и Z
        rb_object.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

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

    /*
    private Vector3 movementVector
    {
        get
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            return new Vector3(horizontal, 0.0f, vertical);
        }
    }
    */


    void FixedUpdate()
    {
        JumpLogic();
        MoveLogic();
        
        transform.Rotate(Vector3.up, rotateLogic(transform.forward, moveVector, transform.right));
    }

    private void MoveLogic()
    {
        /*
        // т.к. мы сейчас решили использовать физическое движение снова,
        // мы убрали и множитель Time.fixedDeltaTime
        rb_object.AddForce(movementVector * Speed, ForceMode.Impulse);
        */
        if (rb_object.velocity.magnitude >= MaxSpeed) return;
        
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.z = Input.GetAxis("Vertical");

        

        rb_object.AddForce(moveVector * Speed,ForceMode.Impulse);
        //Debug.Log(rb_object.velocity.magnitude);

        
        playerAnimator.SetFloat("MoveSpeed", (rb_object.velocity.magnitude / MaxSpeed));

        Debug.Log(rb_object.velocity.magnitude);
    }

    private void JumpLogic()
    {
        //Debug.Log(Input.GetAxis("Jump"));

        if (_isGrounded && (Input.GetAxis("Jump") > 0))
        {
            if(jumpOn == false)
            {
                rb_object.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
                playerAnimator.SetBool("Grounded", false);
                jumpOn = true;
            }
            
        }
    }

    
    private float rotateLogic(Vector3 from, Vector3 to, Vector3 right)
    {  
        float angle = Vector3.Angle(from, to);
        return (Vector3.Angle(right, to) > 90f) ? 360f - angle : angle;
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerAnimator.SetBool("Grounded", true);
        jumpOn = false;
    }
}
