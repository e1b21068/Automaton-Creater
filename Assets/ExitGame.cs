using UnityEngine;

public class ExitGame: MonoBehaviour
{
    public void ExitGameMode()
    {
    //if UNITY_EDITOR
        // Unity�G�f�B�^�[���ł̓���
        UnityEditor.EditorApplication.isPlaying = false;
    //else
        // �r���h���ꂽ�A�v���P�[�V�����̓���
        Application.Quit();
    //endif
    }
}
