﻿using System;

namespace Game.Modules.Common.Interfaces
{
    public interface IEnemyEntity : IComplexEntity
    {
        public event Action<IEnemyEntity> OnLeftGameArea;
        public event Action<bool> OnStateChanged;
        public void Dispose();
    }
}