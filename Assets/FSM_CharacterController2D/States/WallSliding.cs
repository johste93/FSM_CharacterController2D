using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM_CharacterController2D
{
    public class WallSliding : IState
    {   
        public CharacterController characterController{get; set;}
        public void  SetReferenceToCharacter(CharacterController characterController)
        {
            this.characterController = characterController;
        }

        public void OnEnter()
        {            
            characterController.motion.runningVelocity = 0f;
        }

        public void OnExit()
        {
            //Jump away from wall
            characterController.motion.runningDirection *= -1;
        }

        public void Act()
        {
            float deltaGravityToBeApplied = characterController.properties.gravity * characterController.motion.gravityScale * Time.fixedDeltaTime;
            float maxWallSLideSpeed = characterController.properties.maxWallSlideSpeed + deltaGravityToBeApplied;

            characterController.motion.rawVelocity.y = Mathf.Clamp(characterController.motion.rawVelocity.y, -Mathf.Abs(maxWallSLideSpeed), 4f);
        }

        public bool CheckTransitions()
        {
            return 
                Transition_WallSlidingToRunning.ConditionsMet(characterController) ||
                Transition_WallSlidingToWallJumping.ConditionsMet(characterController) ||
                Transition_WallslidingToFallingOfWall.ConditionsMet(characterController);
        }
    }
}