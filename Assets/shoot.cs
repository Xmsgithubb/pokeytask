
using UnityEngine;

public class shoot : MonoBehaviour
{
    public Rigidbody ball;
    public float shootpow = 1000f;
    public float gravity = -9.81f;
    Vector3 velocity;

    public Transform grdcheck;
    public float grddist = 0.4f;
    public LayerMask grdmask;
    
    
    bool isground;

    private float start, end;

    private void Start()
    {
        ball = GetComponent<Rigidbody>();
        start = 0f;
        end = 0f;
    }



    void Update()
    {


        ball.constraints = RigidbodyConstraints.FreezePositionX;
        ball.constraints = RigidbodyConstraints.FreezePositionZ;
        ball.constraints = RigidbodyConstraints.FreezeRotation;

        if (Input.GetMouseButtonDown(0))
        {
            start = Time.time;
        }

        if (Input.GetMouseButtonUp(0))
        {
            end = Time.time;
        }
        if (end - start > 0.5f)
        {
            ball.velocity = transform.up * shootpow;
            start = 0f;
            end = 0f;
        }
        
        velocity.y += gravity * Mathf.Pow (Time.deltaTime, 2);
        
        isground = Physics.CheckSphere(grdcheck.position, grddist, grdmask);
        if(isground && velocity.y <= 0)
        {
            velocity.y = -2f;
        }
    }


}
