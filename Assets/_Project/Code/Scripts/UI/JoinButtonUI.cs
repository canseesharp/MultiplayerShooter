using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

namespace MultiplayerShooter.UI
{
    public class JoinButtonUI : ButtonUI
    {
        [SerializeField] private TMP_InputField _portField;
        [SerializeField] private TMP_InputField _addressField;
        [SerializeField] private GameObject _currentMenu;

        protected override void OnButtonClick()
        {
            if (ConnectionDataValidator.TryGetValidAddress(_addressField.text, out string address) == false)
            {
                return;
            }

            if (ConnectionDataValidator.TryGetValidPort(_portField.text, out ushort port) == false)
            {
                return;
            }

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(address, port);

            _currentMenu.SetActive(false);

            NetworkManager.Singleton.StartClient();
        }
    }
}
