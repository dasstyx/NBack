using System;
using System.Collections;
using UnityEngine;

//TODO: Make a new non-MonoBehaviour class for instantiation
namespace Pallada.Gameplay.TilesGrid.Entity
{
    public class NullGridEntity : MonoBehaviour, IGridEntity
    {
        public int id => 0;

        public IEnumerator HighlightTile()
        {
            yield return null;
        }

        public void Init(int id, Action<int> pressed = null)
        {
        }

        public void Press()
        {
        }
    }
}