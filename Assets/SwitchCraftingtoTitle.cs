using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchCraftingtoTitle : MonoBehaviour
{
    public void SwitchSceneCrafttoTitle()
    {
        SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
    }
}
