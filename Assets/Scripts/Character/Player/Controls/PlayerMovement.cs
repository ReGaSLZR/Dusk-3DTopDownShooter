using UnityEngine;
using ReGaSLZR.Base;
using Zenject;
using UniRx;
using UniRx.Triggers;
using ReGaSLZR.Config;

namespace ReGaSLZR.Player.Controls
{

    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : ReactiveMonoBehaviour
    {

        #region Injectibles

        [Inject]
        private IPlayerInput playerInput;

        [Inject]
        private PlayerConfig config;

        #endregion

        #region Private Fields

        private Camera camMain;
        private Rigidbody rigidBody;

        private float mousePosZ;

        #endregion

        private void Awake()
        {
            camMain = Camera.main;
            mousePosZ = camMain.farClipPlane / 2f;

            rigidBody = GetComponent<Rigidbody>();
        }

        protected override void RegisterObservables()
        {
            this.FixedUpdateAsObservable()
                .Select(_ => playerInput.InputMovement().Value)
                .Subscribe(OnMove)
                .AddTo(disposablesBasic);

            this.UpdateAsObservable()
                .Select(_ => playerInput.InputMousePosition().Value)
                .Where(mousePos => !playerInput.HasConnectedGamePad().Value)
                .Subscribe(RotateByMouse)
                .AddTo(disposablesBasic);

            this.UpdateAsObservable()
                .Select(_ => playerInput.InputRotation().Value)
                .Where(gamePadRotation => playerInput.HasConnectedGamePad().Value)
                .Subscribe(RotateByGamePad)
                .AddTo(disposablesBasic);
        }

        #region Class Implementation

        private void RotateByGamePad(Vector2 gamePadRotation)
        {
            transform.Rotate(Vector3.up * gamePadRotation.x * config.Mvmt.SpeedRotation);
        }

        private void RotateByMouse(Vector2 mousePos)
        {
            var mouseWorldPosition = camMain.ScreenToWorldPoint(
                new Vector3(mousePos.x, mousePos.y, mousePosZ));

            var positionVector = mouseWorldPosition - transform.position;
            positionVector.y = transform.position.y;

            var targetRotation = Quaternion.LookRotation(positionVector);
            transform.rotation = Quaternion.Lerp(transform.rotation,
                targetRotation, config.Mvmt.SpeedRotation * Time.deltaTime 
                * config.MouseSensitivity);
        }

        private void OnMove(Vector2 move)
        {
            rigidBody.velocity = new Vector3(move.x, 0, move.y) * config.Mvmt.SpeedMovement;
        }

        #endregion

    }

}