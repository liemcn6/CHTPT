﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

// 
// This source code was auto-generated by wsdl, Version=4.8.3928.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Web.Services.WebServiceBindingAttribute(Name="ExamForNtp01Soap", Namespace="http://www.hocvienmang.com/")]
public partial class ExamForNtp01 : System.Web.Services.Protocols.SoapHttpClientProtocol {
    
    private System.Threading.SendOrPostCallback GetNtpMessageOperationCompleted;
    
    private System.Threading.SendOrPostCallback SubmitOperationCompleted;
    
    /// <remarks/>
    public ExamForNtp01() {
        this.Url = "http://hocvienmang.com/Exams/ExamForNtp01.asmx";
    }

    internal long GetNtpMessage(string v1, string v2, int v3, int v4, object originateTimeUtcTick, object ntpMesage)
    {
        throw new NotImplementedException();
    }

    /// <remarks/>
    public event GetNtpMessageCompletedEventHandler GetNtpMessageCompleted;
    
    /// <remarks/>
    public event SubmitCompletedEventHandler SubmitCompleted;
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.hocvienmang.com/GetNtpMessage", RequestNamespace="http://www.hocvienmang.com/", ResponseNamespace="http://www.hocvienmang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public string GetNtpMessage(string UserName, string UserPass, int ExamId, long QuestionId, ref long OriginateTimeUtcTick, [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")] ref byte[] ntpMesage) {
        object[] results = this.Invoke("GetNtpMessage", new object[] {
                    UserName,
                    UserPass,
                    ExamId,
                    QuestionId,
                    OriginateTimeUtcTick,
                    ntpMesage});
        OriginateTimeUtcTick = ((long)(results[1]));
        ntpMesage = ((byte[])(results[2]));
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetNtpMessage(string UserName, string UserPass, int ExamId, long QuestionId, long OriginateTimeUtcTick, byte[] ntpMesage, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetNtpMessage", new object[] {
                    UserName,
                    UserPass,
                    ExamId,
                    QuestionId,
                    OriginateTimeUtcTick,
                    ntpMesage}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndGetNtpMessage(System.IAsyncResult asyncResult, out long OriginateTimeUtcTick, out byte[] ntpMesage) {
        object[] results = this.EndInvoke(asyncResult);
        OriginateTimeUtcTick = ((long)(results[1]));
        ntpMesage = ((byte[])(results[2]));
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public void GetNtpMessageAsync(string UserName, string UserPass, int ExamId, long QuestionId, long OriginateTimeUtcTick, byte[] ntpMesage) {
        this.GetNtpMessageAsync(UserName, UserPass, ExamId, QuestionId, OriginateTimeUtcTick, ntpMesage, null);
    }
    
    /// <remarks/>
    public void GetNtpMessageAsync(string UserName, string UserPass, int ExamId, long QuestionId, long OriginateTimeUtcTick, byte[] ntpMesage, object userState) {
        if ((this.GetNtpMessageOperationCompleted == null)) {
            this.GetNtpMessageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetNtpMessageOperationCompleted);
        }
        this.InvokeAsync("GetNtpMessage", new object[] {
                    UserName,
                    UserPass,
                    ExamId,
                    QuestionId,
                    OriginateTimeUtcTick,
                    ntpMesage}, this.GetNtpMessageOperationCompleted, userState);
    }
    
    private void OnGetNtpMessageOperationCompleted(object arg) {
        if ((this.GetNtpMessageCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetNtpMessageCompleted(this, new GetNtpMessageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.hocvienmang.com/Submit", RequestNamespace="http://www.hocvienmang.com/", ResponseNamespace="http://www.hocvienmang.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public string Submit(string UserName, string UserPass, int ExamId, long QuestionId, System.DateTime OriginateSendTimestamp, System.DateTime ReceiveTimestamp, System.DateTime TransmitTimestamp, System.DateTime OriginateReceiveTime, long DifferentTicks, System.DateTime DateTimeAfterSynchronize) {
        object[] results = this.Invoke("Submit", new object[] {
                    UserName,
                    UserPass,
                    ExamId,
                    QuestionId,
                    OriginateSendTimestamp,
                    ReceiveTimestamp,
                    TransmitTimestamp,
                    OriginateReceiveTime,
                    DifferentTicks,
                    DateTimeAfterSynchronize});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginSubmit(string UserName, string UserPass, int ExamId, long QuestionId, System.DateTime OriginateSendTimestamp, System.DateTime ReceiveTimestamp, System.DateTime TransmitTimestamp, System.DateTime OriginateReceiveTime, long DifferentTicks, System.DateTime DateTimeAfterSynchronize, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("Submit", new object[] {
                    UserName,
                    UserPass,
                    ExamId,
                    QuestionId,
                    OriginateSendTimestamp,
                    ReceiveTimestamp,
                    TransmitTimestamp,
                    OriginateReceiveTime,
                    DifferentTicks,
                    DateTimeAfterSynchronize}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndSubmit(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public void SubmitAsync(string UserName, string UserPass, int ExamId, long QuestionId, System.DateTime OriginateSendTimestamp, System.DateTime ReceiveTimestamp, System.DateTime TransmitTimestamp, System.DateTime OriginateReceiveTime, long DifferentTicks, System.DateTime DateTimeAfterSynchronize) {
        this.SubmitAsync(UserName, UserPass, ExamId, QuestionId, OriginateSendTimestamp, ReceiveTimestamp, TransmitTimestamp, OriginateReceiveTime, DifferentTicks, DateTimeAfterSynchronize, null);
    }
    
    /// <remarks/>
    public void SubmitAsync(string UserName, string UserPass, int ExamId, long QuestionId, System.DateTime OriginateSendTimestamp, System.DateTime ReceiveTimestamp, System.DateTime TransmitTimestamp, System.DateTime OriginateReceiveTime, long DifferentTicks, System.DateTime DateTimeAfterSynchronize, object userState) {
        if ((this.SubmitOperationCompleted == null)) {
            this.SubmitOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSubmitOperationCompleted);
        }
        this.InvokeAsync("Submit", new object[] {
                    UserName,
                    UserPass,
                    ExamId,
                    QuestionId,
                    OriginateSendTimestamp,
                    ReceiveTimestamp,
                    TransmitTimestamp,
                    OriginateReceiveTime,
                    DifferentTicks,
                    DateTimeAfterSynchronize}, this.SubmitOperationCompleted, userState);
    }
    
    private void OnSubmitOperationCompleted(object arg) {
        if ((this.SubmitCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.SubmitCompleted(this, new SubmitCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    public new void CancelAsync(object userState) {
        base.CancelAsync(userState);
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
public delegate void GetNtpMessageCompletedEventHandler(object sender, GetNtpMessageCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetNtpMessageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal GetNtpMessageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public string Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((string)(this.results[0]));
        }
    }
    
    /// <remarks/>
    public long OriginateTimeUtcTick {
        get {
            this.RaiseExceptionIfNecessary();
            return ((long)(this.results[1]));
        }
    }
    
    /// <remarks/>
    public byte[] ntpMesage {
        get {
            this.RaiseExceptionIfNecessary();
            return ((byte[])(this.results[2]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
public delegate void SubmitCompletedEventHandler(object sender, SubmitCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.8.3928.0")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class SubmitCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal SubmitCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public string Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((string)(this.results[0]));
        }
    }
}