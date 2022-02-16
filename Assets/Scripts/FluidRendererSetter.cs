using Obi;
using UnityEngine;
[RequireComponent(typeof(ObiFluidRenderer))]
public class FluidRendererSetter : MonoBehaviour
{
   private ObiFluidRenderer _obiFluidRenderer;
   private void Start()
   {
      _obiFluidRenderer = GetComponent<ObiFluidRenderer>();
      FindObjectOfType<LevelManager>().OnLevelLoaded += FindRenderer;
   }
   private void FindRenderer()
   {
      _obiFluidRenderer.particleRenderers[0] = FindObjectOfType<ObiParticleRenderer>();
   }
}
