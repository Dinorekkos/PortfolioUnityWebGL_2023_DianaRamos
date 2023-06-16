using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DINO
{
    public class HomeUI : MonoBehaviour 
    {
        [SerializeField] private Button _cityButton;
        [SerializeField] private Button _homeButton;
        [SerializeField] private CanvasGroup homeCanvasGroup;
        [SerializeField] private CanvasGroup cityCanvasGroup;
        
        void Start()
        {
            _homeButton.image.DOFade(0, 0);
            _cityButton.transform.DOScale(1.2f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InQuad);
            _cityButton.onClick.AddListener(() =>
            {
                HomeController.Instance.GoToCity();
                HandleUIVisible();
            });
            _homeButton.onClick.AddListener(() =>
            {
                HomeController.Instance.GoToHome();
                HandleUIVisible();
            });
            
        }
        

        void Update()
        {
            
        }
        
        void HandleUIVisible()
        {
            CameraStates cameraState = CameraController.Instance.CameraState;
            switch (cameraState)
            {
                case CameraStates.Home:
                    homeCanvasGroup.DOFade(1, 0.3f);
                    cityCanvasGroup.DOFade(0, 0.3f);
                    break;
                case CameraStates.City:
                    homeCanvasGroup.DOFade(0, 0.3f);
                    cityCanvasGroup.DOFade(1, 0.5f).OnComplete(()=>
                    {
                        _homeButton.image.DOFade(1, 0.3f);
                    });

                    break;
                
            }
        }
    }
}