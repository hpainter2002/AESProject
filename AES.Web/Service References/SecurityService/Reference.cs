﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AES.Web.SecurityService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SecurityService.ISecuritySvc")]
    public interface ISecuritySvc {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecuritySvc/ValidateUser", ReplyAction="http://tempuri.org/ISecuritySvc/ValidateUserResponse")]
        AES.Shared.Contracts.ApplicantInfoContract ValidateUser(AES.Shared.Contracts.ApplicantInfoContract userInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecuritySvc/ValidateUser", ReplyAction="http://tempuri.org/ISecuritySvc/ValidateUserResponse")]
        System.Threading.Tasks.Task<AES.Shared.Contracts.ApplicantInfoContract> ValidateUserAsync(AES.Shared.Contracts.ApplicantInfoContract userInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecuritySvc/ValidateEmployeeUser", ReplyAction="http://tempuri.org/ISecuritySvc/ValidateEmployeeUserResponse")]
        AES.Shared.Contracts.EmployeeUserContract ValidateEmployeeUser(AES.Shared.Contracts.EmployeeCredentialsContract credentials);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecuritySvc/ValidateEmployeeUser", ReplyAction="http://tempuri.org/ISecuritySvc/ValidateEmployeeUserResponse")]
        System.Threading.Tasks.Task<AES.Shared.Contracts.EmployeeUserContract> ValidateEmployeeUserAsync(AES.Shared.Contracts.EmployeeCredentialsContract credentials);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecuritySvc/CreateEmployee", ReplyAction="http://tempuri.org/ISecuritySvc/CreateEmployeeResponse")]
        bool CreateEmployee(AES.Shared.Contracts.EmployeeUserContract employeeInfo, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISecuritySvc/CreateEmployee", ReplyAction="http://tempuri.org/ISecuritySvc/CreateEmployeeResponse")]
        System.Threading.Tasks.Task<bool> CreateEmployeeAsync(AES.Shared.Contracts.EmployeeUserContract employeeInfo, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISecuritySvcChannel : AES.Web.SecurityService.ISecuritySvc, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SecuritySvcClient : System.ServiceModel.ClientBase<AES.Web.SecurityService.ISecuritySvc>, AES.Web.SecurityService.ISecuritySvc {
        
        public SecuritySvcClient() {
        }
        
        public SecuritySvcClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SecuritySvcClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SecuritySvcClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SecuritySvcClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public AES.Shared.Contracts.ApplicantInfoContract ValidateUser(AES.Shared.Contracts.ApplicantInfoContract userInfo) {
            return base.Channel.ValidateUser(userInfo);
        }
        
        public System.Threading.Tasks.Task<AES.Shared.Contracts.ApplicantInfoContract> ValidateUserAsync(AES.Shared.Contracts.ApplicantInfoContract userInfo) {
            return base.Channel.ValidateUserAsync(userInfo);
        }
        
        public AES.Shared.Contracts.EmployeeUserContract ValidateEmployeeUser(AES.Shared.Contracts.EmployeeCredentialsContract credentials) {
            return base.Channel.ValidateEmployeeUser(credentials);
        }
        
        public System.Threading.Tasks.Task<AES.Shared.Contracts.EmployeeUserContract> ValidateEmployeeUserAsync(AES.Shared.Contracts.EmployeeCredentialsContract credentials) {
            return base.Channel.ValidateEmployeeUserAsync(credentials);
        }
        
        public bool CreateEmployee(AES.Shared.Contracts.EmployeeUserContract employeeInfo, string password) {
            return base.Channel.CreateEmployee(employeeInfo, password);
        }
        
        public System.Threading.Tasks.Task<bool> CreateEmployeeAsync(AES.Shared.Contracts.EmployeeUserContract employeeInfo, string password) {
            return base.Channel.CreateEmployeeAsync(employeeInfo, password);
        }
    }
}
