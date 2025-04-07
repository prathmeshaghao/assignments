import { bootstrapApplication } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http';
import { provideRouter } from '@angular/router';

import { AppComponent } from './app/app.component';
import { routes } from './app/app.routes'; // Import routes separately

bootstrapApplication(AppComponent, {
  providers: [
    provideHttpClient(),
    provideRouter(routes) // Use standalone routing
  ]
}).catch(err => console.error(err));
