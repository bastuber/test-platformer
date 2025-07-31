using UnityEngine;
using UnityEngine.SceneManagement;

public class KillBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kill player if touching
        if (collision.gameObject.tag == "Player")
        {
            // kill player!
            var currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
