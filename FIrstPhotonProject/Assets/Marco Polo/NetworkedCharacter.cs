using UnityEngine;

namespace Assets.Marco_Polo
{
    public class NetworkedCharacter : Photon.MonoBehaviour
    {
        private Vector3 _correctPosition;
        private Quaternion _correctRotation;

        private void Update()
        {
            if (!photonView.isMine)
            {
                transform.position = Vector3.Lerp(transform.position, _correctPosition, Time.deltaTime * 5);
                transform.rotation = Quaternion.Slerp(transform.rotation, _correctRotation, Time.deltaTime * 5);
            }
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.isWriting)
            {
                stream.SendNext(transform.position);
                stream.SendNext(transform.rotation);
            }
            else
            {
                _correctPosition = (Vector3)stream.ReceiveNext();
                _correctRotation = (Quaternion)stream.ReceiveNext();
            }
        }
    }
}