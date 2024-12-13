﻿using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public interface ITargetStrategy
    {
        Vector3 GetTarget();
    }
}