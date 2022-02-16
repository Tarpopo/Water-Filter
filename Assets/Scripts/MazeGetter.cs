using System;
using UnityEngine;
public class MazeGetter : MonoBehaviour
{
   private void Start()
   {
      FindObjectOfType<MazeManager>().gameObject.SetActive(false);
   }

   public void OnPlay()
   {
      FindObjectOfType<MazeManager>().gameObject.SetActive(true);
   }
}
