using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace _Scripts.Utils
{
    [System.Serializable]
    public class SerializedArray<T>
    {
        [SerializeField] private List<T> _array = new List<T>();
        public T this[int index] => _array[index];

        public List<T> GetArray()
        {
            return _array;
        }

        public int Count => _array.Count;
        public void Add(T item)
        {
            _array.Add(item);
        }

        public void RemoveAt(int itemId)
        {
            _array.RemoveAt(itemId);
        }
        public void Remove(T item)
        {
            _array.Remove(item);
        }
    }
}