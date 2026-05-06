using UnityEngine;

namespace MultiplayerShooter
{
    public class Looking
    {
        private readonly HorizontalLooking _horizontalLooking;
        private readonly VerticalLooking _verticalLooking;

        public Looking(Transform body, Transform camera, float sensitivity)
        {
            _horizontalLooking = new(body, sensitivity);
            _verticalLooking = new(camera, sensitivity);
        }

        public void Look(Vector2 lookingDelta)
        {
            _horizontalLooking.Look(lookingDelta.x);
            _verticalLooking.Look(lookingDelta.y);
        }
    }
}
