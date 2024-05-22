using UnityEngine;

//��� ������� ���������� ��� ��� ������ �� ��������� ���� �� ������ ����� ������������� ������ ����������
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float Speed = 0.3f;
    [SerializeField] private float MaxSpeed = 5f;
    [SerializeField] private float JumpForce = 1f;


    private Vector3 moveVector;

    //���� ����������� ������� ��� ����.
    //��� �� ��������� ��� ��� Player ��� �� ��������� � ������ ����. 

    //!!!!�������� �� ���� ������������� Layer, �������� Player!!!!
    public LayerMask GroundLayer = 1; // 1 == "Default"

    private Rigidbody rb_object;
    private CapsuleCollider collider_object; // ������ ��������� ������������ CapsuleCollider
    //� ������� ���� ��������� ���� �� ����

    private bool jumpOn;

    [SerializeField] private Animator playerAnimator;

    void Start()
    {
        rb_object = GetComponent<Rigidbody>();
        collider_object = GetComponent<CapsuleCollider>();

        //�.�. ��� �� ����� ��� �� �������� ��� ������ ��� ��-���� ��� ������ �� �� ��������.
        //�� ����� ��������� ������� �� ���� X � Z
        rb_object.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        //  ������ �� ������
        if (GroundLayer == gameObject.layer)
            Debug.LogError("Player SortingLayer must be different from Ground SourtingLayer!");

        playerAnimator.SetBool("Grounded", true);
    }


    private bool _isGrounded
    {
        get
        {
            var bottomCenterPoint = new Vector3(collider_object.bounds.center.x, collider_object.bounds.min.y, collider_object.bounds.center.z);

            //������� ��������� ���������� ������� � ��������� �� ���������� �� ��� ������ ������� ��������� � ����

            //_collider.bounds.size.x / 2 * 0.9f -- ��� �������� ����������� ����� ������ �������.
            // ��� �� ����������� ������ -- ������ �� ������ ��������, � ��� ����� ��-�������������

            return Physics.CheckCapsule(collider_object.bounds.center, bottomCenterPoint, collider_object.bounds.size.x / 2 * 0.9f, GroundLayer);
            // ���� ����� ����� ������� � �������, �� ����� ����� �������� ���������� 0.9 �� �������.
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
        // �.�. �� ������ ������ ������������ ���������� �������� �����,
        // �� ������ � ��������� Time.fixedDeltaTime
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
