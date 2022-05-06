//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Settings/Input/InputSystemActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputSystemActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystemActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystemActions"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""a64ff132-3e66-49d8-b084-829c423a46f4"",
            ""actions"": [
                {
                    ""name"": ""Atack"",
                    ""type"": ""Button"",
                    ""id"": ""526a0422-db52-4a0c-aabe-af21e31262e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""86ee75fd-12b7-478f-b4ec-060c7fca574d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""1486f032-3ad6-44ce-88ac-d0e18769f4c7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""4417240f-27ed-4eea-ad22-6a4f32bec5ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""PassThrough"",
                    ""id"": ""463dda0e-bd4a-428c-ab5a-16cef0bdcd2e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""052e5b0e-fbd6-4122-b50e-3306bf36a27a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Recharge"",
                    ""type"": ""Button"",
                    ""id"": ""05092d54-97a9-4304-af06-5c570b3b8ce4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Heal"",
                    ""type"": ""Button"",
                    ""id"": ""27e5c488-8956-416e-89a4-94d8942a2c63"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MeleAtack"",
                    ""type"": ""Button"",
                    ""id"": ""e1e4f1cd-3120-49dc-a98f-eb916cccbcf1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c0b0bf12-97e9-4511-afbf-cee3e064697b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Atack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f06f8c22-0aac-47a1-8231-754f497e63b3"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""hor"",
                    ""id"": ""eed3f231-4206-4344-9ca8-ea959e7b9716"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0c3ef4d8-d1e7-49ef-8ed0-af169f8f5572"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b747218d-7bce-45f2-8eb1-0fbfb9dbb10d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""ver"",
                    ""id"": ""4465a3c0-409b-4eec-82b6-11d89d6aa11d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0da964bb-3dc6-4e1b-8d52-1f5fc17d85b3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a5216556-5c17-4ff1-a72f-42cca51f96e2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4662ea02-38c2-4f8c-a43d-a890760c4b3d"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67e79f7a-7ae1-4b6b-bcf5-07f1b641f925"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca2a491c-3aaf-4677-9bc6-dbfdf1f2334a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""848ec67d-a263-4a81-a696-df27a832cbfc"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Recharge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d24f3389-30be-47c5-a96c-153740ba7030"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Heal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40a14370-92c7-4e24-acfa-bee99cd78851"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MeleAtack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menus&Pause"",
            ""id"": ""666107a3-0ab3-4f70-8554-5b5430ee0373"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""4114c800-b863-4471-b669-6aa3b1a64006"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""746997c7-e69c-4828-85cd-85381f9b5dc0"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_Atack = m_GamePlay.FindAction("Atack", throwIfNotFound: true);
        m_GamePlay_Movement = m_GamePlay.FindAction("Movement", throwIfNotFound: true);
        m_GamePlay_Jump = m_GamePlay.FindAction("Jump", throwIfNotFound: true);
        m_GamePlay_Interact = m_GamePlay.FindAction("Interact", throwIfNotFound: true);
        m_GamePlay_Run = m_GamePlay.FindAction("Run", throwIfNotFound: true);
        m_GamePlay_Crouch = m_GamePlay.FindAction("Crouch", throwIfNotFound: true);
        m_GamePlay_Recharge = m_GamePlay.FindAction("Recharge", throwIfNotFound: true);
        m_GamePlay_Heal = m_GamePlay.FindAction("Heal", throwIfNotFound: true);
        m_GamePlay_MeleAtack = m_GamePlay.FindAction("MeleAtack", throwIfNotFound: true);
        // Menus&Pause
        m_MenusPause = asset.FindActionMap("Menus&Pause", throwIfNotFound: true);
        m_MenusPause_Pause = m_MenusPause.FindAction("Pause", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_Atack;
    private readonly InputAction m_GamePlay_Movement;
    private readonly InputAction m_GamePlay_Jump;
    private readonly InputAction m_GamePlay_Interact;
    private readonly InputAction m_GamePlay_Run;
    private readonly InputAction m_GamePlay_Crouch;
    private readonly InputAction m_GamePlay_Recharge;
    private readonly InputAction m_GamePlay_Heal;
    private readonly InputAction m_GamePlay_MeleAtack;
    public struct GamePlayActions
    {
        private @InputSystemActions m_Wrapper;
        public GamePlayActions(@InputSystemActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Atack => m_Wrapper.m_GamePlay_Atack;
        public InputAction @Movement => m_Wrapper.m_GamePlay_Movement;
        public InputAction @Jump => m_Wrapper.m_GamePlay_Jump;
        public InputAction @Interact => m_Wrapper.m_GamePlay_Interact;
        public InputAction @Run => m_Wrapper.m_GamePlay_Run;
        public InputAction @Crouch => m_Wrapper.m_GamePlay_Crouch;
        public InputAction @Recharge => m_Wrapper.m_GamePlay_Recharge;
        public InputAction @Heal => m_Wrapper.m_GamePlay_Heal;
        public InputAction @MeleAtack => m_Wrapper.m_GamePlay_MeleAtack;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @Atack.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAtack;
                @Atack.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAtack;
                @Atack.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnAtack;
                @Movement.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Interact.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnInteract;
                @Run.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRun;
                @Crouch.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnCrouch;
                @Recharge.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRecharge;
                @Recharge.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRecharge;
                @Recharge.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnRecharge;
                @Heal.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnHeal;
                @Heal.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnHeal;
                @Heal.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnHeal;
                @MeleAtack.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMeleAtack;
                @MeleAtack.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMeleAtack;
                @MeleAtack.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMeleAtack;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Atack.started += instance.OnAtack;
                @Atack.performed += instance.OnAtack;
                @Atack.canceled += instance.OnAtack;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Recharge.started += instance.OnRecharge;
                @Recharge.performed += instance.OnRecharge;
                @Recharge.canceled += instance.OnRecharge;
                @Heal.started += instance.OnHeal;
                @Heal.performed += instance.OnHeal;
                @Heal.canceled += instance.OnHeal;
                @MeleAtack.started += instance.OnMeleAtack;
                @MeleAtack.performed += instance.OnMeleAtack;
                @MeleAtack.canceled += instance.OnMeleAtack;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);

    // Menus&Pause
    private readonly InputActionMap m_MenusPause;
    private IMenusPauseActions m_MenusPauseActionsCallbackInterface;
    private readonly InputAction m_MenusPause_Pause;
    public struct MenusPauseActions
    {
        private @InputSystemActions m_Wrapper;
        public MenusPauseActions(@InputSystemActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_MenusPause_Pause;
        public InputActionMap Get() { return m_Wrapper.m_MenusPause; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenusPauseActions set) { return set.Get(); }
        public void SetCallbacks(IMenusPauseActions instance)
        {
            if (m_Wrapper.m_MenusPauseActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_MenusPauseActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_MenusPauseActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_MenusPauseActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_MenusPauseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public MenusPauseActions @MenusPause => new MenusPauseActions(this);
    public interface IGamePlayActions
    {
        void OnAtack(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnRecharge(InputAction.CallbackContext context);
        void OnHeal(InputAction.CallbackContext context);
        void OnMeleAtack(InputAction.CallbackContext context);
    }
    public interface IMenusPauseActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
