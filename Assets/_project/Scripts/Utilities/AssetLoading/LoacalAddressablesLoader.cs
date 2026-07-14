using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AssetLoading
{
    public class LoacalAddressablesLoader : IAssetLoader
    {
        public async UniTask<GameObject> LoadObjectByName(string objectName)
        {
            var handle = Addressables.LoadAssetAsync<GameObject>(objectName);
            var uniHandle =  handle.ToUniTask();
            return await uniHandle;
        }
    }
}