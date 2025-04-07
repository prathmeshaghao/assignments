import { ApplicationConfig, mergeApplicationConfig } from '@angular/core';
import { appConfig } from './app.config'; // ✅ Ensure correct path

export const serverConfig: ApplicationConfig = {
  providers: []
};

// ✅ Fix: Use `appConfig` correctly
export const config = mergeApplicationConfig(appConfig, serverConfig);
