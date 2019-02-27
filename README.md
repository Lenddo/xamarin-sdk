# Lenddo Xamarin SDK

# Table of Contents

- [Introduction](#introduction)
- [Pre-requisites](#pre-requisites)
- [Building the Demo Application](#building-the-demo-application)

## Introduction

The Lenddo Xamarin SDK allows you to collect information in order for Lenddo to verify the user's information and enhance its scoring capabilities. The Lenddo SDK connects to user's social networks and also collects information and mobile data in the background and can be activated as soon as the user has downloaded the app, granted permissions and logged into the app.

## Pre-requisites

Make sure you have Visual Studio setup and installed, and with tools for mobile development. 

Before incorporating the Onboarding and Data SDK into your app, you should be provided with the following information:

- Data Partner Script ID
- Onboarding Partner Script ID

Please ask for the information above from your Lenddo representative. If you have a dashboard account, these values can also be found there.

There may be also other partner specific values that you are required to set.

## Building the Demo Application

1. Clone the repository and open the solution. There will be 2 projects:

- LenddoSDK
- LenddoSDKXamarinDemo

2. Setup the current project by going to Project > Properties

- Compile using Android version: (Target Framework), Select `Android 8.1 Oreo`

![Project Properties](https://github.com/Lenddo/xamarin-sdk/blob/feature/data-sdk/LenddoSDK/Wiki/project_properties.PNG)

3. Create a Bindings Library for the Android Archive file, lenddosdk-release.aar. 

- Please make sure that the Build Action is `LibraryProjectZip`

![Build Action](https://github.com/Lenddo/xamarin-sdk/blob/feature/data-sdk/LenddoSDK/Wiki/aar_build_action.PNG)

4. NuGet dependencies 

- In case that there is an error on the NuGet dependencies, you may try to run `Update-Package -reinstall` command in the Package Manager Console 

5. In your project that will utilize the LenddoSDK, please make sure that the LenddoSDK is added as a reference under `Projects > Solution` in the Reference Manager 

![Reference](https://github.com/Lenddo/xamarin-sdk/blob/feature/data-sdk/LenddoSDK/Wiki/add_reference_project.PNG)
