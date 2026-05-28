using UnityEngine;
using VContainer;

namespace MultiplayerShooter
{
    [RequireComponent(typeof(GameLifetimeScope))]
    public class VContainerReference : MonoBehaviour
    {
        private void Awake() => Container = GetComponent<GameLifetimeScope>().Container;

        private static IObjectResolver _objectResolver;

        public static IObjectResolver Container
        {
            get => _objectResolver;
            set
            {
                if (_objectResolver != null)
                {
                    throw new System.Exception("There are more than one VContainerReferences");
                }
                _objectResolver = value;
            }
        }

        private void OnDestroy()
        {
            _objectResolver = null;
        }
    }
}
