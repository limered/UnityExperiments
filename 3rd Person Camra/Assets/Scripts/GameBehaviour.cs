using UnityEngine;

// ReSharper disable UnusedMember.Local

namespace Assets.Scripts
{
    public class GameBehaviour : MonoBehaviour
    {
        #region Private Methods

        private void FixedUpdate()
        {
            if (Input.GetKeyDown("escape") && Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            if (Input.GetMouseButtonDown(0) && Cursor.lockState == CursorLockMode.None)
                Cursor.lockState = CursorLockMode.Locked;
        }

        #endregion Private Methods
    }
}