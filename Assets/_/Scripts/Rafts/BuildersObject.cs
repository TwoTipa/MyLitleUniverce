using System;
using System.Collections.Generic;
using _.Scripts.GameplayResources;
using _.Scripts.GameplayResources.ResourceContainers;
using MyBase.Common.GameplayResources;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace _.Scripts.Rafts
{
    public class BuildersObject : MonoBehaviour
    {
        [SerializeField] public bool isBuild = false;
        private ResourceName _name;
        private int _count;
        
        
        
        private ResourceContainer _containerForBuild;
        
        public void OnBuild()
        {
            isBuild = true;
        }

        private void Start()
        {
            if (!isBuild)
            {
                
                //_containerForBuild = new Builder(needForBuild.ToArray(), this);
            }
        }
        
        
    }

    
    #region Editor

#if UNITY_EDITOR

    [CustomEditor(typeof(BuildersObject))]
    public class BuildersObjectEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            BuildersObject buildersObject = (BuildersObject)target;

            if(buildersObject.isBuild) return;
            
            DrawNeedResource();
        }

        private void DrawNeedResource()
        {
            EditorGUILayout.LabelField("Need Resource");

            EditorGUILayout.BeginHorizontal();
            
            EditorGUILayout.LabelField("Resource Name");
            
            EditorGUILayout.LabelField("Resource Count");
            
            EditorGUILayout.EndHorizontal();

        }
    }
    
#endif

    #endregion
    
    
}