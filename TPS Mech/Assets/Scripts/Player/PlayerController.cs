

using UnityEngine;

namespace TPShooter.Player
{
    public class PlayerController
    {
        private PlayerView playerView;
        private PlayerModel playerModel;

        private Vector3 velocity;
        private float turnSmoothVelocity=0.0f;

        public PlayerController(PlayerModel model,PlayerView player)
        {
            playerModel = model;
            playerView = player;
            playerModel.SetPlayerController(this);
            playerView.SetPlayerController(this);
        }
       public int GetPlayerSpeed()
        {
            return playerModel.RunSpeed;
        }

        public Vector3 Jump()
        {
            velocity.y = Mathf.Sqrt(playerModel.JumpHeight * playerModel.JumpVariable * playerModel.Gravity);
            return velocity;
        }
        public Vector3 TPMovement(Vector3 direction, Vector3 Movedirection,Vector3 eulerAngles)
        {
            if (turnSmoothVelocity == float.NaN) { turnSmoothVelocity = 0.0f; }
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerView.Camera.eulerAngles.y;
            float angleRotation = Mathf.SmoothDampAngle(eulerAngles.y, targetAngle, ref turnSmoothVelocity, playerModel.turnTime);
           // Debug.Log(targetAngle +"   "+ turnSmoothVelocity + "   " + playerModel.turnTime + "   " + eulerAngles.y);
            playerView.RotatePlayer(angleRotation);
            Movedirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            Vector3 movement = Movedirection.normalized * playerModel.CurrentSpeed ;
            return movement;
            

        }
        public Vector3 PhysicsExternal(bool isGrounded)
        {
            if (velocity.y > playerModel.MinYVelocity || !isGrounded)
            {
                velocity.y += playerModel.Gravity * Time.deltaTime;
            }
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = playerModel.JumpVariable;
            }
            return (velocity * Time.deltaTime);
        }

        public void Changespeed()
        {
            playerModel.SetCurrentSpeed();
        }

        public float CurrentSpeed()
        {
            return playerModel.CurrentSpeed;
        }
    }
}