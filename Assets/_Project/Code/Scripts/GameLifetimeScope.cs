using MultiplayerShooter.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MultiplayerShooter
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private HUD _hud;
        [SerializeField] private GameMenuUI _gameMenu;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_hud);

            builder.RegisterInstance(_gameMenu);
        }
    }
}
