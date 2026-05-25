using MultiplayerShooter.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MultiplayerShooter
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private HUD _hud;

        protected override void Configure(IContainerBuilder builder)
        {
            VContainerReference.GameLifetimeScope = this;

            builder.RegisterInstance(_hud);
        }
    }
}
