using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM_CharacterController2D
{
    public class StateController
    {   
        public CharacterController characterController;
        public IState currentState;
        
        public StateController(CharacterController characterController)
        {
            this.characterController = characterController;
        }

        public void SetState(State state)
        {
            IState targeState = StateMap.LookUp(state);

            Debug.Log(Time.frameCount + ": " + currentState + " -> " + state);

            if(currentState != null)
                currentState.OnExit();
                
            currentState = targeState;
            currentState.SetReferenceToCharacter(characterController);
            currentState.OnEnter();

            
            //CheckTransitions(); //Prone to creating infite loops! but speeds up transitions by a few frames.
        }

        public void Act()
        {
            currentState.Act();
        }

        public void CheckTransitions()
        {
            currentState.CheckTransitions();
        }
    }
}
