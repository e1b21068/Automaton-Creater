using UnityEngine;

namespace Images.Objects
{
    public class Stay : MonoBehaviour
    {
        // �� �R���W�����ɓ������u�Ԃɋz�����݉\�����f
        private void OnTriggerEnter2D(Collider2D other)
        {
            var dragAndDrop = other.GetComponent<DragAndDrop>();
            if (dragAndDrop == null) return;

            // �h���b�O�Ŏ�����Ă��Ȃ� && �����ʒu�ɖ߂�Œ��łȂ� && ���łɋz�����܂�Ă��Ȃ�
            if (!dragAndDrop.boxFlag && !dragAndDrop.IsReturning && !dragAndDrop.IsBeingAbsorbed)
            {
                // �z�����݊J�n
                StartCoroutine(AbsorbObject(dragAndDrop));
            }
        }

        // �� �z�����݊����O�ɃR���W�����𔲂�����z�����ݏI��
        private void OnTriggerExit2D(Collider2D other)
        {
            var dragAndDrop = other.GetComponent<DragAndDrop>();
            if (dragAndDrop != null)
            {
                dragAndDrop.IsBeingAbsorbed = false;
            }
        }

        // �� �R���[�`���ŋz�����ݎ���
        private System.Collections.IEnumerator AbsorbObject(DragAndDrop dragAndDrop)
        {
            dragAndDrop.IsBeingAbsorbed = true;

            // ���S�ɋ߂Â���
            while (Vector3.Distance(dragAndDrop.transform.position, transform.position) > 0)
            {
                // �h���b�O����n�߂���z�����݃L�����Z��
                if (!dragAndDrop.IsBeingAbsorbed) yield break;

                dragAndDrop.transform.position = Vector3.MoveTowards(
                    dragAndDrop.transform.position,
                    transform.position,
                    10f * Time.deltaTime
                );

                yield return null;
            }

            // �z�����݊���
            dragAndDrop.boxFlag = true;
            dragAndDrop.IsBeingAbsorbed = false;
        }
    }
}