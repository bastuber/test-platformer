using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadSceneOnTouch : ActionOnTagTouch
{
    protected override void Action(Collision2D collision)
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
