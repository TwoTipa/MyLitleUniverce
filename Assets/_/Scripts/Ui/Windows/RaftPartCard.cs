using System;
using _.Scripts.GameplayResources.MonoBehavior;
using _.Scripts.GameplayResources.ResourceContainers;
using _.Scripts.Rafts;
using _.Scripts.Rafts.RaftParts;
using MyBase.Common.Ui;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace _.Scripts.Ui.Windows
{
    public class RaftPartCard : WindowBase
    {
        [SerializeField] private GameObject resourceUiPrefab;
        private RaftPartSetting _setting;
        private RaftPart _part;
        private TextMeshProUGUI _countResourceField;
        private Object _newResourceUi;
        private Image _resourceImage;

        public void Initialize(RaftPartSetting setting, RaftPart part)
        {
            _setting = setting;
            _part = part;
        }

        public void OnClick()
        {
            var content = _part.SwitchContent(PartNames.Builder);
            Initialize(content.Model);
        }

        private void Initialize(GameObject model)
        {
            var builder = new Builder(_setting.NeedResources.ToArray(), _part);
            model.AddComponent<ResourceContainerBehavior>().Initialization(builder);

            var container = model.transform.GetComponentInChildren<VerticalLayoutGroup>();
            
            for (int i = 0; i < _setting.NeedResources.Count; i++)
            {
                _newResourceUi = Instantiate(resourceUiPrefab, container.transform);

                _resourceImage = _newResourceUi.GetComponentInChildren<Image>();
                _countResourceField = _newResourceUi.GetComponentInChildren<TextMeshProUGUI>();

                _countResourceField.text = _setting.NeedResources[i].Amount.ToString();
                _resourceImage.sprite = _setting.NeedResources[i].Image;
                
                _setting.NeedResources[i].Subscribe(_countResourceField);
            }
        }
    }
}