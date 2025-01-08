using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    public GameObject popupPanel;  // �p�l����GameObject
    public Text popupText;         // �e�L�X�g�̎Q��
    public Image popupImage;       // �摜�̎Q��
    public Button popupButton;     // �{�^���̎Q��

    // �|�b�v�A�b�v���J�����\�b�h
    public void OpenPopup(string message, Sprite imageSprite, string buttonText)
    {
        popupText.text = message;
        popupImage.sprite = imageSprite;
        popupButton.GetComponentInChildren<Text>().text = buttonText;
        popupPanel.SetActive(true);  // �|�b�v�A�b�v�p�l����\��
    }

    // �|�b�v�A�b�v����郁�\�b�h
    public void ClosePopup()
    {
        popupPanel.SetActive(false); // �|�b�v�A�b�v�p�l�����\��
    }
}
