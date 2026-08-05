using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Utilities.AssetLoading
{
    public interface IAssetLoader 
    {
        public UniTask<GameObject> LoadObjectByName(string objectName);

    }
}