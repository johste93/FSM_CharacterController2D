using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM_CharacterController2D
{
    public class CharacterController : MonoBehaviour
    {
        public InputController inputController;
        public StateController stateController;
        public MovementController movementController;

        public Properties properties;
        public Motion motion;
        public CollisionInfo collisionInfo;
        public InputInfo inputInfo;

        public Rigidbody2D rigidBody2D;
        public BoxCollider2D boxCollider2D;

        private void Awake()
        {
            inputController = new InputController(this);
            movementController = new MovementController(this);
            motion = new Motion();

            stateController = new StateController(this); //Has to come last.
            stateController.SetState(properties.defaultState);
        }

        private void Update()
        {
            inputController.RegisterInput();
        }

        private void FixedUpdate()
        {
            stateController.Act();

            movementController.UpdateRigidbody();

            stateController.CheckTransitions();
        }
    }
}
