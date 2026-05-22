using VContainer;

namespace MultiplayerShooter
{
    public class VContainerReference
    {
        public static GameLifetimeScope _gameLifetimeScope;

        public static GameLifetimeScope GameLifetimeScope 
        {
            get => _gameLifetimeScope; 
            set => _gameLifetimeScope ??= value;
        }

        public static IObjectResolver Container => _gameLifetimeScope.Container;
    }
}
