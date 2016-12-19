using UnityEngine;

namespace Assets.Marco_Polo
{
    public class RandomMatchmaker : Photon.PunBehaviour
    {
        // Use this for initialization
        private void Start()
        {
            PhotonNetwork.ConnectUsingSettings("initial");
        }

        private void OnGUI()
        {
            GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public override void OnJoinedLobby()
        {
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnJoinedRoom()
        {
            GameObject player = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity, 0);
            player.GetComponent<PlayerBehaviour>().enabled = true;
        }

        public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
        {
            Debug.Log("Can't join random room");
            PhotonNetwork.CreateRoom(null);
        }
    }
}