# book-fast

MVC 6 implementation of a facility management and booking playground app. This is basically a front-end app that relies on [BookFast API](https://github.com/dzimchuk/book-fast-api).

## Configuration

Use environment variables, user-secrets or appsettings.json to configure the project.

```
"Authentication": {
	"AzureAd": {
		"ApiResource": "BookFast API AppId in Azure AD, e.g. https://devunleashed.onmicrosoft.com/book-fast-api",
		"Instance": "<Your Azure AD instance, e.g. https://login.microsoftonline.com/>",
		"TenantId": "<Your Azure AD tenant ID>",
        "ClientId": "<Your BookFast app's client ID>",
		"ClientSecret": "<Your BookFast app's client secret>",
		"PostLogoutRedirectUri": "e.g. https://localhost:44380/",
		"B2C": {
			"Instance": "<Your Azure AD B2C instance>",
        	"TenantId": "<Your Azure AD B2C tenant>",
        	"ClientId": "",
        	"ClientSecret": "",
        	"PostLogoutRedirectUri": "e.g. https://localhost:44380/",
        	"Policies": {
          		"SignInPolicy": "",
          		"SignUpPolicy": "",
          		"EditProfilePolicy": ""
        	}
      	}
	}
},
"BookFastApi": {
	"BaseUrl": "e.g. https://localhost:44337"
}
```