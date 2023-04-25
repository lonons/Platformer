using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public enum AnimState
    {
        Idle = 0,
        Run = 1,
        Jump = 2
    }
    [CreateAssetMenu(fileName = "SpriteAnimatorCfg", menuName = "Configs / Animations" , order = 1)]
    public class AnimationConfig : ScriptableObject
    {
        [Serializable]
        public class SpriteSequence
        {
            public AnimState Track;
            public List<Sprite> Sprites = new List<Sprite>();
        }

        public List<SpriteSequence> Sequences = new List<SpriteSequence>();

    }

}
