using UnityEngine;
using TMPro;
using System.Collections;

public class LosingWindow : CanvasGroupBased
{
    [SerializeField] private MyButton restartButton;
    [SerializeField] private TextMeshProUGUI fadedText;
    [SerializeField] private float showDelay;

    private WaitForSeconds showDelayWPS;

    public MyButton RestartButton => restartButton;

    public override void Enable(bool enable)
    {
        if (enable)
        {
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

    private IEnumerator ShowWithDelay()
    {
        yield return showDelayWPS;

        base.Enable(true);
    }

    protected override void Start()
    {
        showDelayWPS = new WaitForSeconds(showDelay);
    }
}