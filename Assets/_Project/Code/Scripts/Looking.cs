using MultiplayerShooter.SO;
using UnityEngine;

namespace MultiplayerShooter
{
    public class Looking
    {
        private readonly HorizontalLooking _horizontalLooking;
        private readonly VerticalLooking _verticalLooking;

        public Looking(Transform body, Transform camera, PlayerData data)
        {
            _horizontalLooking = new(body, data.MouseSensativity);
            _verticalLooking = new(camera, data.MouseSensativity);
        }

        public void Look(Vector2 lookingDelta)
        {
            _horizontalLooking.Look(lookingDelta.x);
            _verticalLooking.Look(lookingDelta.y);
        }
    }
}
