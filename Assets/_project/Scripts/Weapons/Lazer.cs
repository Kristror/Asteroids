using UnityEngine;
using System.Collections;

public class Lazer : MonoBehaviour
{
    private float _lazerDuration;

    public void SetLazerDuration(float lazerDuration)
    {
        _lazerDuration = lazerDuration;
    }

    public void Shoot()
    {
        gameObject.SetActive(true);

        StartCoroutine(LazerActivity());
    }

    private IEnumerator LazerActivity()
    {
        yield return new WaitForSeconds(_lazerDuration);
        Deactivate();
    }

    private void Deactivate()
    {
        gameObject.SetActive(false); 
    }
}