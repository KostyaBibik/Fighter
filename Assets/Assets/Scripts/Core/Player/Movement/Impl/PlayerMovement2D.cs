using UnityEngine;

namespace Core
{
    public class PlayerMovement2D : MovementBase
    {
        protected override void Move()
        {
            var velocity = MoveDirection.Value.normalized * MoveSpeed;
            velocity.y = PlayerView.Rigidbody.velocity.y;
            PlayerView.Rigidbody.velocity = velocity;
            
            base.Move();
        }

        protected override void Rotate()
        {
            if (MoveDirection.Value.x == 0)
                return;
            
            var scaleX = Mathf.Sign(MoveDirection.Value.x);
            PlayerView.Transform.localScale = new Vector3(scaleX, 1, 1);
        }
        
        protected override void StopMovement()
        {
            PlayerView.Rigidbody.velocity = Vector2.zero;
            
            base.StopMovement();
        }
    }
}