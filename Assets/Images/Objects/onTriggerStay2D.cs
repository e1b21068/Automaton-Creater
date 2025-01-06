using UnityEngine;

namespace Images.Objects
{
    public class Stay : MonoBehaviour
    {
        private void OnTriggerStay2D(Collider2D other)
        {
            // �z�����ޑΏۂ� DragAndDrop �X�N���v�g�������Ă��邩�m�F
            var dragAndDrop = other.GetComponent<DragAndDrop>();

            // �z�����ݏ����̃`�F�b�N
            if (dragAndDrop == null || dragAndDrop.boxFlag || dragAndDrop.IsReturning)
            {
                // �����ʒu�ɖ߂�r���̏ꍇ�A�z�����ݏ������X�L�b�v
                return;
            }

            // �z�����ݒ��̃t���O�𗧂Ă�
            dragAndDrop.IsBeingAbsorbed = true;

            // �I�u�W�F�N�g���z�����݈ʒu�ɃX���[�Y�Ɉړ�������
            other.transform.position = Vector2.MoveTowards(
                other.transform.position,
                this.transform.position,
                5f * Time.deltaTime // �ړ����x
            );

            // �z�����݊�������
            if (Vector2.Distance(other.transform.position, this.transform.position) < 0) // �������\
            {
                dragAndDrop.boxFlag = true; // �Ώۂ̋z�����݃t���O��ݒ�
                dragAndDrop.IsBeingAbsorbed = false; // �z�����ݏI��
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            // �z�����ݔ��肩�痣�ꂽ�ꍇ�ɋz�����ݏI��
            var dragAndDrop = other.GetComponent<DragAndDrop>();
            if (dragAndDrop != null)
            {
                dragAndDrop.IsBeingAbsorbed = false;
            }
        }
    }
}