using UnityEngine;

namespace Images.Objects
{
    public class Stay : MonoBehaviour
    {
        private void OnTriggerStay2D(Collider2D other)
        {
            // 吸い込む対象が DragAndDrop スクリプトを持っているか確認
            var dragAndDrop = other.GetComponent<DragAndDrop>();

            // 吸い込み条件のチェック
            if (dragAndDrop == null || dragAndDrop.boxFlag || dragAndDrop.IsReturning)
            {
                // 初期位置に戻る途中の場合、吸い込み処理をスキップ
                return;
            }

            // 吸い込み中のフラグを立てる
            dragAndDrop.IsBeingAbsorbed = true;

            // オブジェクトを吸い込み位置にスムーズに移動させる
            other.transform.position = Vector2.MoveTowards(
                other.transform.position,
                this.transform.position,
                5f * Time.deltaTime // 移動速度
            );

            // 吸い込み完了条件
            if (Vector2.Distance(other.transform.position, this.transform.position) < 0) // 微調整可能
            {
                dragAndDrop.boxFlag = true; // 対象の吸い込みフラグを設定
                dragAndDrop.IsBeingAbsorbed = false; // 吸い込み終了
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            // 吸い込み判定から離れた場合に吸い込み終了
            var dragAndDrop = other.GetComponent<DragAndDrop>();
            if (dragAndDrop != null)
            {
                dragAndDrop.IsBeingAbsorbed = false;
            }
        }
    }
}