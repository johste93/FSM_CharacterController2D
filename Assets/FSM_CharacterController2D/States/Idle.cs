using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM_CharacterController2D
{
    public class Idle : IState
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
            characterController.inputController.ConsumeInput();
        }

        public void Act()
        {
        }

        public bool CheckTransitions()
        {
            return
                Transition_IdleToRunning.ConditionsMet(characterController);


        }
    }
}
