using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Weapons
{
    public class Lazer : MonoBehaviour
    {
        private int _lazerDuration;

        public void SetLazerDuration(int lazerDuration)
        {
            _lazerDuration = lazerDuration;
        }

        public void Shoot()
        {
            gameObject.SetActive(true);

            UniTaskVoid waitForLazer = LazerActivity();
        }

        private async UniTaskVoid LazerActivity()
        {
            await UniTask.Delay(_lazerDuration);
            Deactivate();
        }

        private void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}