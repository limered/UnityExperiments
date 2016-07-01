using UnityEngine;

// ReSharper disable UnusedMember.Local

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletBehaviour : MonoBehaviour
    {
        #region Public Fields

        public float BulletSpeed;
        public float TimeToLive = 30;

        #endregion Public Fields

        #region Private Fields

        private Rigidbody _body;
        private float _timeSinceSpawn;

        #endregion Private Fields

        #region Public Properties

        public Vector3 BulletDirection { get; set; }

        #endregion Public Properties

        #region Private Methods

        private void FixedUpdate()
        {
            _timeSinceSpawn += Time.fixedDeltaTime;
            if (_timeSinceSpawn > TimeToLive)
                Destroy(gameObject);
        }

        private void Start()
        {
            _body = GetComponent<Rigidbody>();
            _timeSinceSpawn = 0;
            _body.AddForce(BulletDirection * BulletSpeed);
        }

        #endregion Private Methods
    }
}