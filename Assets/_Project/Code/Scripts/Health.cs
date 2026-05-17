using Unity.Netcode;

namespace MultiplayerShooter
{
    public class Health : NetworkBehaviour, IDamageable
    {
        private readonly NetworkVariable<int> _value = new();

        public int Value => _value.Value;

        public void Init(int health)
        {
            _value.Value = health;
        }

        public void TakeDamage(int damage)
        {
            _value.Value -= damage;

            if (Value <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
