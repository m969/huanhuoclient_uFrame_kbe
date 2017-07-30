﻿using System;
using MagicFire.Common;
using UnityEngine.UI;

namespace MagicFire.Mmorpg.UI
{
    using UnityEngine;
    using System.Collections;

    public class CharacterInfoPanel : Panel
    {
        [SerializeField]
        private Text _levelText;
        private int _level;
        [SerializeField]
        private Text _levelPeriodText;
        private int _levelPeriod;
        [SerializeField]
        private Text _hpMaxText;
        private int _hpMax;
        [SerializeField]
        private Text _spMaxText;
        private int _spMax;

        private KBEngine.Model _mainAvatar
        {
            get
            {
                return KBEngine.KBEngineApp.app.player() as KBEngine.Avatar;
            }
        }

        protected override void Start()
        {
            base.Start();
            transform.SetParent(UiManager.Instance.CanvasLayers[1].transform);
            transform.localPosition = new Vector3(0, 0, 0);
            transform.localScale = new Vector3(1, 1, 1);
        }

        //当主玩家激活
        public void OnMainAvatarActive(KBEngine.Model avatar)
        {
            if (_mainAvatar != null)
            {
                Subscribe();
            }
            else
                Debug.LogError("CharacterInfoPanel.OnAvatarActive avatar == null!");
        }

        //当主玩家无效
        public void OnMainAvatarInvalid(KBEngine.Model avatar)
        {
            Desubscribe();
        }

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Desubscribe();
        }

        //订阅属性更新、方法调用
        private void Subscribe()
        {
            if (_mainAvatar == null)
                return;
            //_avatar.SubscribePropertyUpdate(AvatarPropertys.Level, Level_Up);
            _mainAvatar.SubscribePropertyUpdate(AvatarPropertys.LevelName, LevelName_Up);
            //_avatar.SubscribePropertyUpdate(AvatarPropertys.LevelPeriod, LevelPeriod_Up);
            _mainAvatar.SubscribePropertyUpdate(AvatarPropertys.LevelPeriodName, LevelPeriodName_Up);
            _mainAvatar.SubscribePropertyUpdate(CombatPropertys.HpMax, HpMax_Up);
            _mainAvatar.SubscribePropertyUpdate(AvatarPropertys.SpMax, SpMax_Up);
            _mainAvatar.SubscribeMethodCall("OnEntityDestoy", OnModelDestroy);
        }

        //取消订阅
        private void Desubscribe()
        {
            if (_mainAvatar == null)
                return;
            //_avatar.DesubscribeMethodCall(AvatarPropertys.Level, Level_Up);
            _mainAvatar.DesubscribeMethodCall(AvatarPropertys.LevelName, LevelName_Up);
            //_avatar.DesubscribeMethodCall(AvatarPropertys.LevelPeriod, LevelPeriod_Up);
            _mainAvatar.DesubscribeMethodCall(AvatarPropertys.LevelPeriodName, LevelPeriodName_Up);
            _mainAvatar.DesubscribeMethodCall(CombatPropertys.HpMax, HpMax_Up);
            _mainAvatar.DesubscribeMethodCall(AvatarPropertys.SpMax, SpMax_Up);
            _mainAvatar.DesubscribeMethodCall("OnEntityDestoy", OnModelDestroy);
        }

        private void OnModelDestroy(object[] objects)
        {
            Desubscribe();
        }

        ////等级更新
        //private void Level_Up(object old)
        //{
        //    var level = (int)_avatar.getDefinedProperty(AvatarPropertys.Level);
        //    if (_level == level)
        //        return;

        //    _level = level;
        //    if (_levelText)
        //        _levelText.text = level + "";

        //    var levelPeriod = (int)_avatar.getDefinedProperty(AvatarPropertys.LevelPeriod);
        //    _levelPeriod = levelPeriod;
        //    if (_levelPeriodText)
        //        _levelPeriodText.text = levelPeriod + "";
        //}

        private void LevelName_Up(object old)
        {
            _levelText.text = (string)_mainAvatar.getDefinedProperty(AvatarPropertys.LevelName);
        }

        ////等阶更新
        //private void LevelPeriod_Up(object old)
        //{
        //    var levelPeriod = (int)_avatar.getDefinedProperty(AvatarPropertys.LevelPeriod);
        //    if (_levelPeriod == levelPeriod)
        //        return;

        //    _levelPeriod = levelPeriod;
        //    if (_levelPeriodText)
        //        _levelPeriodText.text = levelPeriod + "";
        //}

        private void LevelPeriodName_Up(object old)
        {
            _levelPeriodText.text = (string)_mainAvatar.getDefinedProperty(AvatarPropertys.LevelPeriodName);
        }

        private void HpMax_Up(object old)
        {
            int hpMax = (int)((KBEngine.Model)_mainAvatar).getDefinedProperty(CombatPropertys.HpMax);
            if (Equals(_hpMax, hpMax))
                return;
            _hpMaxText.text = "" + hpMax;
        }

        private void SpMax_Up(object old)
        {
            int spMax = (int)((KBEngine.Model)_mainAvatar).getDefinedProperty(CombatPropertys.HpMax);
            if (Equals(_spMax, spMax))
                return;
            _spMaxText.text = "" + spMax;
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }

}