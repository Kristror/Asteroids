using UnityEngine;
using System.Collections;


public class Lazer : MonoBehaviour
{
    [SerializeField] private float _lazerDuration;

    public void Shoot()
    {
        this.gameObject.SetActive(true);

        StartCoroutine(LazerActivity());
    }

    IEnumerator LazerActivity()
    {
        yield return new WaitForSeconds(_lazerDuration);
        Deactivate();
    }

    private void Deactivate()
    {
        this.gameObject.SetActive(false); 
    }
}