using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

namespace Scenes.TrafficLight
{
    public class CheckAnswer : MonoBehaviour
    {
        // オブジェクトの位置を取得するメソッド
        public GameObject popupWindow;
        public Text popupText;

        public void ObjectCheck()
        {
            // 各色のエリアとシグナルを格納する辞書
            var objects = new Dictionary<string, GameObject>();

            // FindObjectsOfTypeAllを使って特定の名前のオブジェクトを取得し辞書に追加
            foreach (var obj in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                if (obj.activeInHierarchy)
                {
                    switch (obj.name)
                    {
                        case "RedArea":
                        case "RedSignal":
                        case "YellowArea":
                        case "YellowSignal":
                        case "BlueArea":
                        case "BlueSignal":
                            objects[obj.name] = obj;
                            break;
                    }
                }
            }

            // 各色のペアについて座標の一致を確認
            var redCorrect = _CheckPair(objects, "RedArea", "RedSignal");
            var yellowCorrect = _CheckPair(objects, "YellowArea", "YellowSignal");
            var blueCorrect = _CheckPair(objects, "BlueArea", "BlueSignal");


            if (redCorrect && yellowCorrect && blueCorrect)
            {
                ShowPopup("正解です！");
                //return true;
            }
            else
            {
                ShowPopup("不正解です。");
                if (!redCorrect) Debug.Log("RedAreaとRedSignalの位置が一致していません。");
                if (!yellowCorrect) Debug.Log("YellowAreaとYellowSignalの位置が一致していません。");
                if (!blueCorrect) Debug.Log("BlueAreaとBlueSignalの位置が一致していません。");
                //return false;
            }
        }

        // オブジェクトペアの座標一致をチェックするヘルパー関数
        private static bool _CheckPair(Dictionary<string, GameObject> objects, string object1Name, string object2Name)
        {
            if (objects.TryGetValue(object1Name, out var object1) && objects.TryGetValue(object2Name, out var object2))
            {
                return object1.transform.position == object2.transform.position;
            }
            return false; // どちらかのオブジェクトが見つからない場合はfalse
        }

        private void ShowPopup(string message)
        {
            popupText.text = message;
            popupWindow.SetActive(true);
        }

        public void HidePopup()
        {
            popupWindow.SetActive(false);
        }
    }
}