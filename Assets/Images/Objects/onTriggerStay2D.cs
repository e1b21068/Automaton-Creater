using UnityEngine;

namespace Images.Objects
{
    public class Stay : MonoBehaviour
    {
        // ★ コリジョンに入った瞬間に吸い込み可能か判断
        private void OnTriggerEnter2D(Collider2D other)
        {
            var dragAndDrop = other.GetComponent<DragAndDrop>();
            if (dragAndDrop == null) return;

            // ドラッグで持たれていない && 初期位置に戻る最中でない && すでに吸い込まれていない
            if (!dragAndDrop.boxFlag && !dragAndDrop.IsReturning && !dragAndDrop.IsBeingAbsorbed)
            {
                // 吸い込み開始
                StartCoroutine(AbsorbObject(dragAndDrop));
            }
        }

        // ★ 吸い込み完了前にコリジョンを抜けたら吸い込み終了
        private void OnTriggerExit2D(Collider2D other)
        {
            var dragAndDrop = other.GetComponent<DragAndDrop>();
            if (dragAndDrop != null)
            {
                dragAndDrop.IsBeingAbsorbed = false;
            }
        }

        // ★ コルーチンで吸い込み実装
        private System.Collections.IEnumerator AbsorbObject(DragAndDrop dragAndDrop)
        {
            dragAndDrop.IsBeingAbsorbed = true;

            // 中心に近づける
            while (Vector3.Distance(dragAndDrop.transform.position, transform.position) > 0)
            {
                // ドラッグされ始めたら吸い込みキャンセル
                if (!dragAndDrop.IsBeingAbsorbed) yield break;

                dragAndDrop.transform.position = Vector3.MoveTowards(
                    dragAndDrop.transform.position,
                    transform.position,
                    10f * Time.deltaTime
                );

                yield return null;
            }

            // 吸い込み完了
            dragAndDrop.boxFlag = true;
            dragAndDrop.IsBeingAbsorbed = false;
        }
    }
}