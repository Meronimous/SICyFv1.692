﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------
Option Strict On
Option Explicit On
Imports System
Imports System.Runtime.Serialization
Namespace AFIP.HOMO
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0"),  _
     System.Runtime.Serialization.DataContractAttribute(Name:="LoginFault", [Namespace]:="https://wsaahomo.afip.gov.ar/ws/services/LoginCms"),  _
     System.SerializableAttribute()>  _
    Partial Public Class LoginFault
        Inherits Object
        Implements System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
        <System.NonSerializedAttribute()>  _
        Private extensionDataField As System.Runtime.Serialization.ExtensionDataObject
        <Global.System.ComponentModel.BrowsableAttribute(false)>  _
        Public Property ExtensionData() As System.Runtime.Serialization.ExtensionDataObject Implements System.Runtime.Serialization.IExtensibleDataObject.ExtensionData
            Get
                Return Me.extensionDataField
            End Get
            Set
                Me.extensionDataField = value
            End Set
        End Property
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute([Namespace]:="https://wsaahomo.afip.gov.ar/ws/services/LoginCms", ConfigurationName:="AFIP.HOMO.LoginCMS")>  _
    Public Interface LoginCMS
        'CODEGEN: Generating message contract since the wrapper namespace (http://wsaa.view.sua.dvadac.desein.afip.gov) of message loginCmsRequest does not match the default value (https://wsaahomo.afip.gov.ar/ws/services/LoginCms)
        <System.ServiceModel.OperationContractAttribute(Action:="", ReplyAction:="*"),  _
         System.ServiceModel.FaultContractAttribute(GetType(AFIP.HOMO.LoginFault), Action:="", Name:="fault")>  _
        Function loginCms(ByVal request As AFIP.HOMO.loginCmsRequest) As AFIP.HOMO.loginCmsResponse
        <System.ServiceModel.OperationContractAttribute(Action:="", ReplyAction:="*")>  _
        Function loginCmsAsync(ByVal request As AFIP.HOMO.loginCmsRequest) As System.Threading.Tasks.Task(Of AFIP.HOMO.loginCmsResponse)
    End Interface
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="loginCms", WrapperNamespace:="http://wsaa.view.sua.dvadac.desein.afip.gov", IsWrapped:=true)>  _
    Partial Public Class loginCmsRequest
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://wsaa.view.sua.dvadac.desein.afip.gov", Order:=0)>  _
        Public in0 As String
        Public Sub New()
            MyBase.New
        End Sub
        Public Sub New(ByVal in0 As String)
            MyBase.New
            Me.in0 = in0
        End Sub
    End Class
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(WrapperName:="loginCmsResponse", WrapperNamespace:="http://wsaa.view.sua.dvadac.desein.afip.gov", IsWrapped:=true)>  _
    Partial Public Class loginCmsResponse
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://wsaa.view.sua.dvadac.desein.afip.gov", Order:=0)>  _
        Public loginCmsReturn As String
        Public Sub New()
            MyBase.New
        End Sub
        Public Sub New(ByVal loginCmsReturn As String)
            MyBase.New
            Me.loginCmsReturn = loginCmsReturn
        End Sub
    End Class
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface LoginCMSChannel
        Inherits AFIP.HOMO.LoginCMS, System.ServiceModel.IClientChannel
    End Interface
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class LoginCMSClient
        Inherits System.ServiceModel.ClientBase(Of AFIP.HOMO.LoginCMS)
        Implements AFIP.HOMO.LoginCMS
        Public Sub New()
            MyBase.New
        End Sub
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function AFIP_HOMO_LoginCMS_loginCms(ByVal request As AFIP.HOMO.loginCmsRequest) As AFIP.HOMO.loginCmsResponse Implements AFIP.HOMO.LoginCMS.loginCms
            Return MyBase.Channel.loginCms(request)
        End Function
        Public Function loginCms(ByVal in0 As String) As String
            Dim inValue As AFIP.HOMO.loginCmsRequest = New AFIP.HOMO.loginCmsRequest()
            inValue.in0 = in0
            Dim retVal As AFIP.HOMO.loginCmsResponse = CType(Me,AFIP.HOMO.LoginCMS).loginCms(inValue)
            Return retVal.loginCmsReturn
        End Function
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function AFIP_HOMO_LoginCMS_loginCmsAsync(ByVal request As AFIP.HOMO.loginCmsRequest) As System.Threading.Tasks.Task(Of AFIP.HOMO.loginCmsResponse) Implements AFIP.HOMO.LoginCMS.loginCmsAsync
            Return MyBase.Channel.loginCmsAsync(request)
        End Function
        Public Function loginCmsAsync(ByVal in0 As String) As System.Threading.Tasks.Task(Of AFIP.HOMO.loginCmsResponse)
            Dim inValue As AFIP.HOMO.loginCmsRequest = New AFIP.HOMO.loginCmsRequest()
            inValue.in0 = in0
            Return CType(Me,AFIP.HOMO.LoginCMS).loginCmsAsync(inValue)
        End Function
    End Class
End Namespace
