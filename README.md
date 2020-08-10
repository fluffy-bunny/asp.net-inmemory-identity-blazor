# asp.net 3.1 inmemory-identity client-side-blazor template
```OIDC```
```WASM```
```BLAZOR```
```ASP.NET Identity```
```Cookie Auth```

This project uses asp.net Identity.  There is no user database, but relies on external OIDC IDPs (Google, IdentityServer, Azure AD) to do the heavy lifting when it comes to user management.  This implemenation accepts all users that the external IDPs have.

# Blazor
No IdentityServer JWT stuff here.  I am using good ole cookie auth, where the client side HTTPClient will automatically redirect to the ```/Identity/Account/Login``` page if any api calls come back with Unauthorized or Forbidden.  


# Secrets.json
Example..  
```
{
  "ApplicationInsights:InstrumentationKey": "<secret>",
  "oidc:1:clientId": "62cb1f99-3dce-4d29-a1c6-1e90f5de4ae4",
  "oidc:1:clientSecret": "<secret>",
  "oidc:1:authority": "https://login.microsoftonline.com/<secret>/v2.0/",
  "oidc:2:clientId": "<secret>.apps.googleusercontent.com",
  "oidc:2:clientSecret": "<secret>",
  "oidc:2:authority": "https://accounts.google.com/"
}

```






