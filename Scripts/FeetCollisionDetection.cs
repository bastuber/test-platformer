using UnityEngine;

public class FeetCollisionDetection : MonoBehaviour
{
    public bool IsTouchingJumpSurface { private set; get; } = false;

    private void FixedUpdate()
    {
        IsTouchingJumpSurface = false;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == null)
            return;

        string otherTag = collision.gameObject.tag;
        if (otherTag == "Terrain"
            || otherTag == "Platform")
        {
            IsTouchingJumpSurface = true;
        }
    }

}
