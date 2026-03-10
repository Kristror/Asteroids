using UnityEngine;

namespace EntryPoint
{
    public class EntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            CompositionRoot _root = new CompositionRoot();

            _root.Initialize();
        }
    }
}