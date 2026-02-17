using System;
using TMPro;
using UnityEngine;


public class UIplayerStats : MonoBehaviour
{
    [SerializeField] private TMP_Text _textPosition;
    [SerializeField] private TMP_Text _textRotation;
    [SerializeField] private TMP_Text _textSpeed;
    [SerializeField] private TMP_Text _textLazerAmmo;
    [SerializeField] private TMP_Text _textLazerReloadTime;

    private GameObject _playerGameObject;
    private Rigidbody2D _playerRigidBody;
    private PlayerLazerShooting _playerLazerShooting;

    public void SetPlayer(GameObject playerObject)
    {
        _playerGameObject = playerObject;
        _playerRigidBody = playerObject.GetComponent<Rigidbody2D>();
        _playerLazerShooting = playerObject.GetComponent<PlayerLazerShooting>();
    }
    private void Update()
    {
        _textPosition.text  = _playerGameObject.transform.position.ToString();
        _textRotation.text  = Math.Round(_playerGameObject.transform.rotation.eulerAngles.z, 1).ToString();
        _textSpeed.text  = Math.Round(_playerRigidBody.linearVelocity.magnitude, 1).ToString();

        _textLazerAmmo.text = _playerLazerShooting.Ammo.ToString();
        _textLazerReloadTime.text = Math.Round(_playerLazerShooting.TimeToReload(), 1).ToString();
    }
}
