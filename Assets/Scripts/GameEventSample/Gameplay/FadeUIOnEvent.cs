using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameEventSample.Gameplay
{
    public class FadeUIOnEvent : MonoBehaviour {
        
        [SerializeField] private GameEvent fadeInEvent;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private float fadeTime = 0.5f;

        private bool uiActive;

        private void Awake() {
            
            canvasGroup.alpha = 0f;
        }

        private void OnEnable() {
            
            fadeInEvent.Subscribe(FadeInCanvasGroup);
        }

        private void OnDisable() {
            
            fadeInEvent.Unsubscribe(FadeInCanvasGroup);
        }

        private void Update() {

            if (uiActive && Input.GetKeyDown(KeyCode.R)) {
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        private void FadeInCanvasGroup() => StartCoroutine(FadeInTime());

        private IEnumerator FadeInTime() {

            float timer = 0f;
            
            while (timer <= fadeTime) {

                float t = timer / fadeTime;
                float alpha = Mathf.Lerp(0f, 1f, t);
                canvasGroup.alpha = alpha;
                timer++;
                yield return new WaitForEndOfFrame();
            }

            canvasGroup.alpha = 1f;
            uiActive = true;
        }
    }
}