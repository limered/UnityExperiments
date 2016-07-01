using UnityEngine;

// ReSharper disable UnusedMember.Local

namespace Assets.Scripts
{
    public class CameraBehaviour : MonoBehaviour
    {
        #region Public Fields

        public float AnimationSpeed;
        public GameObject FutureCameraPosition;
        public GameObject LookAtGameObject;

        #endregion Public Fields

        #region Private Fields

        private Rigidbody _body;

        #endregion Private Fields

        #region Public Properties

        public static Vector3 AimPoint { get; set; }

        #endregion Public Properties

        #region Private Methods

        private static void CalculateShootPosition()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 300))            {                AimPoint = hit.point;
                Debug.DrawLine(ray.origin, hit.point);            }
        }

        private void AnimateLookat()
        {
            transform.LookAt(LookAtGameObject.transform);
        }

        private void AnimatePosition()
        {
            if (AnimationSpeed > 0)
            {
                var directionToNewPosition = FutureCameraPosition.transform.position - transform.position;
                _body.AddForce(directionToNewPosition * AnimationSpeed);
            }
            else
            {
                transform.position = FutureCameraPosition.transform.position;
            }
        }

        private void FixedUpdate()
        {
            AnimatePosition();
            AnimateLookat();
            CalculateShootPosition();
        }

        private void Start()
        {
            _body = GetComponent<Rigidbody>();
        }

        #endregion Private Methods
    }
}