using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterPlayer.Unity.StatePatternInUnity
{
    public abstract class ActiveState : State
    {
        private float yRot;
        private float xRot;

        private Vector3 rotation;
        private Vector3 camRotation;

        protected float lookSpeed = 5f;

        public ActiveState(Character character, StateMachine stateMachine) : base(character, stateMachine) { }
        public override void Enter()
        {
        }
        public override void HandleInput()
        {
            if (Input.GetButton("Fire1"))
            {
                if (character.fireRateIsGone)
                {
                    character.Shoot();
                    character.StartCoroutine(character.FireRate(character.weapon.delay));
                    if (character.weapon.particleSystem.isPlaying == false)
                        character.weapon.particleSystem.Play(true);
                }
            }
            else if (character.weapon.particleSystem.isPlaying == true)
                character.weapon.particleSystem.Stop(true);

            yRot = Input.GetAxisRaw("Mouse X");
            xRot = Input.GetAxisRaw("Mouse Y");
        }
        public override void LogicUpdate()
        {
            rotation = new Vector3(0f, yRot, 0f) * lookSpeed;
            camRotation = new Vector3(xRot, 0f, 0f) * lookSpeed;
        }
        public override void PhysicsUpdate()
        {
            character.Rotate(rotation);
            character.RotateCam(camRotation);
        }
        public override void Exit()
        {

        }
    }
}

