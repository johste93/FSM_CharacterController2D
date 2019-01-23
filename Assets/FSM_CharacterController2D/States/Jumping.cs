using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM_CharacterController2D
{
    public class Jumping : IState
    {   
        public CharacterController characterController{get; set;}
        public void  SetReferenceToCharacter(CharacterController characterController)
        {
            this.characterController = characterController;
        }

        public void OnEnter()
        {      
            characterController.motion.timeOfLastJumpAttempt = 0f;
            characterController.motion.rawVelocity.y = PhysicsHelper.CalculateSpeedFromHeight(characterController.properties.maxJumpHeight, characterController.properties.gravity);
        }

        public void OnExit()
        {
            characterController.motion.gravityScale = 1f;
        }
        
        public void Act()
        {
            if(characterController.inputInfo.onButtonPressed)
            {
                characterController.motion.gravityScale = 1f;	
            }	
            else
                characterController.motion.gravityScale = 1f/characterController.properties.minimumJumpPercent;

        }


        public bool CheckTransitions()
        {
            return 
                Transition_JumpingToWallSliding.ConditionsMet(characterController) ||
                Transition_JumpingToFalling.ConditionsMet(characterController);
                
        }
    }
}