# Authentication and Authorization
I am using cookie auth instead of the IdentityServer JWT Bearer token approach.  The design requires that the blazor app use an HTTPClient that will redirect to the servers login when any REST calls return an Unauthorized or Forbidden response.  

```
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        ....
        builder.AddClientSideAuth();
        ...
        await builder.Build().RunAsync();
    }
```
This introduces the following service;  
[IHostHttpClient](/src/ClientSideAuth/IHostHttpClient.cs) and an example usage [FetchAuthStatusService](/src/BlazorAppRealTime/Services/FetchAuthStatusService.cs)  

**NOTE**: This is meant simply for the blazor app to call its hosting webapp apis.  If you want to make a calls to different endpoints, than those HttpClients will need to use some sort of bearer token approach.  

My [AccountHelper]( /src/ClientSideAuth/AccountHelper.cs) is hard coded to use the following URLs;  
```
 private const string LogInPath = "Identity/Account/Login";
 private const string LogOutPath = "Identity/Account/Logout";
```
as this is the out of the box asp.net Identity endpoints.  

Also, what you get for free is a timer that will do a full page reload based upon the auth cookies expiration.  Saying that, I am make it easier on myself and returning the follwing response header if the server thinks its in an authenticated state;  

```
 var query = from item in responseMessage.Headers
                           where item.Key == "x-authexpsec"
                            select item.Value;
```
This returns the # seconds until we expire.  When we get this back we restart the timer, hence we slide it out.  
I introduced a server-side middleware([AuthenticationPeekMiddleware](/src/InMemoryIdentityApp/Authorization/AuthenticationPeekMiddleware.cs)) that runs after the stock Auth;  
```
private void UseAuthMiddleware(IApplicationBuilder builder)
{
    builder.UseAuthentication();
    builder.UseAuthorization();
    builder.UseMiddleware<AuthenticationPeekMiddleware>();
}
```


