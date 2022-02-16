using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameWindow : CanvasGroupBased
    {
        [SerializeField] private TextMeshProUGUI currentLevelText;
        [SerializeField] private Image progressImage;
        [SerializeField] private MyButton restartButton;

        public MyButton RestartButton => restartButton;

        public override void Enable(bool enable)
        {
            base.Enable(enable);

            if (!enable) return;
            UpdateLevelText();
            ResetProgressBar();
        }

        public void UpdateProgressBar(LevelProgress levelProgress)
        {
            progressImage.fillAmount = levelProgress.Progress;
        }

        public void ResetProgressBar()
        {
            progressImage.fillAmount = 0f;
        }

        private void UpdateLevelText()
        {
            currentLevelText.text = string.Format("LEVEL {0}", Statistics.CurrentLevelNumber+1);
        }
    }
}