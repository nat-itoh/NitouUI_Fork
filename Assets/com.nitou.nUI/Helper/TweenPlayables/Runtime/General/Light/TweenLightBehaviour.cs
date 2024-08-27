using System;
using UnityEngine;

namespace nitou.TweenPlayables
{
    [Serializable]
    public class TweenLightBehaviour : TweenAnimationBehaviour<Light>
    {
        public ColorTweenParameter color;
        public FloatTweenParameter intensity;
        public FloatTweenParameter shadowStrength;

        public override void OnTweenInitialize(Light playerData)
        {
            color.SetInitialValue(playerData, playerData.color);
            intensity.SetInitialValue(playerData, playerData.intensity);
            shadowStrength.SetInitialValue(playerData, playerData.shadowStrength);
        }
    }

}