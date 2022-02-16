
using UnityEngine;

namespace SquareDino.Scripts.PolicesPopUp
{
    public class MyPoliciesManager : MonoBehaviour
    {
        [SerializeField] private MyPoliciesPopUp policiesPopUpPrefab;
        [Space]
        [SerializeField] private string privacyPolicyURL = "http://wannatest.games/privacy-policy.html";
        [SerializeField] private string termsOfServictyURL = "http://wannatest.games/terms-of-use.html";


        private MyPoliciesPopUp _currentPopUp;


        private void Awake()
        {
            if(!MyPoliciesHandler.PrivacyPolicyAccepted || !MyPoliciesHandler.TermsOfServiceAccepted)
            {
                _currentPopUp = Instantiate(policiesPopUpPrefab);
                _currentPopUp.Init(privacyPolicyURL, termsOfServictyURL, OnPoliciesAccepted);
            }
            else
            {
                OnPoliciesAccepted();
            }
        }


        private void OnPoliciesAccepted()
        {
            MyPoliciesHandler.PrivacyPolicyAccepted = true;
            MyPoliciesHandler.TermsOfServiceAccepted = true;
            if(_currentPopUp != null)
                Destroy(_currentPopUp.gameObject);
        }
    }
}