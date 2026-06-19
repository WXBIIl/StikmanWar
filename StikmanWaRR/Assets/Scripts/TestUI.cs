using Unity.Netcode;
using UnityEngine;

namespace Multiplayer.Scripts
{
    public class TestUI : MonoBehaviour
    {
        public void StartHostButtonClick()
        {
            NetworkManager.Singleton.StartHost();
        }

        public void StartClientButtonClick()
        {
            NetworkManager.Singleton.StartClient();
        }
    }
}