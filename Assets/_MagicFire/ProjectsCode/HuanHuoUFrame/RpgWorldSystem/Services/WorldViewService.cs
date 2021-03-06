using uFrame.MVVM.ViewModels;

namespace MagicFire.HuanHuoUFrame{
    using HuanHuoUFrame;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.IOC;
    using uFrame.Kernel;
    using uFrame.MVVM;
    using UniRx;
    using UnityEngine;
    using PathologicalGames;
    using uFrame.MVVM.Views;
    
    
    public class WorldViewService : WorldViewServiceBase {

        [SerializeField]
        private GameObject _masterCanvasPrefab;

        [SerializeField]
        private GameObject _eventSystemPrefab;

        [SerializeField]
        private GameObject _canvas3DPrefab;

        [SerializeField]
        private GameObject _playerTargetPrefab;


        private SceneState _worldSceneState = SceneState.Destructed;
        private SceneState _loginSceneState = SceneState.Loaded;

        private GameObject _masterCanvas;

        private GameObject _canvas3D;

        private GameObject _eventSystem;

        private GameObject _uiManager;

        private List<KBEngine.Entity> _entitiesPool = new List<KBEngine.Entity>();


        public GameObject MasterCanvas
        {
            get
            {
                if (_masterCanvas == null)
                {
                    _masterCanvas = GameObject.Find("MasterCanvas");
                    _eventSystem = GameObject.Find("EventSystem");
                    _uiManager = GameObject.Find("UIManager");
                    if (_uiManager != null)
                        DontDestroyOnLoad(_uiManager);
                    if (_masterCanvas == null)
                        _masterCanvas = Instantiate(_masterCanvasPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    if (_masterCanvas != null)
                        DontDestroyOnLoad(_masterCanvas);
                    if (_eventSystem == null)
                        _eventSystem = Instantiate(_eventSystemPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                    if (_eventSystem != null)
                        DontDestroyOnLoad(_eventSystem);
                }
                return _masterCanvas;
            }
        }

        public GameObject Canvas3D
        {
            get
            {
                if (_canvas3D == null)
                {
                    _canvas3D = GameObject.Find("3DCanvas");
                    if (_canvas3D == null)
                    {
                        _canvas3D = Instantiate(_canvas3DPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        if (_canvas3D != null)
                        {
                            DontDestroyOnLoad(_canvas3D);
                            _canvas3D.transform.eulerAngles = new Vector3(90, 0, 0);
                        }
                    }
                }
                return _canvas3D;
            }
        }



        /// <summary>
        /// This method is invoked whenever the kernel is loading
        /// Since the kernel lives throughout the entire lifecycle  of the game, this will only be invoked once.
        /// </summary>
        public override void Setup() {
            base.Setup();
            // Use the line below to subscribe to events
            // this.OnEvent<MyEvent>().Subscribe(myEventInstance => { TODO });

            MasterCanvas.ToString();
            Canvas3D.ToString();

            this.OnEvent<OnMainAvatarEnterSpaceEvent>().ObserveOnMainThread().Subscribe(OnMainAvatarEnterSpace);
            this.OnEvent<OnMainAvatarLeaveSpaceEvent>().ObserveOnMainThread().Subscribe(OnMainAvatarLeaveSpace);

            this.OnEvent<onEnterWorldEvent>().ObserveOnMainThread().Subscribe(OnEnterWorld);
            this.OnEvent<onLeaveWorldEvent>().ObserveOnMainThread().Subscribe(OnLeaveWorld);
            this.OnEvent<set_positionEvent>().ObserveOnMainThread().Subscribe(Set_Position);
            this.OnEvent<set_directionEvent>().ObserveOnMainThread().Subscribe(Set_Direction);
            this.OnEvent<updatePositionEvent>().ObserveOnMainThread().Subscribe(UpdatePosition);

            this.OnEvent<SceneLoaderEvent>()
                .Where(x => x.Name == "LoginScene")
                .Where(x => x.State == SceneState.Destructed)
                .Subscribe(evt =>
                {
                    _loginSceneState = SceneState.Destructed;
                    MasterCanvas.GetComponentInChildren<LoginPanel>().gameObject.SetActive(false);
                });
        }

        private void OnMainAvatarEnterSpace(OnMainAvatarEnterSpaceEvent evt)
        {
            Debug.Log("OnMainAvatarEnterSpace");

            if (_loginSceneState == SceneState.Destructed)
            {
                _worldSceneState = SceneState.Destructed;
                this.Publish(new LoadSceneCommand()
                {
                    SceneName = evt.SpaceName,
                    RestrictToSingleScene = true
                });

                _worldSceneState = SceneState.Loaded;
                InstantiateAllViews();
            }
            else
            {
                this.OnEvent<SceneLoaderEvent>()
                    .Where(x => x.Name == "LoginScene")
                    .Where(x => x.State == SceneState.Destructed)
                    .Subscribe(evnt => 
                    {
                        _worldSceneState = SceneState.Destructed;
                        this.Publish(new LoadSceneCommand()
                        {
                            SceneName = evt.SpaceName,
                            RestrictToSingleScene = true
                        });
                        _worldSceneState = SceneState.Loaded;
                        InstantiateAllViews();
                    });
            }
        }

        private void OnMainAvatarLeaveSpace(OnMainAvatarLeaveSpaceEvent evt)
        {
            Debug.Log("OnMainAvatarLeaveSpace");
            KBEngine.Event.fireIn("OnLeaveSpaceClientInputInValid");
        }

        private EntityCommonView InstantiateModelView(KBEngine.Entity entity)
        {
            EntityCommonView view = null;
            var viewType = entity.className.Replace("ViewModel", "View");
            var viewPool = PoolManager.Pools[viewType + "Pool"];
            if (viewPool != null)
            {
                var viewModel = entity as EntityCommonViewModel;
                if (viewModel != null)
                {
                    Transform viewPrefab;
                    if (entity.className == "AvatarViewModel")
                        viewPrefab = viewPool.prefabs["AvatarView"];
                    else
                        viewPrefab = viewPool.prefabs[viewModel.entityName];
                    if (viewPrefab != null)
                        view = viewPool.SpawnEntityCommonView(viewPrefab, viewModel);
                }
            }
            return view;
        }

        private EntityCommonView InstantiateRingView(KBEngine.Entity entity)
        {
            EntityCommonView view = null;

            var entityType = entity.className.Replace("ViewModel", "");
            var viewPool = PoolManager.Pools[entityType + "ViewPool"];
            if (viewPool != null)
            {
                var viewModel = entity as EntityCommonViewModel;
                if (viewModel != null)
                {
                    var viewPrefab = viewPool.prefabs[entityType + "RingView"];
                    if (viewPrefab != null)
                        view = viewPool.SpawnEntityCommonView(viewPrefab, viewModel);
                }
            }
            return view;
        }

        private EntityCommonView InstantiatePanelView(KBEngine.Entity entity)
        {
            EntityCommonView view = null;

            var entityType = entity.className.Replace("ViewModel", "");
            var viewPool = PoolManager.Pools[entityType + "ViewPool"];
            if (viewPool != null)
            {
                var viewModel = entity as EntityCommonViewModel;
                if (viewModel != null)
                {
                    var viewPrefab = viewPool.prefabs[entityType + "PanelView"];
                    if (viewPrefab != null)
                        view = viewPool.SpawnEntityCommonView(viewPrefab, viewModel);
                }
            }
            return view;
        }

        private void InstantiateViews(KBEngine.Entity entity)
        {
            if (entity.className != "CampViewModel" && entity.className != "SpaceViewModel" && entity.renderObj == null)
            {
                var modelView = InstantiateModelView(entity);

                if (entity.isPlayer())
                {
                    if (modelView != null)
                    {
                        modelView.gameObject.AddComponent<AvatarStateController>();
                    }
                    AvatarStateController.Instance.gameObject.SetActive(true);
                    AvatarStateController.Instance.Init(modelView as AvatarView);
                    Instantiate(_playerTargetPrefab);

                    var viewPool = PoolManager.Pools["AvatarViewPool"];
                    if (viewPool != null)
                    {
                        var viewModel = entity as EntityCommonViewModel;
                        if (viewModel != null)
                        {
                            var viewPrefab = viewPool.prefabs["MainAvatarInfoPanelView"];
                            if (viewPrefab != null)
                            {
                                var mainAvatarInfoPanelView = viewPool.SpawnEntityCommonView(viewPrefab, viewModel);
                            }
                        }
                    }
                }

                if (entity.className == "AvatarViewModel")
                {
                    var ringView = InstantiateRingView(entity);
                    var panelView = InstantiatePanelView(entity);
                }
            }
        }

        private void InstantiateAllViews()
        {
            foreach (var entity in _entitiesPool)
            {
                InstantiateViews(entity);
            }
        }

        private void OnEnterWorld(onEnterWorldEvent evt)
        {

            if (_worldSceneState != SceneState.Loaded)
            {
                _entitiesPool.Add(evt.Entity);
                return;
            }

            var entity = evt.Entity;
            InstantiateViews(entity);
            //if (entity.className != "CampViewModel" && entity.className != "SpaceViewModel" && entity.renderObj == null)
            //{
            //    var modleView = InstantiateView(entity) as EntityCommonView;

            //    if (entity.isPlayer())
            //    {
            //        if (modleView != null)
            //        {
            //            modleView.gameObject.AddComponent<AvatarStateController>();
            //        }
            //        AvatarStateController.Instance.gameObject.SetActive(true);
            //        AvatarStateController.Instance.Init(modleView as AvatarView);
            //        Instantiate(_playerTargetPrefab);

            //        var viewPool = PoolManager.Pools["AvatarViewPool"];
            //        if (viewPool != null)
            //        {
            //            var viewModel = entity as EntityCommonViewModel;
            //            if (viewModel != null)
            //            {
            //                var viewPrefab = viewPool.prefabs["MainAvatarInfoPanelView"];
            //                if (viewPrefab != null)
            //                {
            //                    var mainAvatarInfoPanelView = viewPool.SpawnView(viewPrefab, viewModel) as EntityCommonView;
            //                }
            //            }
            //        }
            //    }

            //    if (entity.className == "AvatarViewModel")
            //    {
            //        var ringView = InstantiateRingView(entity) as EntityCommonView;
            //        var panelView = InstantiatePanelView(entity) as EntityCommonView;
            //    }
            //}
        }

        private void OnLeaveWorld(onLeaveWorldEvent evt)
        {
            var entity = evt.Entity;
            if (entity.renderObj == null)
                return;

            var viewObj = (GameObject)entity.renderObj;
            if (viewObj.activeInHierarchy == true)
            {
                viewObj.transform.parent.GetComponent<SpawnPool>().Despawn(viewObj.transform);
                entity.renderObj = null;
            }
            viewObj.GetComponent<ViewBase>().ViewModelObject = null;
        }

        private void Set_Position(set_positionEvent evt)
        {
            //var entity = evt.Entity;
            //if (entity.renderObj == null)
            //    return;

            //GameObject go = ((UnityEngine.GameObject)entity.renderObj);
            //Vector3 currpos = new Vector3(entity.position.x, entity.position.z, go.transform.position.z);
            //go.GetComponent<EntityCommonView>().destPosition = currpos;
            //go.GetComponent<EntityCommonView>().position = currpos;
        }

        private void Set_Direction(set_directionEvent evt)
        {
            //var entity = evt.Entity;
            //if (entity.renderObj == null)
            //    return;

            //((UnityEngine.GameObject)entity.renderObj).GetComponent<EntityCommonView>().destDirection =
            //    new Vector3(entity.direction.y, entity.direction.z, entity.direction.x);
        }

        private void UpdatePosition(updatePositionEvent evt)
        {
            //var entity = evt.Entity;

            //if (entity.renderObj == null)
            //    return;

            //EntityCommonView EntityCommonView = ((UnityEngine.GameObject)entity.renderObj).GetComponent<EntityCommonView>();
            //GameObject go = ((UnityEngine.GameObject)entity.renderObj);
            //EntityCommonView.destPosition = new Vector3(entity.position.x, entity.position.z, go.transform.position.z);
        }
    }
}
