using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchTitletoCrafting : MonoBehaviour
{
    public void SwitchSceneTitletoCraft()
    {
        SceneManager.LoadScene("CraftingScene", LoadSceneMode.Single);
    }
}