using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM_CharacterController2D
{
    public class InputController
    {
        private CharacterController characterController;

        public InputController(CharacterController characterController)
        {
            this.characterController = characterController;
            characterController.inputInfo = new InputInfo();
        }

        public void RegisterInput()
        {
            characterController.inputInfo = new InputInfo();

            if(Input.GetMouseButtonDown(0))
            {
                characterController.motion.timeOfLastJumpAttempt = Time.time;
                characterController.inputInfo.onButtonDownFrame = Time.frameCount;
            }
                
            if(Input.GetMouseButton(0))
                characterController.inputInfo.onButtonPressedFrame = Time.frameCount;

            if(Input.GetMouseButtonUp(0))
                characterController.inputInfo.onButtonUpFrame = Time.frameCount;
        }

        public void ConsumeInput()
        {
            characterController.motion.timeOfLastJumpAttempt = 0f;
            characterController.inputInfo.Reset();
        }
    }
}