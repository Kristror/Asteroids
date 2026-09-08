using System;
using UnityEngine.InputSystem;
using Zenject;

namespace Player
{
    public class PlayerInputController : ITickable
    {
        public event Action ShootBullet;
        public event Action ShootLaser;
        public event Action<bool> Move;
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
                ShootLaser?.Invoke();
            }
        }
        private void CheckKeyboard()
        {
            bool move = _keyboard.wKey.isPressed || _keyboard.upArrowKey.isPressed;
            int rotate = 0;

            if (_keyboard.aKey.isPressed || _keyboard.leftArrowKey.isPressed)
            {
                rotate = 1;
            }
            else if(_keyboard.dKey.isPressed || _keyboard.rightArrowKey.isPressed)
            {
                rotate = -1;
            }

            Move?.Invoke(move);
            Rotate?.Invoke(rotate);
        }
    }
}