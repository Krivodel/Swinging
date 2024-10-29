# Swinging
Улучшите ощущения от игры с гибкой системой покачивания. Пример результата в реальной игре:

https://github.com/user-attachments/assets/fda683e1-f4fd-416f-83ff-116ba2a6f246

Тонкая настройка кривых для каждой оси позиции или поворота. Поддержка смешивания кривых. Сделайте основной пресет для ходьбы, и подмешивайте к нему пресет состояния персонажа (например, частота дыхания или уровень стресса)

![image](https://github.com/user-attachments/assets/c68ad3fc-d231-45df-9899-ffd82cc978ee)

# Как использовать
На объекте для покачивания нужно добавить **TransformSwingController**.
В нём можно заранее задать свингеры через инспектор

![image](https://github.com/user-attachments/assets/31014ee5-5323-4eca-99a5-c500b20c0099)

Или добавлять их динамически через код

```
_swingController.AddSwinger(mySwinger);
```

Чтобы написать свой свингер, нужно реализовать интерфейс **ITransformSwinger**

```
public class ExampleSwinger : ITransformSwinger
{
    [SerializeField] private SwingCurve3 _positionCurve;
    [SerializeField] private BlendMode _positionBlendMode = BlendMode.Add;

    void ITransformSwinger.Apply(ref ModifiableTransform transform, in SwingMultiplier multiplier)
    {
        _positionCurve.Update(multiplier.Speed);

        transform.LocalPosition = Blender.Blend(
            transform.LocalPosition,
            _positionCurve.Evaluate() * multiplier.Evaluation,
            _positionBlendMode);
    }
}
```

Если нужна поддержка плавных переходов между кривыми, можно наследоваться от **TransitableTransformSwinger<TSwing>**, где в качестве **TSwing** передать наследника **TransitableSwing**

```
public class ExampleSwing : TransitableSwing
{
    [field: SerializeField] public SwingCurve3 PositionCurve { get; private set; }
    [field: SerializeField] public BlendMode BlendMode { get; private set; } = BlendMode.Add;
}
```

```
public class ExampleTransitableSwinger : TransitableTransformSwinger<ExampleSwing>
{
    [SerializeField] private ExampleSwing _idleSwing;
    [SerializeField] private ExampleSwing _moveSwing;
    [SerializeField] private BlendMode _transitionBlendMode = BlendMode.Add;
    [SerializeField] private bool _isMoving; // For example.

    protected override void OnApply(ref ModifiableTransform transform, in SwingMultiplier multiplier)
    {
        _idleSwing.PositionCurve.Update(multiplier.Speed);
        _moveSwing.PositionCurve.Update(multiplier.Speed);

        SetSwing(_isMoving ? _moveSwing : _idleSwing);

        var previousNewPosition = PreviousSwing == null
            ? Vector3.zero
            : multiplier.Evaluation * PreviousSwing.Attenuation * PreviousSwing.PositionCurve.Evaluate();
        var currentNewPosition = CurrentSwing.Attenuation * multiplier.Evaluation * CurrentSwing.PositionCurve.Evaluate();
        var newPosition = Blender.Blend(previousNewPosition, currentNewPosition, _transitionBlendMode);

        transform.LocalPosition = Blender.Blend(transform.LocalPosition, newPosition, CurrentSwing.BlendMode);
    }
}
```

# Как установить
2 варианта:
1) Перенести папку **Krivodeling** в папку **Assets**
2) Импортировать **.unitypackage**: https://github.com/Krivodel/Swinging/releases/

# Зависимости
- DOTween Pro
- Odin Inspector and Serializer
