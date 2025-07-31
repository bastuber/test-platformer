using UnityEngine;

public class DestroyOnEnemyTouch : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log($"Enemy {this.name} destroyed by {collision.gameObject.name} !");
            Destroy(gameObject);
        }
    }
}
