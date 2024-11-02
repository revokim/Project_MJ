//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/InputSystem/InventoryInputSystem.inputactions
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

public partial class @InventoryInputSystem: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InventoryInputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InventoryInputSystem"",
    ""maps"": [
        {
            ""name"": ""Inventory"",
            ""id"": ""4c927eff-8a74-4e6a-be52-69a19cc1b5a6"",
            ""actions"": [
                {
                    ""name"": ""DropWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""807fb22b-3a8a-47f1-8fd0-ac5bc25038d1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveInventoryCursor"",
                    ""type"": ""Button"",
                    ""id"": ""6d65b720-2a6f-4552-8e87-9e69e5fcc829"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d007c8ab-179c-44be-851a-35af83cea2f0"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DropWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0afcd981-2a26-4458-8f64-460bcf646d32"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInventoryCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""34fd725d-d8d8-48eb-b425-5644ad22b8b5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInventoryCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4ebc9cd-92a4-4791-85a2-844a11f37fee"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInventoryCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95533bd6-dfcf-47b2-9a2f-af69474c32c8"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveInventoryCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Inventory
        m_Inventory = asset.FindActionMap("Inventory", throwIfNotFound: true);
        m_Inventory_DropWeapon = m_Inventory.FindAction("DropWeapon", throwIfNotFound: true);
        m_Inventory_MoveInventoryCursor = m_Inventory.FindAction("MoveInventoryCursor", throwIfNotFound: true);
    }

    ~@InventoryInputSystem()
    {
        UnityEngine.Debug.Assert(!m_Inventory.enabled, "This will cause a leak and performance issues, InventoryInputSystem.Inventory.Disable() has not been called.");
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

    // Inventory
    private readonly InputActionMap m_Inventory;
    private List<IInventoryActions> m_InventoryActionsCallbackInterfaces = new List<IInventoryActions>();
    private readonly InputAction m_Inventory_DropWeapon;
    private readonly InputAction m_Inventory_MoveInventoryCursor;
    public struct InventoryActions
    {
        private @InventoryInputSystem m_Wrapper;
        public InventoryActions(@InventoryInputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @DropWeapon => m_Wrapper.m_Inventory_DropWeapon;
        public InputAction @MoveInventoryCursor => m_Wrapper.m_Inventory_MoveInventoryCursor;
        public InputActionMap Get() { return m_Wrapper.m_Inventory; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InventoryActions set) { return set.Get(); }
        public void AddCallbacks(IInventoryActions instance)
        {
            if (instance == null || m_Wrapper.m_InventoryActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InventoryActionsCallbackInterfaces.Add(instance);
            @DropWeapon.started += instance.OnDropWeapon;
            @DropWeapon.performed += instance.OnDropWeapon;
            @DropWeapon.canceled += instance.OnDropWeapon;
            @MoveInventoryCursor.started += instance.OnMoveInventoryCursor;
            @MoveInventoryCursor.performed += instance.OnMoveInventoryCursor;
            @MoveInventoryCursor.canceled += instance.OnMoveInventoryCursor;
        }

        private void UnregisterCallbacks(IInventoryActions instance)
        {
            @DropWeapon.started -= instance.OnDropWeapon;
            @DropWeapon.performed -= instance.OnDropWeapon;
            @DropWeapon.canceled -= instance.OnDropWeapon;
            @MoveInventoryCursor.started -= instance.OnMoveInventoryCursor;
            @MoveInventoryCursor.performed -= instance.OnMoveInventoryCursor;
            @MoveInventoryCursor.canceled -= instance.OnMoveInventoryCursor;
        }

        public void RemoveCallbacks(IInventoryActions instance)
        {
            if (m_Wrapper.m_InventoryActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInventoryActions instance)
        {
            foreach (var item in m_Wrapper.m_InventoryActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InventoryActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InventoryActions @Inventory => new InventoryActions(this);
    public interface IInventoryActions
    {
        void OnDropWeapon(InputAction.CallbackContext context);
        void OnMoveInventoryCursor(InputAction.CallbackContext context);
    }
}
