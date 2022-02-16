using System;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(Canvas))]
public class CanvasGroupBased : MonoBehaviour
{
    public event System.Action<bool> OnEnableAll;
    public event System.Action<bool> OnEnableInteractable;

    protected void DoEnable(bool value)
    {
        if (OnEnableAll != null)
        {
            OnEnableAll(value);
        }
    }

    protected CanvasGroup canvasGroup;
    protected Canvas canvas;

    protected virtual void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponent<Canvas>();
    }

    public bool IsShown
    {
        get;
        protected set;
    }

    public virtual void Enable(bool enable)
    {
        IsShown = enable;

        canvas.enabled = enable;
        canvasGroup.alpha = enable ? 1f : 0f;
        canvasGroup.blocksRaycasts = enable;
        canvasGroup.interactable = enable;

        OnEnableAll?.Invoke(enable);
    }

    public virtual void Enable(bool enable, float duration)
    {
        IsShown = enable;
        
        canvas.enabled = enable;
        if (DOTween.IsTweening(canvasGroup)) canvasGroup.DOKill();
        canvasGroup.DOFade(IsShown ? 1f : 0f, duration);
        canvasGroup.blocksRaycasts = enable;
        canvasGroup.interactable = enable;

        OnEnableAll?.Invoke(enable);
    }

    public virtual void EnableInteractable(bool enable)
    {
        canvasGroup.blocksRaycasts = enable;
        canvasGroup.interactable = enable;

        OnEnableInteractable?.Invoke(enable);
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

}
