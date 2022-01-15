using System;
using System.Collections;
using UnityEngine;

namespace Pallada.Gameplay.TilesGrid.Entity
{
    public interface IGridEntity
    {
        int id { get; }
        Transform transform { get; }

        IEnumerator HighlightTile();

        void Init(int id, Action<int> pressed = null);

        void Press();
    }
}