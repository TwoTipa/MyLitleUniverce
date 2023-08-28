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
            var canvas = model.transform.GetComponentInChildren<Canvas>();
            _newResourceUi = Instantiate(resourceUiPrefab, canvas.transform);

            _resourceImage = _newResourceUi.GetComponentInChildren<Image>();
            _countResourceField = _newResourceUi.GetComponentInChildren<TextMeshProUGUI>();

            _countResourceField.text = _setting.NeedResources[0].Amount.ToString();

            var builder = new Builder(_setting.NeedResources, _part);
            model.AddComponent<ResourceContainerBehavior>().Initialization(builder);
            
            builder.Subscribe(_countResourceField);
            Debug.Log($"Нужно {_setting.NeedResources[0].Amount} {_setting.NeedResources[0].Name} для того чтобы построить {_setting.Name}");
        }
    }
}