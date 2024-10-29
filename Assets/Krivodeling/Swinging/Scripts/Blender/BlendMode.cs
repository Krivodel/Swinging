using Sirenix.OdinInspector;
using System;

namespace Krivodeling
{
    [Serializable, EnumPaging]
    public enum BlendMode
    {
        Add,
        Multiply,
        Subtract,
        Average,
        Max,
        Min
    }
}
