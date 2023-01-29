using System;
using System.Collections.Generic;
using VerticalGame.Engine.Objects;

namespace chapter11.Engine.Objects
{
    public class GameObjectPool<T> where T : BaseGameObject
    {
        private LinkedList<T> _activePool = new LinkedList<T>();
        private LinkedList<T> _inactivePool = new LinkedList<T>();

        public List<T> ActiveObjects
        {
            get
            {
                List<T> list = new List<T>();
                foreach (var gameObject in _activePool)
                {
                    list.Add(gameObject);
                }
                return list;
            }
        }

        public T GetOrReturn(Func<T> createNbObjectFn) 
        {
            T activatedObject;
            if (_inactivePool.Count > 0)
            {
                T gameObject = _inactivePool.First.Value;
                activatedObject = gameObject;

                _activePool.AddLast(gameObject);
                _inactivePool.RemoveFirst();
            }
            else
            {
                T gameObject = createNbObjectFn();
                activatedObject = gameObject;

                _activePool.AddLast(gameObject);
            }
            return activatedObject;
        }
    }
}