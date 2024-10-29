using System;
using System.Collections;
using System.Collections.Generic;

namespace Krivodeling.Swinging
{
    public sealed class SwingMultiplierCollection : IEnumerable<SwingMultiplier>
    {
        private readonly List<SwingMultiplier> _multipliers = new()
        {
            new(1f, 1f)
        };

        IEnumerator<SwingMultiplier> IEnumerable<SwingMultiplier>.GetEnumerator()
        {
            return _multipliers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _multipliers.GetEnumerator();
        }

        public SwingMultiplier Calculate()
        {
            float speed = 1f;
            float evaluation = 1f;

            for (int i = 0; i < _multipliers.Count; i++)
            {
                SwingMultiplier multiplier = _multipliers[i];

                speed *= multiplier.Speed;
                evaluation *= multiplier.Evaluation;
            }

            return new(speed, evaluation);
        }

        public void Add(SwingMultiplier multiplier)
        {
            _multipliers.Add(multiplier);
        }

        public void Remove(SwingMultiplier multiplier)
        {
            if (_multipliers.Count - 1 == 0)
                throw new InvalidOperationException("Multipliers count cannot be less than or equal to 1.");

            _multipliers.Remove(multiplier);
        }
    }
}
