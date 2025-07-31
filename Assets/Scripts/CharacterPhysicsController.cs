using UnityEngine;

public class CharacterPhysicsController : MonoBehaviour
{
    public float JumpForce = 5f;

    public float Speed = 5f;

    private Rigidbody2D RigidBody;

    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Walking
        float xInput = Input.GetAxis("Horizontal");
        RigidBody.linearVelocityX = xInput * Speed;

        //Jumping
        var feetCollider = transform.Find("FeetCollider");
        bool areFeetTouching = feetCollider.GetComponent<FeetCollisionDetection>().IsTouchingJumpSurface;
        if (Input.GetButtonDown("Jump") && areFeetTouching)
        {
            RigidBody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }

    }
}
