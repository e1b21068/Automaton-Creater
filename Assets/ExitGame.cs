using UnityEngine;

public class ExitGame: MonoBehaviour
{
    public void ExitGameMode()
    {
    //if UNITY_EDITOR
        // Unityエディター内での動作
        UnityEditor.EditorApplication.isPlaying = false;
    //else
        // ビルドされたアプリケーションの動作
        Application.Quit();
    //endif
    }
}
