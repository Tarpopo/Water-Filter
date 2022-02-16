using MoreMountains.NiceVibrations;
using SquareDino;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
   private Slider _slider;
   [SerializeField]private UnityEvent _onBarFull;
   private bool _isActive=true;
   private bool _vibration;
   private void Start()
   {
      _slider=GetComponent<Slider>();
      FindObjectOfType<LevelManager>().OnLevelLoaded += () =>
      {
         _isActive = true;
         _slider.value = 0;
         _onBarFull.AddListener(FindObjectOfType<Level>().CompleteLevel);
      };
   }

   public void SetValue(float value)
   {
      if (_isActive == false) return;
      _slider.value = value;
      //_slider.fillAmount = value;
      if (_slider.value >= 1)
      {
         _isActive = false;
         _onBarFull.Invoke();
      }

      if (_vibration == false)
      {
         _vibration = true;
         return;
      }
      MyVibration.Haptic(MyHapticTypes.LightImpact);
      _vibration = false;
   }
}
