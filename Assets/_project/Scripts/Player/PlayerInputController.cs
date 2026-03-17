using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputController : MonoBehaviour
    {
        public Action ShootBullet;
        public Action ShootLazer;
        public Action Move;
        public Action<int> Rotate;

        private Keyboard _keyboard;
        private Mouse _mouse;

        public void Start()
        {
            _keyboard = Keyboard.current;
            _mouse = Mouse.current;
        }

        private void Update()
        {
            CheckMouse();
            CheckKeyboard();
        }

        private void CheckMouse()
        {
            if (_mouse.leftButton.wasPressedThisFrame)
            {
                ShootBullet?.Invoke();
            }
            
            if (_mouse.rightButton.wasPressedThisFrame)
            {
                ShootLazer?.Invoke();
            }
        }
        private void CheckKeyboard()
        {

            if (_keyboard.wKey.isPressed || _keyboard.upArrowKey.isPressed)
            {
                Move?.Invoke();
            }

            if (_keyboard.aKey.isPressed || _keyboard.leftArrowKey.isPressed)
            {
                Rotate?.Invoke(1);
            }

            if (_keyboard.dKey.isPressed || _keyboard.rightArrowKey.isPressed)
            {
                Rotate?.Invoke(-1);
            }
        }
    }
}