using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Hilam
{
    public class Button : MonoBehaviour
    {
        [SerializeField] internal int buttonValue;
        [SerializeField] internal bool isOpen;
        [Space(3)]
        [SerializeField] private Light buttonLight;
        [Header("UI")] 
        [SerializeField] private TextMeshProUGUI realValueUI;
        [SerializeField] private TextMeshProUGUI bitValueUI;
        
        private AudioSource audioSource;
        private void Start()
        {
            ChangeButtonToClose();
            audioSource = GetComponentInParent<AudioSource>();
        }

        void ChangeButtonToClose()
        {
            buttonLight.color = Color.red;
            realValueUI.gameObject.SetActive(false);
            bitValueUI.text = "0";
        }
        
        void ChangeButtonToOpen()
        {
            buttonLight.color = Color.green;
            realValueUI.gameObject.SetActive(true);
            bitValueUI.text = "1";
        }

        public void ChangeStatus(bool _isOpen)
        {
            isOpen = _isOpen;
            if(isOpen) ChangeButtonToOpen();
            else ChangeButtonToClose();
        }
        private void OnMouseDown()
        {
            isOpen = !isOpen;
            audioSource.Play();
            ChangeStatus(isOpen);
            
        }
    }
}
