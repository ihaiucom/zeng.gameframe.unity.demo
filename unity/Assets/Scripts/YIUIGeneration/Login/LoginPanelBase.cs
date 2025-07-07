using System;
using YIUIBind;
using YIUIFramework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace YIUI.Login
{



    /// <summary>
    /// 由YIUI工具自动创建 请勿手动修改
    /// </summary>
    public abstract class LoginPanelBase:BasePanel
    {
        public const string PkgName = "Login";
        public const string ResName = "LoginPanel";
        
        public override EWindowOption WindowOption => EWindowOption.None;
        public override EPanelLayer Layer => EPanelLayer.Panel;
        public override EPanelOption PanelOption => EPanelOption.None;
        public override EPanelStackOption StackOption => EPanelStackOption.VisibleTween;
        public override int Priority => 0;
        public TMPro.TMP_InputField u_ComUsernameInput { get; private set; }
        public TMPro.TMP_InputField u_ComPasswordInput { get; private set; }
        public UnityEngine.UI.Toggle u_ComRememberLoginToggle { get; private set; }
        public UnityEngine.UI.Button u_ComRegisterButton { get; private set; }
        public UnityEngine.UI.Button u_ComLoginButton { get; private set; }
        public YIUIBind.UIDataValueString u_DataUsername { get; private set; }
        public YIUIBind.UIDataValueString u_DataPassword { get; private set; }
        public YIUIBind.UIDataValueBool u_DataRememberLogin { get; private set; }
        protected UIEventP0 u_EventClickLoginButton { get; private set; }
        protected UIEventHandleP0 u_EventClickLoginButtonHandle { get; private set; }
        protected UIEventP0 u_EventClickRegisterButton { get; private set; }
        protected UIEventHandleP0 u_EventClickRegisterButtonHandle { get; private set; }

        
        protected sealed override void UIBind()
        {
            u_ComUsernameInput = ComponentTable.FindComponent<TMPro.TMP_InputField>("u_ComUsernameInput");
            u_ComPasswordInput = ComponentTable.FindComponent<TMPro.TMP_InputField>("u_ComPasswordInput");
            u_ComRememberLoginToggle = ComponentTable.FindComponent<UnityEngine.UI.Toggle>("u_ComRememberLoginToggle");
            u_ComRegisterButton = ComponentTable.FindComponent<UnityEngine.UI.Button>("u_ComRegisterButton");
            u_ComLoginButton = ComponentTable.FindComponent<UnityEngine.UI.Button>("u_ComLoginButton");
            u_DataUsername = DataTable.FindDataValue<YIUIBind.UIDataValueString>("u_DataUsername");
            u_DataPassword = DataTable.FindDataValue<YIUIBind.UIDataValueString>("u_DataPassword");
            u_DataRememberLogin = DataTable.FindDataValue<YIUIBind.UIDataValueBool>("u_DataRememberLogin");
            u_EventClickLoginButton = EventTable.FindEvent<UIEventP0>("u_EventClickLoginButton");
            u_EventClickLoginButtonHandle = u_EventClickLoginButton.Add(OnEventClickLoginButtonAction);
            u_EventClickRegisterButton = EventTable.FindEvent<UIEventP0>("u_EventClickRegisterButton");
            u_EventClickRegisterButtonHandle = u_EventClickRegisterButton.Add(OnEventClickRegisterButtonAction);

        }

        protected sealed override void UnUIBind()
        {
            u_EventClickLoginButton.Remove(u_EventClickLoginButtonHandle);
            u_EventClickRegisterButton.Remove(u_EventClickRegisterButtonHandle);

        }
     
        protected virtual void OnEventClickLoginButtonAction(){}
        protected virtual void OnEventClickRegisterButtonAction(){}
   
   
    }
}