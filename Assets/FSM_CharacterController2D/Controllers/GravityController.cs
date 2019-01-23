using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM_CharacterController2D
{
    public class GravityController
    {
        private CharacterController characterController;

        public void SetReferenceToCharacter(CharacterController characterController)
        {
            this.characterController = characterController;
        }

        public void ApplyGravity()
        {
            if(characterController.motion.rawVelocity.y > characterController.properties.maxFallSpeed)
                characterController.motion.rawVelocity.y += characterController.properties.gravity * characterController.motion.gravityScale * Time.fixedDeltaTime;
        }
    }
}
