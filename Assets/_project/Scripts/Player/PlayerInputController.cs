using System;
using UnityEngine.InputSystem;
using Utilities;
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
        private PauseController _pauseController;

        public PlayerInputController(Keyboard keyboard, Mouse mouse, PauseController pauseController)
        {
            _keyboard = keyboard;
            _mouse = mouse;
            _pauseController = pauseController;
        }

        public void Tick()
        {
            if (!_pauseController.IsPaused)
            {
                CheckMouse();
                CheckKeyboard();
            }
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