﻿using MagicFire.Mmorpg.AvatarInputState;

namespace MagicFire.Mmorpg
{
    using UnityEngine;
    using UnityEngine.Events;
    using System.Collections;
    using DG.Tweening;
    using MagicFire.Common.Plugin;

    [PrefabMonoSingleton(
        AssetTool.AuxiliaryPrefabsFolder + "/PlayerTarget.prefab",
        "Prefabs",
        "auxiliaryprefabs_bundle",
        "PlayerTarget")]
    public class PlayerTarget : MonoSingleton<PlayerTarget>
    {
        [SerializeField]
        private GameObject _camera;
        private Vector2 _startPoint;
        private float _startAngle;
        private bool _hasDown;

        private PlayerTarget()
        {

        }

        // Use this for initialization
        private void Start()
        {
            _camera = transform.Find("Main Camera").gameObject;
            tag = "DontDestroy";
            _hasDown = false;
        }

        // Update is called once per frame
        private void Update()
        {
            if (AvatarStateController.Instance == null)
            {
                return;
            }
            if (Input.GetMouseButtonDown(2))
            {
                _hasDown = true;
                _startPoint = Input.mousePosition;
                _startAngle = transform.localEulerAngles.y;
            }
            if (Input.GetMouseButtonUp(2))
            {
                _hasDown = false;
            }
            if (_hasDown)
            {
                transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, _startAngle + (Input.mousePosition.x - _startPoint.x) * 0.5f, 0);
            }
            var scrollValue = Input.GetAxis("Mouse ScrollWheel");
            var p = _camera.transform.localPosition;
            _camera.transform.localPosition = new Vector3(p.x, p.y + scrollValue * -10, p.z);
        }

        private void FixedUpdate()
        {
            if (AvatarStateController.Instance == null)
            {
                return;
            }
            transform.DOMove(AvatarStateController.Instance.transform.position, 1);
        }
    }

}