using Unity.Netcode;
using UnityEngine;
using UnityEngine.Rendering;

namespace MultiplayerShooter
{
    [RequireComponent(typeof(Renderer))]
    public class OwnMeshHider : NetworkBehaviour
    {
        public override void OnNetworkSpawn()
        {
            if (IsOwner == true)
            {
                GetComponent<Renderer>().shadowCastingMode = ShadowCastingMode.ShadowsOnly;
            }
        }
    }
}
