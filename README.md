# OurSmsClient

> package for our sms api
- [oursms](https://oursms.app/)

## Installation
dotnet add package OurSmsClient --version 1.0.1

## Code 
userId - key get these parameters from your platform

## Use Dependency Injection
in startup.cs in ConfigureServices method

services.AddOurSms(userId,key);

## in your service, inject IOurSmsClient
<pre>
private readonly IOurSmsClient _ourSmsClient;

public TestClass(IOurSmsClient ourSmsClient)
{
    _ourSmsClient = ourSmsClient;
}
</pre>

### Send One Sms
<pre>
var response = _ourSmsClient.SendOneMessage(phoneNumber, message);
</pre>
> phoneNumber string type, message string type

### Send Otp Sms
<pre>
var respone = _ourSmsClient.SendOtp(phoneNumber, otp);
</pre>
> phoneNumber string type, otp string type


### Get Status Of Message
<pre>
var status = _ourSmsClient.MessageStatus(messageId);
</pre>
> messageId string type get from response of send message
