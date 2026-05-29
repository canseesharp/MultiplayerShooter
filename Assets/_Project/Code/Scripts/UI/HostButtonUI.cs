using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

namespace MultiplayerShooter.UI
{
    public class HostButtonUI : ButtonUI
    {
        [SerializeField] private TMP_InputField _portField;
        [SerializeField] private GameObject _currentMenu;

        private readonly string _hostAdress = "0.0.0.0";

        protected override void OnButtonClick()
        {
            if (ConnectionDataValidator.TryGetValidPort(_portField.text, out ushort port) == false)
            {
                return;
            }

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(_hostAdress, port);

            _currentMenu.SetActive(false);

            NetworkManager.Singleton.StartHost();
        }
    }
}
