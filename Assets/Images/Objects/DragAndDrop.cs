using UnityEngine;

namespace Images.Objects
{
    public class DragAndDrop : MonoBehaviour
    {
        public bool boxFlag; // true で吸い込み済みとなる
        private Vector3 _offset;
        private bool _isDragging;

        public bool IsBeingAbsorbed { get; set; }
        public bool IsReturning { get; private set; }

        private Vector3 InitialPosition { get; set; }

        private void Start()
        {
            InitialPosition = transform.position;
        }

        private void OnMouseDown()
        {
            // ドラッグ開始時に明示的にリセット
            boxFlag = false;
            IsReturning = false;
            IsBeingAbsorbed = false;

            _offset = transform.position - GetMouseWorldPos();
            _isDragging = true;
        }

        private void OnMouseDrag()
        {
            if (_isDragging)
            {
                transform.position = GetMouseWorldPos() + _offset;
            }
        }

        private void OnMouseUp()
        {
            _isDragging = false;
        }

        private Vector3 GetMouseWorldPos()
        {
            var mousePoint = Input.mousePosition;

            if (Camera.main == null)
            {
                Debug.LogError(
                    "Main camera is not found. Please ensure a camera with the 'MainCamera' tag is present in the scene."
                );
                return Vector3.zero;
            }

            mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;
            return Camera.main.ScreenToWorldPoint(mousePoint);
        }

        private void Update()
        {
            // 吸い込まれていない、かつドラッグ中でないなら初期位置へ戻す
            if (!boxFlag && !IsBeingAbsorbed && !_isDragging)
            {
                ReturnToInitialPosition();
            }
        }

        private void ReturnToInitialPosition()
        {
            if (boxFlag || IsBeingAbsorbed) return;

            IsReturning = true;

            transform.position = Vector3.MoveTowards(
                transform.position,
                InitialPosition,
                10f * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, InitialPosition) < 0.01f)
            {
                IsReturning = false;
            }
        }
    }
}
