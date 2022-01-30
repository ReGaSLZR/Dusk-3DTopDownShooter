using UniRx;
using UnityEngine;

namespace ReGaSLZR.Player.Controls
{

    public interface IPlayerInput
    {
        IReadOnlyReactiveProperty<bool> HasConnectedGamePad();
        IReadOnlyReactiveProperty<bool> IsFiring();

        IReadOnlyReactiveProperty<Vector2> InputRotation();
        IReadOnlyReactiveProperty<Vector2> InputMovement();
        IReadOnlyReactiveProperty<Vector2> InputMousePosition();
    }

}