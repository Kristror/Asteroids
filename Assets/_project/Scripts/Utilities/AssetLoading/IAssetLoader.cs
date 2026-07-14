using Cysharp.Threading.Tasks;
using UnityEngine;

namespace AssetLoading
{
    public interface IAssetLoader 
    {
        public UniTask<GameObject> LoadObjectByName(string objectName);

    }
}