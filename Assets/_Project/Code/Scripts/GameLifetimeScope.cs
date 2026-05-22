using MultiplayerShooter.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MultiplayerShooter
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private HealthBarUI _healthBar;

        protected override void Configure(IContainerBuilder builder)
        {
            VContainerReference.GameLifetimeScope = this;

            builder.RegisterInstance(_healthBar);
        }
    }
}
