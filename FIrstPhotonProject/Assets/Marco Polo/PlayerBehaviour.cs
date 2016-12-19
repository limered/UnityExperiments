using UnityEngine;

namespace Assets.Marco_Polo
{
    public class PlayerBehaviour : MonoBehaviour
    {
        public float MovementSpeed = 200;
        private Rigidbody _body;

        private void Start()
        {
            _body = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            var force = Vector3.zero;
            if (Input.GetKey("s"))
                force.z -= MovementSpeed;
            if (Input.GetKey("w"))
                force.z += MovementSpeed;
            if (Input.GetKey("a"))
                force.x -= MovementSpeed;
            if (Input.GetKey("d"))
                force.x += MovementSpeed;

            _body.AddForce(force);
        }
    }
}