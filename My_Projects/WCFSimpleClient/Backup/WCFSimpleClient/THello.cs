﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5472
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName = "IHello")]
public interface IHello
{

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IHello/SayHello", ReplyAction = "http://tempuri.org/IHello/SayHelloResponse")]
    string SayHello();
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IHelloChannel : IHello, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class HelloClient : System.ServiceModel.ClientBase<IHello>, IHello
{

    public HelloClient()
    {
    }

    public HelloClient(string endpointConfigurationName)
        :
            base(endpointConfigurationName)
    {
    }

    public HelloClient(string endpointConfigurationName, string remoteAddress)
        :
            base(endpointConfigurationName, remoteAddress)
    {
    }

    public HelloClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
        :
            base(endpointConfigurationName, remoteAddress)
    {
    }

    public HelloClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress)
        :
            base(binding, remoteAddress)
    {
    }

    public string SayHello()
    {
        return base.Channel.SayHello();
    }
}
