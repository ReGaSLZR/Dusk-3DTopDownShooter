using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;
using UniRx.Triggers;
using ReGaSLZR.Utils;
using Zenject;
using ReGaSLZR.Player.Input;
using static UnityEngine.InputSystem.InputAction;

namespace ReGaSLZR.Player.Controls
{

    public class PlayerInput : MonoInstaller<PlayerInput>, IPlayerInput
    {

        #region Private Fields

        private PlayerControls controls;

        private CompositeDisposable disposables = new CompositeDisposable();

        private IReactiveProperty<bool> rHasConnectedGamePad = new ReactiveProperty<bool>();
        private IReactiveProperty<bool> rIsFiring = new ReactiveProperty<bool>();

        private IReactiveProperty<Vector2> rInputMovement = new ReactiveProperty<Vector2>();
        private IReactiveProperty<Vector2> rInputRotation = new ReactiveProperty<Vector2>();
        private IReactiveProperty<Vector2> rMousePosition = new ReactiveProperty<Vector2>();

        #endregion

        #region Class Overrides

        public override void InstallBindings()
        {
            Container.BindInstance<IPlayerInput>(this);
        }

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            controls = new PlayerControls();
        }

        private void OnEnable()
        {
            InputSystem.onDeviceChange += OnDeviceChange;

            controls.Gameplay.Fire.performed += OnFirePerformed;
            controls.Gameplay.Fire.canceled += OnFireStopped;

            controls.Gameplay.Move.performed += OnMovePerformed;
            controls.Gameplay.Move.canceled += OnMoveStopped;

            controls.Gameplay.Rotate.performed += OnRotatePerformed;
            controls.Gameplay.Rotate.canceled += OnRotateStopped;

            controls.Gameplay.Enable();

            this.UpdateAsObservable()
                .Subscribe(_ => rMousePosition.Value = 
                    controls.Gameplay.MousePosition.ReadValue<Vector2>())
                .AddTo(disposables);

            rHasConnectedGamePad.Value = (Gamepad.current != null);
        }

        private void OnDisable()
        {
            InputSystem.onDeviceChange -= OnDeviceChange;

            controls.Gameplay.Fire.performed -= OnFirePerformed;
            controls.Gameplay.Fire.canceled -= OnFireStopped;

            controls.Gameplay.Move.performed -= OnMovePerformed;
            controls.Gameplay.Move.canceled -= OnMoveStopped;

            controls.Gameplay.Rotate.performed -= OnRotatePerformed;
            controls.Gameplay.Rotate.canceled -= OnRotateStopped;

            controls.Gameplay.Disable();

            disposables.Dispose();
        }

        #endregion

        #region IPlayerInput Implementation

        public IReadOnlyReactiveProperty<bool> HasConnectedGamePad() => rHasConnectedGamePad;
        public IReadOnlyReactiveProperty<bool> IsFiring() => rIsFiring;

        public IReadOnlyReactiveProperty<Vector2> InputRotation() => rInputRotation;
        public IReadOnlyReactiveProperty<Vector2> InputMovement() => rInputMovement;
        public IReadOnlyReactiveProperty<Vector2> InputMousePosition() => rMousePosition;

        #endregion

        #region Class Implementation

        private void OnDeviceChange(InputDevice device, InputDeviceChange change)
        {   
            LogUtil.PrintInfo(GetType(), $"added? {device.added} | class {device.description.deviceClass} | change {change}");

            //device.description.deviceClass
            //NOTE: for some reason it returns "class" instead of "Gamepad" or "keyboard", contrary to https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/Devices.html
            //I'm gonna use (Gamepad.current != null) instead
            //I'm using an XBox Series X Controller connected via a USB wire

            rHasConnectedGamePad.Value = (device.added && (Gamepad.current != null));
        }

        private void OnFirePerformed(CallbackContext context)
        {
            rIsFiring.Value = true;
        }

        private void OnFireStopped(CallbackContext context)
        {
            rIsFiring.Value = false;
        }

        private void OnMovePerformed(CallbackContext context)
        {
            rInputMovement.Value = context.ReadValue<Vector2>();
        }

        private void OnMoveStopped(CallbackContext context)
        {
            rInputMovement.Value = Vector2.zero;
        }

        private void OnRotatePerformed(CallbackContext context)
        {
            rInputRotation.Value = context.ReadValue<Vector2>();
        }

        private void OnRotateStopped(CallbackContext context)
        {
            rInputRotation.Value = Vector2.zero;
        }

        #endregion

    }

}