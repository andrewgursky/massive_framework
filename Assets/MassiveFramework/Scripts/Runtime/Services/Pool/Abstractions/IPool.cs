﻿using System.Collections.Generic;

namespace MassiveCore.Framework
{
    public interface IPool
    {
        IEnumerable<T> Objects<T>(string id = "") where T : class, IPoolObject;

        T Request<T>(string id = "") where T : class, IPoolObject;

        void Return<T>(T obj) where T : class, IPoolObject;
        void ReturnAll<T>() where T : class, IPoolObject;
        void ReturnAll();

        void RemoveAll<T>() where T : class, IPoolObject;
    }
}
