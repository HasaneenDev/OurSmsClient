# OurSmsClient

> package for our sms api
- [oursms](https://oursms.app/)

## Installation
dotnet add package OurSmsClient --version 1.0.1

## Code 
userId - key get these parameters from your platform

var oursms = new OurSmsClient(userId, key);
> userId int type, key string type

### Send One Sms
var response = oursms.SendOneMessage(phoneNumber, message);
> phoneNumber string type, message string type

### Send Otp Sms
var respone = oursms.SendOtp(phoneNumber, otp);
> phoneNumber string type, otp string type


### Get Status Of Message
var status = oursms.MessageStatus(messageId);
> messageId string type get from response of send message
