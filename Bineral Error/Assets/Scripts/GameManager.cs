using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Hilam
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Button[] buttons;

        [Header("Properties")] 
        [SerializeField] private int answer;
        [SerializeField] private int question;

        [Header("UI")] 
        [SerializeField] private TextMeshProUGUI questionUI;

        private void Start()
        {
            GetRandomBit();
        }

        private void Update()
        {
            FindAnswer();
        }

        #region Answer Methods
        
        void FindAnswer()
        {
            answer = ButtonValues();
        }
        int ButtonValues()
        {
            int _value = 0;
            for (int i = 0; i < buttons.Length; i++)
            {
                if(buttons[i].isOpen)_value += buttons[i].buttonValue;
            }

            return _value;
        }

        public void ResetAnswer()
        {
            foreach (var _button in buttons)
            {
                _button.ChangeStatus(false);
            }

            answer = 0;
        }
        

        #endregion

        #region Question Methods

        public bool CheckQuestion()
        {
            return answer == question;
        }

        public void GetRandomBit()
        {
            question = Random.Range(0, 257);
            questionUI.text = question.ToString();
        }

        #endregion
        
    }
}
