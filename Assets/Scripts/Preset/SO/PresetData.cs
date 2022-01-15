using UnityEngine;

namespace Pallada.Preset.SO
{
    [CreateAssetMenu(fileName = "PresetData", menuName = "NBack/PresetData", order = 0)]
    public class PresetData : ScriptableObject
    {
        public int nback = 2;
        public int tileCount = 3;
        public int timeLimit = 60;
        public float turnTime = .8f;
    }
}