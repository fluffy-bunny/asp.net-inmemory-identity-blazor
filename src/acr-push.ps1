docker images
az acr login --name acrchaosbunny

docker tag fluffybunny/inmemoryidentityappblazor:latest acrchaosbunny.azurecr.io/fluffybunny/inmemoryidentityappblazor:latest
docker push acrchaosbunny.azurecr.io/fluffybunny/inmemoryidentityappblazor:latest

