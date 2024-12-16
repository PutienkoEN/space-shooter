using UnityEngine;

namespace Game.PickupModule.Scripts
{
    
    public abstract class PickupConfig : ScriptableObject, IPickupConfig
    {
       public abstract IPickupConfigData GetPickupData();
    }
    
}