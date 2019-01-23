using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM_CharacterController2D
{
    public interface IState
    {
        CharacterController characterController{get; set;}
        void SetReferenceToCharacter(CharacterController characterController);

        void OnEnter();
        void OnExit();
        void Act();
        bool CheckTransitions();
    }
}
    
