using System;
using Pallada.Gameplay.TilesGrid.Entity;
using UnityEngine;

namespace Installers.GamePlay.TilesInstaller
{
    [Serializable]
    public class GridParamsSettings : IGridParams
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private GameObject _tilePrefab;
        [SerializeField] private float _tileSpacing;

        public Rect frame => RectTransform.rect;

        public RectTransform RectTransform => _rectTransform;

        public int TileCount { get; private set; }

        public Transform root => RectTransform.transform;

        public GameObject TilePrefab => _tilePrefab;

        public float TileSpacing => _tileSpacing;

        public void Setup(int tilesCount)
        {
            TileCount = tilesCount;
        }
    }
}