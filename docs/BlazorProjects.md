# BlazorProjects (client-side)  
Whether you build a stand-alone blazor app or one that is meant to be an a mult-hosted environment its better to build them as if thery are meant to be multi-hosted.  

## Protect against collision
Modify [csproj](/src/BlazorAppRealTime/BlazorAppRealTime.csproj) so that the clientside content is in a unique folder.  
```
  <StaticWebAssetBasePath>BlazorHost/BlazorAppRealTime</StaticWebAssetBasePath>
```
This will result in all the clientside files ```(_content excluded)``` to be published to;
```
/wwwroot/BlazorHost/BlazorAppRealTime/_framework/{files}
/wwwroot/BlazorHost/BlazorAppRealTime/css/{files}
/wwwroot/BlazorHost/BlazorAppRealTime/sample-data/{files}
/wwwroot/BlazorHost/BlazorAppRealTime/favicon.ico
/wwwroot/BlazorHost/BlazorAppRealTime/index.html 
```
## ThirdParty problem
When you include a third-party component library such as;
```
 <PackageReference Include="BlazorPro.Spinkit" Version="1.2.0" />
```
This will result in publishing not honoring the following;
```
  <StaticWebAssetBasePath>BlazorHost/BlazorAppRealTime</StaticWebAssetBasePath>
```
This will result in.  
```
/wwwroot/BlazorHost/BlazorAppRealTime/_framework/{files}
/wwwroot/BlazorHost/BlazorAppRealTime/css/{files}
/wwwroot/BlazorHost/BlazorAppRealTime/sample-data/{files}
/wwwroot/BlazorHost/BlazorAppRealTime/favicon.ico
/wwwroot/BlazorHost/BlazorAppRealTime/index.html 
/wwwroot/_content/BlazorPro.Spinkit/{files} 
```
We have a **COLLISION** problem now.  If you have multiple blazor apps and each includes ```BlazorPro.Spinkit``` and each has a different version then its anyones guess as to what versio of ```BlazorPro.Spinkit``` content files will finally be in the final publish.  

## Workaround.
1. In your blazor project do a publish at dev time.
2. Copy everthing from  
     ```{blazorproject}\bin\Release\netcoreapp3.1\publish\wwwroot\BlazorHost\BlazorAppRealTime\_content\{*}``` 
     to
     ```{blazorproject}\wwwroot\_content\{*}```
3. Check it into your project (now you own it)
4. Repeat each time you change any thirdparty components.
5. Keep asking Microsoft to fix this in tooling.


Ok, now you have a blazor project that publishes to unique folders.
     

