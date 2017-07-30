﻿/* --------------------------
 * Company: MagicFire Studio
 *   Autor: Changmin Yang
 *    Date: 2017/02/20
 *    描述： 实体属性的UI面板，将实体的一些比较主要的属性可视化，比如名字、血条、状态等；
 * -------------------------- */
using System;

namespace MagicFire.Mmorpg.UI
{
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    using MagicFire.Common;
    using KBEngine;
    using DG.Tweening;

    public class EntityPanelView : View
    {
        private Text _nameText;//用于显示实体姓名的Text组件
        protected string _entityName;//实体的姓名

        protected virtual void FixedUpdate()
        {
            if (Model == null)
                return;
            var v = Camera.main.WorldToScreenPoint(((KBEngine.Model)Model).position);
            transform.DOMove(new Vector3(v.x, v.y, 0), 0.1f);
        }

        public override void InitializeView(IModel model)
        {
            base.InitializeView(model);
            transform.SetParent(SingletonGather.UiManager.CanvasLayerBack.transform);

            var entityPanelPosition = Camera.main.WorldToScreenPoint(((KBEngine.Model)model).position);
            entityPanelPosition = new Vector3(entityPanelPosition.x, entityPanelPosition.y, 0);

            transform.localPosition = entityPanelPosition;
            transform.localEulerAngles = Vector3.zero;
            transform.localScale = new Vector3(1, 1, 1);

            _nameText = transform.Find("Name").GetComponentInChildren<Text>();

            HandleEntityNameUpdate(0);

            model.SubscribePropertyUpdate(EntityPropertys.EntityName, HandleEntityNameUpdate);//订阅姓名属性的更新
        }

        public override void OnModelDestroy(object[] objects)
        {
            if (Model != null)
            {
                Model.DesubscribePropertyUpdate(EntityPropertys.EntityName, HandleEntityNameUpdate);//取消订阅
            }
            base.OnModelDestroy(objects);
        }

        //处理实体姓名的更新：如果实体的姓名变了，那么View的显示实体姓名的Text组件（_nameText）也要相应作出改变
        private void HandleEntityNameUpdate(object old)
        {
            if (_entityName == ((KBEngine.Model)Model).getDefinedProperty(EntityPropertys.EntityName) as string) return;
            if (_nameText)
            {
                _nameText.text = _entityName = ((KBEngine.Model)Model).getDefinedProperty(EntityPropertys.EntityName) as string;
                gameObject.name = ((KBEngine.Model)Model).className + ":" + _entityName;
            }
        }
    }
}