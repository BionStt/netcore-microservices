# Netcore-Microservices

## Development

docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d


## AKS

### Deployment

kubectl apply -f .\deployment\aks\services\basket-api\
kubectl apply -f .\deployment\aks\services\catalog-api\
kubectl apply -f .\deployment\aks\services\discount-api\
kubectl apply -f .\deployment\aks\services\discount\discount-api\
kubectl apply -f .\deployment\aks\services\discount\discount-db\

### Examples

kubectl apply -f .\deployment\aks\examples\postgres\