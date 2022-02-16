using UnityEngine;

#if FLAG_AF
    using AppsFlyerSDK;
#endif

namespace SquareDino.Scripts.MyAnalytics
{
    public class MyAppsFlyerV6 : MonoBehaviour {
    
        [SerializeField] private string devKey = "r9vNC83N8nYpCzYGigyjUh";
        [SerializeField] private string appIdIOs = "Number Only";
        [SerializeField] private bool isDebug;

#if FLAG_AF
        private void Start()
        {
            AppsFlyer.initSDK(devKey, appIdIOs);
            AppsFlyer.startSDK();
            AppsFlyer.setIsDebug (isDebug);
            AppsFlyer.setCustomerUserId(SystemInfo.deviceUniqueIdentifier);
            // AppsFlyer.getConversionData();
        }
#endif
    }
}