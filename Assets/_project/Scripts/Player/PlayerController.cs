using UnityEngine;

namespace Player
{
    public class PlayerController
    {
        public GameObject PlayerInstance { get; private set; }

        public PlayerCollision PlayerCollision;

        public PlayerController(PlayerFactory playerFactory)
        {
            PlayerInstance = playerFactory.Create().gameObject;

            PlayerCollision = PlayerInstance.GetComponentInChildren<PlayerCollision>();
        }
    }
}