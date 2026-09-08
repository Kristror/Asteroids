using System;

namespace Configs
{
    public interface IConfigsProvider 
    {
        public event Action ConfigsLoaded;
        public GameConfigs GetGameConfigs();
    }
}