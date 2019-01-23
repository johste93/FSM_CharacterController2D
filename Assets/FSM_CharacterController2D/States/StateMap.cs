using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace FSM_CharacterController2D
{
    public class StateMap
    {
        public static IState LookUp(State state)
        {
            switch(state)
            {
                case State.Idle:
                    return new Idle();
                case State.Falling:
                    return new Falling();
                case State.FallingWithoutControl:
                    return new FallingWithoutControl();
                case State.FallingOfWall:
                    return new FallingOfWall();
                case State.Running:
                    return new Running();
                case State.Jumping:
                    return new Jumping();
                case State.WallJumping:
                    return new WallJumping();
                case State.Fluttering:
                    return new Fluttering();
                case State.WallSliding:
                    return new WallSliding();
            }

            Debug.LogError("State not found in StateMap!");
            return null;
        }
    }
}
