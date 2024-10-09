// create a new app service and a new app service plan
resource appServicePlan 'Microsoft.Web/serverfarms@2020-06-01' = {
  name: 'myAppServicePlan'
  location: resourceGroup().location
  sku: {
    name: 'F1'
    tier: 'Free'
  }
}

resource appService 'Microsoft.Web/sites@2020-06-01' = {
  name: 'myAppService'
  location: resourceGroup().location
  properties: {
    serverFarmId: appServicePlan.id
  }
}
