using UnityEngine;
using System.Collections;
using System;

namespace FSM_CharacterController2D
{
    [Serializable]
    public class Properties : ScriptableObject
    {   
        //Movement
        public float movementSpeed = 6f;

        //Jump
        public float maxJumpHeight = 4;

        //FlutterJump
        public float flutterJumpDuration = 0.5f;
        public float flutterJumpCounterForce = 75f;
        public float flutterJumpMinimumVelocity = -7f;

        //WallJump
        public float maxWallSlideSpeed = 4;

        //Wiggleroom
        public float wiggleRoomSecounds = 0.15f;
        public float wiggleRoomDistance = 0.2f;

        //Gravity
        public float gravity = -46f;
        public float maxFallSpeed = -46f;
        public float minimumJumpPercent = 0.3f;

        //StateMachine
        public State defaultState;

        //CollisionController
        public LayerMask whatIsPlatform;
    }
}

