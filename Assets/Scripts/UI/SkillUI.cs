using System;
using System.Collections.Generic;
using System.Linq;
using Characters.SkillSystem;
using UnityEngine;

namespace UI
{
    public class SkillUI : MonoBehaviour
    {
        private static SkillManager _skillManager;
        private List<SkillUIObject> _skillUIObjects = new List<SkillUIObject>();
        [SerializeField] private GameObject skillUIPrefab;

        private void Start()
        {
            if (_skillManager == null)
            {
                _skillManager = FindObjectOfType<SkillManager>();
            }


            foreach (var skill in _skillManager.skillPool)
            {
                _skillUIObjects.Add(Instantiate(skillUIPrefab, transform).GetComponent<SkillUIObject>());
                _skillUIObjects.Last().nameText.text = skill.name;
            }
        }

        public void DrawSkillsList(List<Skill> skills)
        {
            for (int i = 0; i < skills.Count; i++)
            {
                _skillUIObjects[i].levelText.text = skills[i].level.ToString();
                
            }
        }
        
    }
}