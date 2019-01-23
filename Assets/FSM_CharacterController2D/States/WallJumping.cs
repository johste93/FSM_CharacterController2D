using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM_CharacterController2D
{
    public class WallJumping : IState
    {   
        public CharacterController characterController{get; set;}
        public void  SetReferenceToCharacter(CharacterController characterController)
        {
            this.characterController = characterController;
        }

        public void OnEnter()
        {      
            characterController.motion.runningVelocity = characterController.properties.movementSpeed * characterController.motion.runningDirection;
        }

        public void OnExit()
        {
        }
        
        public void Act()
        {
        }

        public bool CheckTransitions()
        {
            return Transition_WallJumpingToJumping.ConditionsMet(characterController);
        }
    }
}