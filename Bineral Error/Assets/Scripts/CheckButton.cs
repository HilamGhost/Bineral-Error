using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hilam
{
    public class CheckButton : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [Header("Sounds")] 
        [SerializeField] private AudioClip correctAnswer;
        [SerializeField] private AudioClip wrongAnswer;
        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        void NextQuestion()
        {
            gameManager.GetRandomBit();
            gameManager.ResetAnswer();
            audioSource.PlayOneShot(correctAnswer);
        }

        void ResetQuestion()
        {
            gameManager.ResetAnswer();
            audioSource.PlayOneShot(wrongAnswer);
        }

        private void OnMouseDown()
        {
            if (gameManager.CheckQuestion())
            {
                NextQuestion();
                return;
            }
            ResetQuestion();
            
        }
    }
}
