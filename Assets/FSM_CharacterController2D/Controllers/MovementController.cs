using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM_CharacterController2D
{
    public class MovementController 
    {
        private CharacterController characterController;
        private GravityController gravityController;
        private CollisionController collisionController;

        public MovementController(CharacterController characterController)
        {
            this.characterController = characterController;
            
            gravityController = new GravityController();
            gravityController.SetReferenceToCharacter(characterController);

            collisionController = new CollisionController();
            collisionController.SetReferenceToCharacter(characterController);
        }

        public void UpdateRigidbody()
        {   
            //Apply gravity
            gravityController.ApplyGravity();

            //Check collisions
            collisionController.UpdateCollisions();

            //Finally
            characterController.rigidBody2D.position += characterController.motion.clampedVelocity * Time.fixedDeltaTime;;
        }
    }
}
