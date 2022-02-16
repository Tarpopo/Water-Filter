using System.Collections;
using SquareDino.Scripts.MyAds;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class VictoryWindow : CanvasGroupBased
    {
        [SerializeField] private MyButton continueButton;
        [SerializeField] private TextMeshProUGUI completedLevelNumberText;
        [SerializeField] private float showDelay;
        [SerializeField] private UnityEvent _onWindowShow;
        private WaitForSeconds showDelayWPS;

        public MyButton ContinueButton => continueButton;
    
        public override void Enable(bool enable)
        {
            if (enable)
            {
                _onWindowShow?.Invoke();
                UpdateLevelText();

                // Показываем окно с задержкой
                if (showDelay > 0f)
                {
                    StartCoroutine(ShowWithDelay());
                }
                else
                {
                    base.Enable(enable);
                }
            }    
            else
            {
                base.Enable(enable);
            }
        }
        
        
        private void OnEnable()
        {
            MyAdsManager.RewardedEnable(RewardedLoaded);
        }
        
        private void OnDisable()
        {
            MyAdsManager.RewardedDisable(RewardedLoaded);
        }

        private void RewardedLoaded(bool flag)
        {
            // КнопкаРевардед.interactable = flag;
        }

        private IEnumerator ShowWithDelay()
        {
            yield return showDelayWPS;
            base.Enable(true);
        }

        // Обновляет текст с номером пройденного уровня
        private void UpdateLevelText()
        {
            var levelNumber = Statistics.CurrentLevelNumber == 0 ?11 : Statistics.CurrentLevelNumber;
            completedLevelNumberText.text = string.Format("LEVEL {0}", levelNumber);
        }

        protected override void Start()
        {
            showDelayWPS = new WaitForSeconds(showDelay);
        }
    }
}