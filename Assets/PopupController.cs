using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    public GameObject popupPanel;  // パネルのGameObject
    public Text popupText;         // テキストの参照
    public Image popupImage;       // 画像の参照
    public Button popupButton;     // ボタンの参照

    // ポップアップを開くメソッド
    public void OpenPopup(string message, Sprite imageSprite, string buttonText)
    {
        popupText.text = message;
        popupImage.sprite = imageSprite;
        popupButton.GetComponentInChildren<Text>().text = buttonText;
        popupPanel.SetActive(true);  // ポップアップパネルを表示
    }

    // ポップアップを閉じるメソッド
    public void ClosePopup()
    {
        popupPanel.SetActive(false); // ポップアップパネルを非表示
    }
}
