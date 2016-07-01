using UnityEngine;

// ReSharper disable UnusedMember.Local

namespace Assets.Scripts
{
    public class PlayerBehaviour : MonoBehaviour
    {
        #region Public Fields

        public GameObject BulletPrefab;
        public float MovementSpeedForce = 20;
        public GameObject Weapon;
        public GameObject YRotationObject;

        #endregion Public Fields

        #region Private Fields

        private Rigidbody _rigitbody;

        #endregion Private Fields

        #region Private Methods

        private void FixedUpdate()
        {
            Move();
            Rotate();
            RotateWeapon();
            Shoot();
        }

        private void Move()
        {
            if (Input.GetKey("w"))
                _rigitbody.AddRelativeForce(0, 0, MovementSpeedForce);
            if (Input.GetKey("s"))
                _rigitbody.AddRelativeForce(0, 0, -MovementSpeedForce);
            if (Input.GetKey("a"))
                _rigitbody.AddRelativeForce(-MovementSpeedForce, 0, 0);
            if (Input.GetKey("d"))
                _rigitbody.AddRelativeForce(MovementSpeedForce, 0, 0);
        }

        private void Rotate()
        {
            if (Cursor.lockState != CursorLockMode.Locked) return;

            transform.Rotate(0, Input.GetAxis("Mouse X"), 0);

            var rotationX = YRotationObject.transform.rotation.eulerAngles.x;
            if (rotationX > 280) rotationX -= 280;
            else rotationX += 70;

            var input = -Input.GetAxis("Mouse Y");
            if ((rotationX < 10 && input < 0) || (rotationX > 140 && input > 0)) return;

            YRotationObject.transform.Rotate(input, 0, 0);
        }

        private void RotateWeapon()
        {
            Weapon.transform.LookAt(CameraBehaviour.AimPoint);
        }

        private void Shoot()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var offset = CameraBehaviour.AimPoint - Weapon.transform.position;
                offset.Normalize();
                var bullet = Instantiate(BulletPrefab, Weapon.transform.position + offset, Quaternion.identity) as GameObject;
                if (bullet != null)
                    bullet.GetComponent<BulletBehaviour>().BulletDirection = offset;
            }
        }

        private void Start()
        {
            _rigitbody = GetComponent<Rigidbody>();
        }

        #endregion Private Methods
    }
}