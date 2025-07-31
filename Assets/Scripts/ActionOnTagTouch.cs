using UnityEngine;

public class ActionOnTagTouch : MonoBehaviour
{
    public string Tag;

    protected virtual void Action(Collision2D collision)
    {
        Debug.LogWarning($"ActionOnTagTouch action not implemented for {gameObject.name}");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == Tag)
        {
            Action(collision);
        }
    }
}
