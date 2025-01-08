using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryScene : MonoBehaviour
{
    public void RetryCurrentScene()
    {
        // 現在のシーンを再ロード
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
