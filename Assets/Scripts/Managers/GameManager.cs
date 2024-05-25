using Assets.Scripts.Astronauta.Core;
using Cinemachine;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [Header("Player Settings")]
        public GameObject player;
        public Transform playerStartPoint;

        [Header("Enemies Settings")]
        public List<GameObject> enemies;

        [Header("Animation Settings")]
        public float duration;
        public Ease ease = Ease.OutBack;

        [Header("Camera")]
        public CinemachineVirtualCamera virtualCamera;

        private void Start()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            var currentPlayer = Instantiate(player);
            currentPlayer.transform.position = playerStartPoint.position;
            currentPlayer.transform
                .DOScale(0, duration)
                .SetEase(ease)
                .From();

            virtualCamera.Follow = currentPlayer.transform;
        }
    }
}
