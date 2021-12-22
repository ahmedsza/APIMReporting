# APIMReporting

This is a simple POC that is used to extract data from API Management. 
Specifically it uses the Reports API - https://docs.microsoft.com/en-us/rest/api/apimanagement/current-ga/reports/list-by-request 

You need to fill in the subscription id, resource group name and the API Management service name

it uses https://docs.microsoft.com/en-us/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet to get the bearer token. 
See https://azuresdkdocs.blob.core.windows.net/$web/dotnet/Azure.Identity/1.0.0/api/index.html for more information
