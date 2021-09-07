kubectl create namespace kong
helm repo add kong https://charts.konghq.com
helm repo update

kubectl create secret tls kong-cluster-cert -n kong --cert=tls.crt --key=tls.key
kubectl create secret generic kong-cluster-ca -n kong --from-file=ca.crt=ca.crt

helm install my-kong kong/kong -n kong --values values.yaml
