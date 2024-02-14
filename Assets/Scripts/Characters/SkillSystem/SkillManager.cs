using System.Collections.Generic;
using UnityEngine;

namespace Characters.SkillSystem
{
    public class SkillManager : MonoBehaviour
    {
        public List<Skill> skillPool;
        public byte skillMaxLevel = 16;
    }
}