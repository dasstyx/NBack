using System.Collections;
using UnityEngine;

namespace Pallada.Gameplay.TilesGrid.Entity
{
    public class VolumetricGridEntity : GridEntityBase
    {
        private Material material;
        private MeshRenderer render;

        protected override IEnumerator CompleteInit()
        {
            yield return null;
            render = GetComponent<MeshRenderer>();
            material = render.material;
        }

        protected override IEnumerator TweenHighlight()
        {
            var color = material.color;
            color.a = 1;
            material.color = color;
            ApplyChanges();
            yield return null;
        }

        protected override IEnumerator TweenUnHighlight()
        {
            var color = material.color;
            color.a = 0;
            material.color = color;
            ApplyChanges();
            yield return null;
            // ^-^
        }

        private void ApplyChanges()
        {
            render.material = material;
        }
    }
}