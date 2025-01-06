using UnityEngine;

namespace Images.Objects
{
    public class DragAndDrop : MonoBehaviour
    {
        public bool boxFlag; // true で吸い込み済みとなる
        private Vector3 _offset;
        private bool _isDragging;

        // 吸い込まれている状態を示すフラグ
        public bool IsBeingAbsorbed { get; set; }

        // 初期位置に戻る途中かどうかを示すフラグ
        public bool IsReturning { get; private set; }

        // 初期位置を保存するための変数
        private Vector3 InitialPosition { get; set; }

        private void Start()
        {
            // 初期位置を保存
            InitialPosition = transform.position;
        }

        private void OnMouseDown()
        {
            // ドラッグ開始時に boxFlag を解除
            boxFlag = false;
            IsReturning = false; // 戻る状態を解除
            // マウスによるドラッグの移動開始
            _offset = transform.position - GetMouseWorldPos();
            _isDragging = true;
        }

        private void OnMouseDrag()
        {
            // ドラッグ中オブジェクトをマウスに追従させる
            if (_isDragging)
            {
                transform.position = GetMouseWorldPos() + _offset;
            }
        }

        private void OnMouseUp()
        {
            // ドラッグ終了
            _isDragging = false;
        }

        private Vector3 GetMouseWorldPos()
        {
            // マウス位置をワールド座標に変換
            var mousePoint = Input.mousePosition;

            if (Camera.main == null)
            {
                Debug.LogError(
                    "Main camera is not found. Please ensure a camera with the 'MainCamera' tag is present in the scene.");
                return Vector3.zero;
            }

            mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z; // 深度
            return Camera.main.ScreenToWorldPoint(mousePoint);
        }

        private void Update()
        {
            // 吸い込まれていない、かつドラッグ中でない場合は初期位置に戻す
            if (!boxFlag && !IsBeingAbsorbed && !_isDragging)
            {
                ReturnToInitialPosition();
            }
        }

        private void ReturnToInitialPosition()
        {
            if (boxFlag || IsBeingAbsorbed)
            {
                // 吸い込まれている最中であれば、初期位置に戻らない
                return;
            }

            // 初期値に戻る処理中のフラグを有効化
            IsReturning = true;

            // 初期位置へスムーズに戻る
            transform.position = Vector3.MoveTowards(
                transform.position,
                InitialPosition,
                10f * Time.deltaTime // 移動速度
            );

            // 初期位置に到達したらフラグを解除
            if (Vector3.Distance(transform.position, InitialPosition) < 0.01f)
            {
                IsReturning = false; // 戻り完了
            }
        }
    }
}