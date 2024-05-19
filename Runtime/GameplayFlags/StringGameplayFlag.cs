using System;
using UnityEngine;

namespace Dre0Dru.GameplayFlags
{
    [Serializable]
    public struct StringGameplayFlag : IEquatable<StringGameplayFlag>
    {
        [SerializeField]
        private string _name;

        public string Name => _name;

        public StringGameplayFlag(string name)
        {
            _name = name;
        }

        public bool Equals(StringGameplayFlag other)
        {
            return _name == other._name;
        }

        public override bool Equals(object obj)
        {
            return obj is StringGameplayFlag other && Equals(other);
        }

        public override int GetHashCode()
        {
            return (_name != null ? _name.GetHashCode() : 0);
        }

        public static implicit operator string(StringGameplayFlag flag)
        {
            return flag._name;
        }

        public static implicit operator StringGameplayFlag(string name)
        {
            return new StringGameplayFlag()
            {
                _name = name
            };
        }
    }
}
