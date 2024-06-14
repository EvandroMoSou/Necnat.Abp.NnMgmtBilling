import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'NnMgmtBilling',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44323/',
    redirectUri: baseUrl,
    clientId: 'NnMgmtBilling_App',
    responseType: 'code',
    scope: 'offline_access NnMgmtBilling',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44323',
      rootNamespace: 'Necnat.Abp.NnMgmtBilling',
    },
    NnMgmtBilling: {
      url: 'https://localhost:44344',
      rootNamespace: 'Necnat.Abp.NnMgmtBilling',
    },
  },
} as Environment;
