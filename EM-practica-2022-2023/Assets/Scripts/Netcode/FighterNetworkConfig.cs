﻿using Cinemachine;
using Movement.Components;
using Systems;
using Unity.Netcode;

namespace Netcode
{
    public class FighterNetworkConfig : NetworkBehaviour
    {
        public override void OnNetworkSpawn()       //Cuando aparece el personaje...
        {
            if (!IsOwner) return;
            
            FighterMovement fighterMovement = GetComponent<FighterMovement>();  //Tomamos el tipo de su movimiento
            InputSystem.Instance.Character = fighterMovement;                   //Instanciamos en el InputSystem dicho movimiento para manejarlo
            ICinemachineCamera virtualCamera = CinemachineCore.Instance.GetActiveBrain(0).ActiveVirtualCamera;  //Configuramos la cámara para que siga al jugador
            virtualCamera.Follow = transform;                                   //Hacemos que la cámara siga al jugador
        }
    }
}