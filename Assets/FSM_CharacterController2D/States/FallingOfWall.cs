using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM_CharacterController2D
{
    public class FallingOfWall : IState
    {
        public CharacterController characterController{get; set;}
        public void  SetReferenceToCharacter(CharacterController characterController)
        {
            this.characterController = characterController;
        }

        public void OnEnter()
        {      
        }

        public void OnExit()
        {
        }

        public void Act()
        {
        }

        public bool CheckTransitions()
        {
            //These are shared by Falling.cs //Replace with duplicates before changing
            return 
                Transition_FallingToRunning.ConditionsMet(characterController) ||
                Transition_FallingToWallSliding.ConditionsMet(characterController) ||
                Transition_FallingToFluttering.ConditionsMet(characterController);
        }
    }
}
