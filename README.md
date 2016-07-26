# book-fast

MVC 6 implementation of a multitenant facility management and booking playground app. This is basically a front-end app that relies on [BookFast API](https://github.com/dzimchuk/book-fast-api).

## Configuration

Use environment variables, user-secrets or appsettings.json to configure the project.

```
"Authentication": {
	"AzureAd": {
		"ApiResource": "BookFast API AppId in Azure AD, e.g. https://devunleashed.onmicrosoft.com/book-fast-api",
		"Instance": "<Your Azure AD instance, e.g. https://login.microsoftonline.com/>",
		"ValidIssuers": "Comma separated list of tenant identifiers, e.g. https://sts.windows.net/490789ec-b183-4ba5-97cf-e69ec8870130/,https://sts.windows.net/f418e7eb-0dcd-40be-9b81-c58c87c57d9a/",
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
          		"SignInOrSignUpPolicy": "",
          		"EditProfilePolicy": ""
        	}
      	}
	}
},
"BookFastApi": {
	"BaseUrl": "e.g. https://localhost:44337"
}
```