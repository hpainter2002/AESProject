﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AES.Web.ManagementService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ManagementService.IManagementSvc")]
    public interface IManagementSvc {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagementSvc/GetStoreList", ReplyAction="http://tempuri.org/IManagementSvc/GetStoreListResponse")]
        AES.Shared.Contracts.StoreContract[] GetStoreList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagementSvc/GetStoreList", ReplyAction="http://tempuri.org/IManagementSvc/GetStoreListResponse")]
        System.Threading.Tasks.Task<AES.Shared.Contracts.StoreContract[]> GetStoreListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagementSvc/GetUserList", ReplyAction="http://tempuri.org/IManagementSvc/GetUserListResponse")]
        AES.Shared.Contracts.EmployeeUserContract[] GetUserList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagementSvc/GetUserList", ReplyAction="http://tempuri.org/IManagementSvc/GetUserListResponse")]
        System.Threading.Tasks.Task<AES.Shared.Contracts.EmployeeUserContract[]> GetUserListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagementSvc/UpdateStoreInfo", ReplyAction="http://tempuri.org/IManagementSvc/UpdateStoreInfoResponse")]
        bool UpdateStoreInfo(AES.Shared.Contracts.StoreContract store);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagementSvc/UpdateStoreInfo", ReplyAction="http://tempuri.org/IManagementSvc/UpdateStoreInfoResponse")]
        System.Threading.Tasks.Task<bool> UpdateStoreInfoAsync(AES.Shared.Contracts.StoreContract store);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagementSvc/UpdateUserInfo", ReplyAction="http://tempuri.org/IManagementSvc/UpdateUserInfoResponse")]
        bool UpdateUserInfo(AES.Shared.Contracts.EmployeeUserContract user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagementSvc/UpdateUserInfo", ReplyAction="http://tempuri.org/IManagementSvc/UpdateUserInfoResponse")]
        System.Threading.Tasks.Task<bool> UpdateUserInfoAsync(AES.Shared.Contracts.EmployeeUserContract user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagementSvc/CreateNewStore", ReplyAction="http://tempuri.org/IManagementSvc/CreateNewStoreResponse")]
        bool CreateNewStore(AES.Shared.Contracts.StoreContract store);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagementSvc/CreateNewStore", ReplyAction="http://tempuri.org/IManagementSvc/CreateNewStoreResponse")]
        System.Threading.Tasks.Task<bool> CreateNewStoreAsync(AES.Shared.Contracts.StoreContract store);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagementSvc/CreateNewUser", ReplyAction="http://tempuri.org/IManagementSvc/CreateNewUserResponse")]
        bool CreateNewUser(AES.Shared.Contracts.EmployeeUserContract user, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IManagementSvc/CreateNewUser", ReplyAction="http://tempuri.org/IManagementSvc/CreateNewUserResponse")]
        System.Threading.Tasks.Task<bool> CreateNewUserAsync(AES.Shared.Contracts.EmployeeUserContract user, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IManagementSvcChannel : AES.Web.ManagementService.IManagementSvc, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ManagementSvcClient : System.ServiceModel.ClientBase<AES.Web.ManagementService.IManagementSvc>, AES.Web.ManagementService.IManagementSvc {
        
        public ManagementSvcClient() {
        }
        
        public ManagementSvcClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ManagementSvcClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ManagementSvcClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ManagementSvcClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public AES.Shared.Contracts.StoreContract[] GetStoreList() {
            return base.Channel.GetStoreList();
        }
        
        public System.Threading.Tasks.Task<AES.Shared.Contracts.StoreContract[]> GetStoreListAsync() {
            return base.Channel.GetStoreListAsync();
        }
        
        public AES.Shared.Contracts.EmployeeUserContract[] GetUserList() {
            return base.Channel.GetUserList();
        }
        
        public System.Threading.Tasks.Task<AES.Shared.Contracts.EmployeeUserContract[]> GetUserListAsync() {
            return base.Channel.GetUserListAsync();
        }
        
        public bool UpdateStoreInfo(AES.Shared.Contracts.StoreContract store) {
            return base.Channel.UpdateStoreInfo(store);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateStoreInfoAsync(AES.Shared.Contracts.StoreContract store) {
            return base.Channel.UpdateStoreInfoAsync(store);
        }
        
        public bool UpdateUserInfo(AES.Shared.Contracts.EmployeeUserContract user) {
            return base.Channel.UpdateUserInfo(user);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateUserInfoAsync(AES.Shared.Contracts.EmployeeUserContract user) {
            return base.Channel.UpdateUserInfoAsync(user);
        }
        
        public bool CreateNewStore(AES.Shared.Contracts.StoreContract store) {
            return base.Channel.CreateNewStore(store);
        }
        
        public System.Threading.Tasks.Task<bool> CreateNewStoreAsync(AES.Shared.Contracts.StoreContract store) {
            return base.Channel.CreateNewStoreAsync(store);
        }
        
        public bool CreateNewUser(AES.Shared.Contracts.EmployeeUserContract user, string password) {
            return base.Channel.CreateNewUser(user, password);
        }
        
        public System.Threading.Tasks.Task<bool> CreateNewUserAsync(AES.Shared.Contracts.EmployeeUserContract user, string password) {
            return base.Channel.CreateNewUserAsync(user, password);
        }
    }
}
