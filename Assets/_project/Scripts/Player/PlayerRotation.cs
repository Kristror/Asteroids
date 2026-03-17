using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerRotation : MonoBehaviour
    {
       

        private Rigidbody2D _rigidBodyPlayer;

        private void Start()
        {
            _rigidBodyPlayer = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
        }

        
    }
}