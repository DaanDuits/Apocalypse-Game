using System;
using System.Collections.Generic;
using UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Characters.SkillSystem
{
    public class SkillHandler : MonoBehaviour
    {
        private static SkillManager _skillManager;
        [SerializeField] private SkillUI skillUI;
        private List<Skill> _skills;

        private void Awake()
        {
            if (_skillManager == null)
            {
                _skillManager = FindObjectOfType<SkillManager>();
            }

            _skills = _skillManager.skillPool;
            foreach (var skill in _skills)
            {
                skill.level = (byte)Random.Range(0, _skillManager.skillMaxLevel + 1);
            }
        }

        private void Start()
        {
            skillUI.DrawSkillsList(_skills);
        }
    }
}