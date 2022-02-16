using Obi;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{
   [SerializeField] private bool _changeScale;
   private ObiSolver _currentSolver;
   private void Start()
   {
      FindObjectOfType<LevelManager>().OnLevelLoaded += SetGravity;
      SetGravity();
   }

   private void SetGravity()
   {
      _currentSolver = FindObjectOfType<ObiSolver>();
      if(_currentSolver==null)Debug.LogWarning("cant find obi solver");
   }

   public void ChangeGravity()
   {
      var gravity = _currentSolver.parameters.gravity;
      gravity.y *= -1;
      _currentSolver.parameters.gravity = gravity;
      _currentSolver.PushSolverParameters();
      if(_changeScale)ChangeScale();
   }

   private void ChangeScale()
   {
      var scale = transform.localScale;
      scale.y *= -1;
      transform.localScale = scale;
   }
}
