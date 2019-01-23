using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM_CharacterController2D
{
    public class Running : IState
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
            if(characterController.motion.runningDirection == 1 ? characterController.collisionInfo.right : characterController.collisionInfo.left)
            {
                characterController.motion.runningDirection *= -1;
                characterController.motion.runningVelocity = characterController.properties.movementSpeed * characterController.motion.runningDirection;
            }
                
        }

        public bool CheckTransitions()
        {
            return 
                Transition_RunningToJumping.ConditionsMet(characterController) ||
                Transition_RunningToFalling.ConditionsMet(characterController);
        }
    }
}