using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM_CharacterController2D
{
    public class Fluttering : IState
    {   
        public CharacterController characterController{get; set;}
        public void  SetReferenceToCharacter(CharacterController characterController)
        {
            this.characterController = characterController;
        }

        public void OnEnter()
        {      
            characterController.motion.rawVelocity.y = characterController.properties.flutterJumpMinimumVelocity;
            characterController.motion.runningVelocity = characterController.properties.movementSpeed * characterController.motion.runningDirection;
        }

        public void OnExit()
        {
            characterController.motion.timeSpentFluttering = 0f;
        }

        public void Act()
        {
            characterController.motion.rawVelocity.y += characterController.properties.flutterJumpCounterForce * Time.fixedDeltaTime;
            characterController.motion.timeSpentFluttering += Time.fixedDeltaTime;

        }

        public bool CheckTransitions()
        {
            return 
                Transition_FlutteringToWallsliding.ConditionsMet(characterController) ||
                Transition_FlutteringToFallingWithoutControl.ConditionsMet(characterController);
        }
    }
}