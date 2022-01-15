using System;
using UnityEngine;

namespace Pallada.Settings
{
    [Serializable]
    public class GameChancesSettings
    {
        [SerializeField] private float repeatChance = .3f;

        public float RepeatChance => repeatChance;
    }
}