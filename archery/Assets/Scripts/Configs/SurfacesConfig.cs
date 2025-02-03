using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace Archery.Character
{
    [CreateAssetMenu(fileName = "SurfacesConfig", menuName = "Configs/Surfaces")]
    public class SurfacesConfig : ScriptableObject
    {
        [SerializedDictionary("tag", "config"), SerializeField]
        private SerializedDictionary<string, SurfaceConfig> _configs;
        
        [SerializeField] private SurfaceConfig _defaultConfig;
        
        public SurfaceConfig GetConfig(string tag)
        {
            return _configs.ContainsKey(tag) ? _configs[tag] : _defaultConfig;
        }
    }
}