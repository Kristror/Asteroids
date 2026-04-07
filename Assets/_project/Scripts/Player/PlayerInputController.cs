using System;
using UnityEngine.InputSystem;
using Zenject;

namespace Player
{
    public class PlayerInputController : ITickable
    {
        public event Action ShootBullet;
        public event Action ShootLazer;
        public event Action Move;
        public event Action<int> Rotate;

        private Keyboard _keyboard;
        private Mouse _mouse;

        public PlayerInputController(Keyboard keyboard, Mouse mouse)
        {
            _keyboard = keyboard;
            _mouse = mouse;
        }

        public void Tick()
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