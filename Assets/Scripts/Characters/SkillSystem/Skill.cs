using UnityEditor;
using UnityEngine;

namespace Characters.SkillSystem
{
    [System.Serializable]
    public class Skill
    {
        public string name;
        public Texture2D texture;
        public byte level;

        public SkillPassionLevel PassionLevel
        {
            get;
            set;
        }
    }
}