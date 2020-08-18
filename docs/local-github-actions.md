# Local Github Actions 
For this the following technology is used;  
[nektos act](https://github.com/nektos/act)   

On windows bring up a WSL2 command prompt.  

# Secrets
```
az login --service-principal -u {secret} -p {secret} --tenant {secret}
export NUGET_DEVEXPRESS_COM='https://nuget.devexpress.com/{secret}/api'
export REGISTRY_NAME='p7coredockerhub'
export REGISTRY_LOGIN_SERVER='p7coredockerhub.azurecr.io'
export AZURE_CREDENTIALS='{secret}'
export ARM_CLIENT_ID="{secret}"
export ARM_CLIENT_SECRET="{secret}"
export ARM_SUBSCRIPTION_ID=$(az account show --query id | xargs)
export ARM_TENANT_ID=$(az account show --query tenantId | xargs)
```
How local ACT knows about the secrets is the presense of the following [file](/.actrc) where it maps environment variable to github action secrets.  

